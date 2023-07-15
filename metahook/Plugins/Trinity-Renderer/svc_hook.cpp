#include <metahook.h>
#include "plugins.h"
#include "svc_hook.h"
#include "svc_message.h"
#include "sizebuf.h"

#define CL_DUMPMESSAGELOAD_F_SIG "\x55\x8B\xEC\x83\xE4\xF8\x51\x53\x56\x57\x68"
#define CL_DUMPMESSAGELOAD_F_SIG_NEW "\x55\x8B\xEC\x51\x53\x56\x57\x68\x2A\x2A\x2A\x2A\x33\xDB\xE8\x2A\x2A\x2A\x2A\x83\xC4\x04\x33\xF6\xBF\x2A\x2A\x2A\x2A\x8B\x04\xB5\x2A\x2A\x2A\x2A"
int SVC_LASTMSG = 50;

typedef struct svc_func_s
{
	unsigned char opcode;
	char *pszname;
	pfnSVC_Parse pfnParse;
}
svc_func_t;

svc_func_t *cl_parsefuncs = NULL;
sizebuf_t *net_message = NULL;
int *msg_readcount = NULL;

void SVC_InstallHooks(void);

void SVC_Init(void)
{
	DWORD addr_svc_bad = (DWORD)g_pMetaHookAPI->SearchPattern((void *)g_dwEngineBase, g_dwEngineSize, "svc_bad", sizeof("svc_bad") - 1);
	DWORD addr_svc_nop = (DWORD)g_pMetaHookAPI->SearchPattern((void *)addr_svc_bad, 0x100, "svc_nop", sizeof("svc_nop") - 1);
	
	int svc[6] = { 0, addr_svc_bad, 0, 1, addr_svc_nop, 0 };
	char *svc_sig = (char *)svc;

	DWORD addr_cl_parsefuncs = (DWORD)g_pMetaHookAPI->SearchPattern((void *)g_dwEngineBase, g_dwEngineSize, svc_sig, sizeof(svc));
	
	if (addr_cl_parsefuncs)
	{	
		cl_parsefuncs = (svc_func_t *)addr_cl_parsefuncs;

		while (SVC_LASTMSG)
		{
			if (cl_parsefuncs[SVC_LASTMSG].opcode == 0xFF)
			{
				SVC_LASTMSG -= 1;
				break;
			}

			SVC_LASTMSG++;
		}
	}

	DWORD addr_cl_parse_director = (DWORD)cl_parsefuncs[51].pfnParse;
	if (addr_cl_parse_director)
	{
		msg_readcount = (int *)(*(DWORD *)(addr_cl_parse_director + 8));
		net_message = (sizebuf_t *)(*(DWORD *)(addr_cl_parse_director + 15) - 0x8);
	}

	SVC_InstallHooks();
}

pfnSVC_Parse SVC_HookFunc(int opcode, pfnSVC_Parse pfnParse)
{
	pfnSVC_Parse pfnResult = cl_parsefuncs[opcode].pfnParse;

	cl_parsefuncs[opcode].pfnParse = pfnParse;
	return pfnResult;
}

void *SVC_GetBuffer(void)
{
	return net_message->data + *msg_readcount;
}

int SVC_GetBufferSize(void)
{
	return net_message->cursize - *msg_readcount;
}

void SVC_Skip(int size)
{
	*msg_readcount += size;
}