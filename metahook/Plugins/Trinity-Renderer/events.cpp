#include "metahook.h"
#include "plugins.h"
#include "util_vector.h"
#include "exportfuncs.h"

#include "events.h"
#include "pmtrace.h"
#include "pm_defs.h"
#include "pm_materials.h"
#include "event_api.h"

#include "particle_engine.h"
#include "bsprenderer.h"

#include "studio.h"
#include "StudioModelRenderer.h"

extern CGameStudioModelRenderer g_StudioRenderer;

void(*g_pfnEV_HLDM_DecalGunshot)(pmtrace_t *pTrace, int iBulletType, float scale, int r, int g, int b, bool bCreateSparks, char cTextureType) = (void(*)(pmtrace_t *, int, float, int, int, int, bool, char))0x19020B0;
void(*g_pfnEV_HLDM_FireBullets)(int idx, float *forward, float *right, float *up, int cShots, float *vecSrc, float *vecDirShooting, float *vecSpread, float flDistance, int iBulletType, int iTracerFreq, int *tracerCount, int iPenetration) = (void(*)(int, float *, float *, float *, int, float *, float *, float *, float, int, int, int *, int))0x1902460;

void EV_HLDM_DecalGunshot(pmtrace_t *pTrace, int iBulletType, float scale, int r, int g, int b, bool bCreateSparks, char cTextureType);
void EV_HLDM_FireBullets(int idx, float *forward, float *right, float *up, int cShots, float *vecSrc, float *vecDirShooting, float *vecSpread, float flDistance, int iBulletType, int iTracerFreq, int *tracerCount, int iPenetration);
void EV_InstallHooks();

typedef enum
{
	BULLET_NONE = 0,
	BULLET_PLAYER_9MM,
	BULLET_PLAYER_MP5,
	BULLET_PLAYER_357,
	BULLET_PLAYER_BUCKSHOT,
	BULLET_PLAYER_CROWBAR,

	BULLET_MONSTER_9MM,
	BULLET_MONSTER_MP5,
	BULLET_MONSTER_12MM,

	BULLET_PLAYER_45ACP,
	BULLET_PLAYER_338MAG,
	BULLET_PLAYER_762MM,
	BULLET_PLAYER_556MM,
	BULLET_PLAYER_50AE,
	BULLET_PLAYER_57MM,
	BULLET_PLAYER_357SIG
}
Bullet;


void EV_Init()
{
	EV_InstallHooks();
}

void EV_InstallHooks()
{
	if (g_dwEngineBuildnum >= 5971)
	{
		DWORD dwClientBase = g_pMetaHookAPI->GetModuleBase(GetModuleHandle("client.dll"));
		g_pfnEV_HLDM_DecalGunshot = (void(*)(pmtrace_t *, int, float, int, int, int, bool, char))(dwClientBase + 0x20B0);
		g_pfnEV_HLDM_FireBullets = (void(*)(int, float *, float *, float *, int, float *, float *, float *, float, int, int, int *, int))(dwClientBase + 0x2460);
	}

	g_pMetaHookAPI->InlineHook(g_pfnEV_HLDM_DecalGunshot, EV_HLDM_DecalGunshot, (void *&)g_pfnEV_HLDM_DecalGunshot);
	g_pMetaHookAPI->InlineHook(g_pfnEV_HLDM_FireBullets, EV_HLDM_FireBullets, (void *&)g_pfnEV_HLDM_FireBullets);
}

