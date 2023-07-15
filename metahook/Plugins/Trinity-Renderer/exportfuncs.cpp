#include <cstdio>
#include <cstdlib>
#include <cmath>

#include "metahook.h"
#include "util_vector.h"
#include "hud.h"
#include "event_api.h"
#include "cl_util.h"
#include "player.h"
#include "r.h"
#include "events.h"
#include "message.h"
#include "svc_hook.h"

//RENDERERS START
#include "rendererdefs.h"
#include "bsprenderer.h"
#include "propmanager.h"
#include "textureloader.h"
#include "particle_engine.h"
#include "watershader.h"
#include "mirrormanager.h"
#include "r_efx.h"

#include "studio.h"
#include "StudioModelRenderer.h"

extern CGameStudioModelRenderer g_StudioRenderer;
extern engine_studio_api_t IEngineStudio;

CBSPRenderer gBSPRenderer;
CParticleEngine gParticleEngine;
CWaterShader gWaterShader;
CTextureLoader gTextureLoader;
CPropManager gPropManager;
CMirrorManager gMirrorManager;
//RENDERERS END

cl_enginefunc_t gEngfuncs;
CHud gHud;
efx_api_s gEfxAPI;

int g_iFlashLight;

int Initialize(struct cl_enginefuncs_s *pEnginefuncs, int iVersion)
{
	memcpy(&gEngfuncs, pEnginefuncs, sizeof(gEngfuncs));
	memcpy(&gEfxAPI, pEnginefuncs->pEfxAPI, sizeof(gEfxAPI));
	R_DisableSteamMSAA();

	pEnginefuncs->pfnHookUserMsg = &HookUserMsg;
	pEnginefuncs->pEfxAPI->R_BloodSprite = &R_BloodSprite;
	pEnginefuncs->pEfxAPI->R_BloodStream = &R_BloodStream;
	//pEnginefuncs->pEfxAPI->R_Explosion = &R_Explosion;
	pEnginefuncs->pEfxAPI->R_DecalShoot = &R_DecalShoot;
	pEnginefuncs->pEfxAPI->R_DecalRemoveAll = &R_DecalRemoveAll;
	//pEnginefuncs->pEfxAPI->Draw_DecalIndex = &Draw_DecalIndex;

	SVC_Init();
	R_Init();

	return gExportfuncs.Initialize(pEnginefuncs, iVersion);
}

void HUD_Init(void)
{
	R_Init2();

	gExportfuncs.HUD_Init();

	gHUD.Init();

	EV_Init();

	return;
}

int HUD_VidInit(void)
{
	gHUD.VidInit();

	R_VidInit();	// Esto carga tambien el propmanager que antes no estaba cargando

	return gExportfuncs.HUD_VidInit();
}

extern void HUD_PrintSpeeds(void);

int HUD_Redraw(float time, int intermission)
{
	gHUD.Redraw(time, intermission);

	HUD_PrintSpeeds();

	return gExportfuncs.HUD_Redraw(time, intermission);
}

void HUD_DrawNormalTriangles(void)
{
	gExportfuncs.HUD_DrawNormalTriangles();

	//RENDERERS START
	//2012-02-25
	R_DrawNormalTriangles();
	//RENDERERS END

	//gHUD.m_Spectator.DrawOverview();

#if defined( TEST_IT )
	//	Draw_Triangles();
#endif
}

void HUD_DrawTransparentTriangles(void)
{
	gExportfuncs.HUD_DrawTransparentTriangles();

	//RENDERERS START
	//2012-02-25
	R_DrawTransparentTriangles();
	//RENDERERS END

#if defined( TEST_IT )
	//	Draw_Triangles();
#endif
}

void HUD_CreateEntities(void)
{
	gExportfuncs.HUD_CreateEntities();

	//RENDERES START
	// Animate lights here
	gBSPRenderer.AnimateLight();

	// Do this here, not in refdef
	gBSPRenderer.SetupRenderer();

	if (g_iFlashLight)
	{
		cl_entity_t *pView = gEngfuncs.GetViewModel();

		if (pView)
			SetupFlashlight(Vector(pView->origin) + Vector(0, 0, 8), Vector(-pView->angles[0], pView->angles[1], pView->angles[2]), gEngfuncs.GetClientTime(), gHUD.m_flTimeDelta);
	}
	//RENDERERS END
}

