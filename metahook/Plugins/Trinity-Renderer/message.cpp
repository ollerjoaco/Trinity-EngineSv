#include "metahook.h"
#include "util_vector.h"
#include "hud.h"
#include "message.h"

pfnUserMsgHook pmSetFOV;
pfnUserMsgHook pmFog;

int HookUserMsg(char *szMsgName, pfnUserMsgHook pfn)
{
	if (!strcmp(szMsgName, "SetFOV"))
	{
		pmSetFOV = pfn;
		return gEngfuncs.pfnHookUserMsg(szMsgName, __MsgFunc_SetFOV);
	}
	else if(!strcmp(szMsgName, "Fog"))
	{
		pmFog = pfn;
		return gEngfuncs.pfnHookUserMsg(szMsgName, __MsgFunc_Fog);
	}
	return gEngfuncs.pfnHookUserMsg(szMsgName, pfn);
}