void EV_HLDM_DecalGunshot(pmtrace_t *ptr, int iBulletType, float scale, int r, int g, int b, bool bCreateSparks, char cTextureType)
{
	physent_t *pe;
	pe = gEngfuncs.pEventAPI->EV_GetPhysent(ptr->ent);

	if (pe && pe->solid == SOLID_BSP)
	{
		static char decal[32];
		
		switch (cTextureType)
		{
		case CHAR_TEX_CONCRETE:
		case CHAR_TEX_TILE:
		default:
			{
				strcpy(decal, "shot");
				gParticleEngine.CreateCluster("concrete_impact_cluster.txt", ptr->endpos, ptr->plane.normal, 0);
				break;
			}
		case CHAR_TEX_GRATE:
			{
				strcpy(decal, "shot_metal");
				break;
			}
		case CHAR_TEX_METAL:
			{
				strcpy(decal, "shot_metal");
				break;
			}
		case CHAR_TEX_VENT:
			{
				strcpy(decal, "shot_metal");
				break;
			}
		case CHAR_TEX_DIRT:
			{
				strcpy(decal, "shot");
				gParticleEngine.CreateCluster("dirt_impact_cluster.txt", ptr->endpos, ptr->plane.normal, 0);
				break;
			}
		case CHAR_TEX_WOOD:
			{
				strcpy(decal, "shot_wood");
				gParticleEngine.CreateCluster("wood_impact_cluster.txt", ptr->endpos, ptr->plane.normal, 0);
				break;
			}
		case CHAR_TEX_COMPUTER:
			{
				strcpy(decal, "shot");
				break;
			}
		case CHAR_TEX_GLASS:
			{
				strcpy(decal, "shot_glass");
				gParticleEngine.CreateCluster("glass_impact_cluster.txt", ptr->endpos, ptr->plane.normal, 0);
				break;
			}
		}
		
		if (ptr->ent == 0 || pe->name[0] == '*')
			gBSPRenderer.CreateDecal(ptr->endpos, ptr->plane.normal, decal, FALSE);
		else
			g_StudioRenderer.StudioDecalExternal(ptr->endpos, ptr->plane.normal, decal);

	}
}

void EV_HLDM_FireBullets(int idx, float *forward, float *right, float *up, int cShots, float *vecSrc, float *vecDirShooting, float *vecSpread, float flDistance, int iBulletType, int iTracerFreq, int *tracerCount, int iPenetration)
{
	pmtrace_t tr;

	for (int iShot = 1; iShot <= cShots; iShot++)
	{
		vec3_t vecDir, vecEnd;
		float x, y, z;

		if (iBulletType == BULLET_PLAYER_BUCKSHOT)
		{
			do
			{
				x = gEngfuncs.pfnRandomFloat(-0.5, 0.5) + gEngfuncs.pfnRandomFloat(-0.5, 0.5);
				y = gEngfuncs.pfnRandomFloat(-0.5, 0.5) + gEngfuncs.pfnRandomFloat(-0.5, 0.5);
				z = x * x + y * y;
			} while (z > 1);

			for (int i = 0; i < 3; i++)
			{
				vecDir[i] = vecDirShooting[i] + x * vecSpread[0] * right[i] + y * vecSpread[1] * up[i];
				vecEnd[i] = vecSrc[i] + flDistance * vecDir[i];
			}
		}
		else
		{
			for (int i = 0; i < 3; i++)
			{
				vecDir[i] = vecDirShooting[i] + vecSpread[0] * right[i] + vecSpread[1] * up[i];
				vecEnd[i] = vecSrc[i] + flDistance * vecDir[i];
			}
		}

		gEngfuncs.pEventAPI->EV_SetUpPlayerPrediction(false, false);
		gEngfuncs.pEventAPI->EV_PushPMStates();
		gEngfuncs.pEventAPI->EV_SetSolidPlayers(idx - 1);
		gEngfuncs.pEventAPI->EV_SetTraceHull(2);
		gEngfuncs.pEventAPI->EV_PlayerTrace(vecSrc, vecEnd, PM_STUDIO_IGNORE, -1, &tr);
		gEngfuncs.pEventAPI->EV_PopPMStates();

		if (tr.fraction == 1.0)
			continue;

		if (gEngfuncs.PM_PointContents(tr.endpos, NULL) != CONTENTS_WATER)
			continue;

		vec3_t start = vecSrc;
		vec3_t end = tr.endpos;
		int num = (end - start).Length() / 15;
		vec3_t sub = (end - start) / num;

		for (int i = 0; i < num; i++)
		{
			vec3_t check = end - sub * i;

			// Adjust the decal direction to be horizontal, this works assuming all water planes are horizontal.
			vec3_t decalDirection = { 0.0f, 0.0f, 1.0f };
			
			if (gEngfuncs.PM_PointContents(check, NULL) != CONTENTS_WATER)
			{
				gParticleEngine.CreateCluster("water_impact_cluster.txt", check, decalDirection, 0);
				break;
			}
		}

	}

	g_pfnEV_HLDM_FireBullets(idx, forward, right, up, cShots, vecSrc, vecDirShooting, vecSpread, flDistance, iBulletType, iTracerFreq, tracerCount, iPenetration);

}