int	HUD_AddEntity(int type, struct cl_entity_s *ent, const char *modelname)
{
	//RENDERERS START
	if (!gBSPRenderer.FilterEntities(type, ent, modelname))
		return 0;
	//RENDERERS END

	return gExportfuncs.HUD_AddEntity(type, ent, modelname);
}

void HUD_ProcessPlayerState(struct entity_state_s *dst, const struct entity_state_s *src)
{
	//RENDERERS START
	
	cl_entity_t *pPlayer = gEngfuncs.GetLocalPlayer();

	if (dst->number == gEngfuncs.GetLocalPlayer()->index)
	{
		//g_iTeamNumber = g_PlayerExtraInfo[dst->number].teamnumber;
		g_iUser1 = src->iuser1;
		g_iUser2 = src->iuser2;
		g_iUser3 = src->iuser3;
		g_iFlashLight = (src->effects & EF_DIMLIGHT);
	}
	//RENDERERS END

	return gExportfuncs.HUD_ProcessPlayerState(dst, src);
}

void HUD_Shutdown(void)
{
	/*
	gTextureLoader.Shutdown();
	gBSPRenderer.Shutdown();*/
	R_Shutdown();

	return gExportfuncs.HUD_Shutdown();
}

void HUD_TempEntUpdate(double frametime, double client_time, double cl_gravity, struct tempent_s **ppTempEntFree, struct tempent_s **ppTempEntActive, int(*Callback_AddVisibleEntity)(struct cl_entity_s *pEntity), void(*Callback_TempEntPlaySound)(struct tempent_s *pTemp, float damp))
{
	gExportfuncs.HUD_TempEntUpdate(frametime, client_time, cl_gravity, ppTempEntFree, ppTempEntActive, Callback_AddVisibleEntity, Callback_TempEntPlaySound);

	//RENDERERS START
	// Get bsp renderer list
	gBSPRenderer.GetRenderEnts();

	if (frametime > 0)
	{
		// Update particles
		gParticleEngine.Update();

		// Decay lights here
		gBSPRenderer.DecayLights();
	}
	//RENDERERS END

	// Nothing to simulate
	if (!*ppTempEntActive)
		return;

	TEMPENTITY *pTemp = *ppTempEntActive;

	while (pTemp)
	{
		if (!(pTemp->flags & FTENT_NOMODEL))
		{
			//RENDERERS START
			gBSPRenderer.AddEntity(&pTemp->entity);
			//RENDERERS END
		}
		pTemp = pTemp->next;
	}
}

void HUD_WeaponsPostThink(local_state_s *from, local_state_s *to, usercmd_t *cmd, double time, unsigned int random_seed)
{
	//g_pv_angles->x = v_angles.x;
	//g_pv_angles->y = v_angles.y;
	//g_pv_angles->z = v_angles.z;

	g_iCurrentWeapon = to->client.m_iId;
	g_iPlayerFlags = from->client.flags;
	g_flPlayerSpeed = Vector(from->client.velocity).Length();
	g_iWeaponFlags = (int)from->client.vuser4[0];
	//g_iFreezeTimeOver = from->client.iuser3 & IUSER3_FREEZETIMEOVER;
	//g_finalstate = to;
}

void HUD_PostRunCmd(struct local_state_s *from, struct local_state_s *to, struct usercmd_s *cmd, int runfuncs, double time, unsigned int random_seed)
{
	//g_runfuncs = runfuncs;

	if (!cl_lw)
		cl_lw = gEngfuncs.pfnGetCvarPointer("cl_lw");

	if (cl_lw && cl_lw->value)
	{
		HUD_WeaponsPostThink(from, to, cmd, time, random_seed);
	}
	else
	{
		//to->client.fov = g_lastFOV;
	}

	/*if (runfuncs)
	{
		CounterStrike_SetSequence(to->playerstate.sequence, to->playerstate.gaitsequence);
		CounterStrike_SetOrientation(to->playerstate.origin, cmd->viewangles);
	}*/

	gExportfuncs.HUD_PostRunCmd(from, to, cmd, runfuncs, time, random_seed);
}

// NO SE PARA QUE ES ESTO ( AVERIGUAR )
/*
==========================
CL_GetModelData


==========================
*/
void CL_GetModelByIndex(int iIndex, void** pPointer)
{
	void* pModel = IEngineStudio.GetModelByIndex(iIndex);
	*pPointer = pModel;
}