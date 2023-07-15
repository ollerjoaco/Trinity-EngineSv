#include <cstdio>
#include <cstdlib>
#include <cmath>

#include "metahook.h"
#include "util_vector.h"

#include "hud.h"
#include "cl_util.h"
#include "message.h"
#include "pm_shared.h"
#include "player.h"


//RENDERERS START
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

cvar_s *cl_righthand = NULL;
cvar_t *cl_lw = NULL;
//RENDERERS END

CHud gHUD;

int __MsgFunc_SetFOV(const char *pszName, int iSize, void *pbuf)
{
	return gHUD.MsgFunc_SetFOV(pszName, iSize, pbuf);
}

int __MsgFunc_Fog(const char *pszName, int iSize, void *pbuf)
{
	return gHUD.MsgFunc_Fog(pszName, iSize, pbuf);
}

int __MsgFunc_LightStyle(const char* pszName, int iSize, void* pbuf)
{
	return gHUD.MsgFunc_LightStyle(pszName, iSize, pbuf);
}

int __MsgFunc_CreateDecal(const char* pszName, int iSize, void* pbuf)
{
	return gBSPRenderer.MsgCustomDecal(pszName, iSize, pbuf);
}

int __MsgFunc_StudioDecal(const char* pszName, int iSize, void* pbuf)
{
	return gHUD.MsgFunc_StudioDecal(pszName, iSize, pbuf);
}

int __MsgFunc_SkyMark_S(const char* pszName, int iSize, void* pbuf)
{
	return gBSPRenderer.MsgSkyMarker_Sky(pszName, iSize, pbuf);
}

int __MsgFunc_SkyMark_W(const char* pszName, int iSize, void* pbuf)
{
	return gBSPRenderer.MsgSkyMarker_World(pszName, iSize, pbuf);
}

int __MsgFunc_DynLight(const char* pszName, int iSize, void* pbuf)
{
	return gBSPRenderer.MsgDynLight(pszName, iSize, pbuf);
}

int __MsgFunc_FreeEnt(const char* pszName, int iSize, void* pbuf)
{
	return gHUD.MsgFunc_FreeEnt(pszName, iSize, pbuf);
}

int __MsgFunc_Particle(const char* pszName, int iSize, void* pbuf)
{
	return gParticleEngine.MsgCreateSystem(pszName, iSize, pbuf);
}
//RENDERERS END

void CHud::Init(void)
{
	HOOK_MESSAGE(SetFOV);

	cl_righthand = gEngfuncs.pfnGetCvarPointer("cl_righthand");
	//RENDERERS START
	//HOOK_MESSAGE( SetFog );
	HOOK_MESSAGE( LightStyle );
	HOOK_MESSAGE( CreateDecal );
	HOOK_MESSAGE( StudioDecal );
	HOOK_MESSAGE( SkyMark_S );
	HOOK_MESSAGE( SkyMark_W );
	HOOK_MESSAGE( DynLight );
	HOOK_MESSAGE( FreeEnt );
	HOOK_MESSAGE( Particle );
}


void CHud::VidInit(void)
{
	m_scrinfo.iSize = sizeof(m_scrinfo);
	gEngfuncs.pfnGetScreenInfo(&m_scrinfo);
}


CHud:: ~CHud()
{
}

extern void HUD_PrintSpeeds(void);

int CHud::Redraw(float flTime, int intermission)
{
	m_fOldTime = m_flTime;	// save time of previous redraw
	m_flTime = flTime;
	m_flTimeDelta = (double)m_flTime - m_fOldTime;

	HUD_PrintSpeeds();

	return 1;
}

int CHud::MsgFunc_SetFOV(const char *pszName, int iSize, void *pbuf)
{
	BEGIN_READ(pbuf, iSize);

	int newfov = READ_BYTE();
	int def_fov = CVAR_GET_FLOAT("default_fov");

	if (newfov == 0)
		m_iFOV = def_fov;
	else
		m_iFOV = newfov;

	return pmSetFOV(pszName, iSize, pbuf);
}

int CHud::MsgFunc_Fog(const char *pszName, int iSize, void *pbuf)
{
	BEGIN_READ(pbuf, iSize);

	gHUD.m_pFogSettings.active = true;
	gHUD.m_pFogSettings.color.x = (float)READ_BYTE() / 255;
	gHUD.m_pFogSettings.color.y = (float)READ_BYTE() / 255;
	gHUD.m_pFogSettings.color.z = (float)READ_BYTE() / 255;
	gHUD.m_pFogSettings.start = 300;
	gHUD.m_pFogSettings.end = 1500;
	//gHUD.m_pFogSettings.affectsky = (READ_SHORT() == 1) ? false : true;

	return pmFog(pszName, iSize, pbuf);
}

int CHud::MsgFunc_LightStyle(const char* pszName, int iSize, void* pbuf)
{
	BEGIN_READ(pbuf, iSize);

	int m_iStyleNum = READ_BYTE();
	char* szStyle = READ_STRING();
	gBSPRenderer.AddLightStyle(m_iStyleNum, szStyle);

	return 1;
}

int CHud::MsgFunc_StudioDecal(const char* pszName, int iSize, void* pbuf)
{
	BEGIN_READ(pbuf, iSize);

	vec3_t pos, normal;
	pos.x = READ_COORD();
	pos.y = READ_COORD();
	pos.z = READ_COORD();
	normal.x = READ_COORD();
	normal.y = READ_COORD();
	normal.z = READ_COORD();
	int entindex = READ_SHORT();

	if (!entindex)
		return 1;

	cl_entity_t* pEntity = gEngfuncs.GetEntityByIndex(entindex);

	if (!pEntity)
		return 1;

	g_StudioRenderer.StudioDecalForEntity(pos, normal, READ_STRING(), pEntity);

	return 1;
}

int CHud::MsgFunc_FreeEnt(const char* pszName, int iSize, void* pbuf)
{
	BEGIN_READ(pbuf, iSize);

	int iEntIndex = READ_SHORT();

	if (!iEntIndex)
		return 1;


	cl_entity_t* pEntity = gEngfuncs.GetEntityByIndex(iEntIndex);

	if (!pEntity)
		return 1;

	pEntity->efrag = NULL;
	return 1;
}