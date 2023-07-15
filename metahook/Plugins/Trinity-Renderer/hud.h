#ifndef _HUD_H
#define _HUD_H

extern struct cvar_s *cl_righthand;
extern struct cvar_s *cl_lw;

//RENDERERS START
#include "frustum.h"

struct fog_settings_t
{
	vec3_t color;
	int start;
	int end;
	
	bool affectsky;
	bool active;
};
//RENDERERS END


class CHud
{
public:
	~CHud();

public:
	float m_flTime;	   // the current client time
	float m_fOldTime;  // the time at which the HUD was last redrawn
	double m_flTimeDelta; // the difference between flTime and fOldTime

	void Init( void );
	void VidInit( void );
	void Think(void);
	int Redraw( float flTime, int intermission );
	//int UpdateClientData( client_data_t *cdata, float time );

	// Screen information
	SCREENINFO	m_scrinfo;

	int m_iFOV;

	//RENDERERS START
	fog_settings_t m_pSkyFogSettings;
	fog_settings_t m_pFogSettings;
	FrustumCheck viewFrustum;

	int _cdecl MsgFunc_SetFOV(const char *pszName, int iSize, void *pbuf);
	int _cdecl MsgFunc_Fog(const char *pszName, int iSize, void *pbuf);

	//int  _cdecl MsgFunc_SetFog( const char *pszName, int iSize, void *pbuf );
	int  _cdecl MsgFunc_LightStyle( const char *pszName, int iSize, void *pbuf );
	int  _cdecl MsgFunc_StudioDecal( const char *pszName, int iSize, void *pbuf );
	int  _cdecl MsgFunc_FreeEnt( const char *pszName, int iSize, void *pbuf );

	int  _cdecl MsgFunc_CreateDecal( const char *pszName, int iSize, void *pbuf );
	int  _cdecl MsgFunc_SkyMark_S( const char *pszName, int iSize, void *pbuf );
	int  _cdecl MsgFunc_SkyMark_W( const char *pszName, int iSize, void *pbuf );
	int  _cdecl MsgFunc_DynLight( const char *pszName, int iSize, void *pbuf );
	int  _cdecl MsgFunc_CreateSystem( const char *pszName, int iSize, void *pbuf );
	//RENDERERS END
};

int __MsgFunc_SetFOV(const char *pszName, int iSize, void *pbuf);
int __MsgFunc_Fog(const char *pszName, int iSize, void *pbuf);

extern CHud gHUD;

#endif