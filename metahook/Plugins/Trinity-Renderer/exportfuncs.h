extern cl_enginefunc_t gEngfuncs;
extern efx_api_s gEfxAPI;

extern int g_iFlashLight;

int Initialize(struct cl_enginefuncs_s *pEnginefuncs, int iVersion);
void HUD_Init(void);
void HUD_Shutdown(void);
int HUD_VidInit(void);
int HUD_Redraw(float time, int intermission);
void HUD_DrawTransparentTriangles(void);
void HUD_DrawNormalTriangles(void);
void HUD_CreateEntities(void);
int HUD_AddEntity(int type, struct cl_entity_s *ent, const char *modelname);
void HUD_ProcessPlayerState(struct entity_state_s *dst, const struct entity_state_s *src);
void HUD_TempEntUpdate(double frametime, double client_time, double cl_gravity, struct tempent_s **ppTempEntFree, struct tempent_s **ppTempEntActive, int(*Callback_AddVisibleEntity)(struct cl_entity_s *pEntity), void(*Callback_TempEntPlaySound)(struct tempent_s *pTemp, float damp));
void HUD_PostRunCmd(struct local_state_s *from, struct local_state_s *to, struct usercmd_s *cmd, int runfuncs, double time, unsigned int random_seed);
