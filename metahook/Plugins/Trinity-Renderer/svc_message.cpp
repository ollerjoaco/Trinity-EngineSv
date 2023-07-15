#include <metahook.h>
#include "util_vector.h"
#include "plugins.h"
#include "svc_hook.h"
#include "svc_message.h"
#include "sizebuf.h"
#include "parsemsg.h"
#include "decal.h"

#include "bsprenderer.h"
#include "particle_engine.h"

pfnSVC_Parse pfnCL_Parse_LightStyle;
pfnSVC_Parse pfnCL_Parse_TempEntity;

void SVC_InstallHooks(void)
{
	pfnCL_Parse_LightStyle = SVC_HookFunc(svc_lightstyle, CL_Parse_LightStyle);
	pfnCL_Parse_TempEntity = SVC_HookFunc(svc_tempentity, CL_Parse_TempEntity);
}

void CL_Parse_LightStyle(void)
{
	BEGIN_READ(SVC_GetBuffer(), SVC_GetBufferSize());

	int i = READ_BYTE();
	char map[64];
	strcpy(map, READ_STRING());

	
	// use some bad way....
	gBSPRenderer.AddLightStyle(i, map);

	if (i == 0 && map[1] == 0)
	{		
		gBSPRenderer.m_bFullBright = (map[0] > 'z' || map[0] < 'a');
		
		//gBSPRenderer.AnimateLight();
		gBSPRenderer.m_flLightScale = float(map[0] - 'm') / 13 + 1;
		//gBSPRenderer.UpdateLightmaps();	//crash maps with water
	}
	/*else
	{
		gBSPRenderer.AddLightStyle(i, map);
	}
	*/
	

	pfnCL_Parse_LightStyle();
}

void CL_Parse_TempEntity()
{
	BEGIN_READ(SVC_GetBuffer(), SVC_GetBufferSize());


	int c = READ_BYTE();
	int size = 1;

	switch (c)
	{
	case TE_EXPLOSION:
	{
		float pos[3];
		int modelIndex;
		pos[0] = READ_COORD();
		pos[1] = READ_COORD();
		pos[2] = READ_COORD();
		modelIndex = READ_SHORT();

		model_s *model = IEngineStudio.GetModelByIndex(modelIndex);

		if (!strcmp(model->name, "sprites/fexplo.spr"))
		{
			gEngfuncs.pEfxAPI->R_Explosion(pos, 0, 0, 0, TE_EXPLFLAG_NONE);

			cl_dlight_t *dl;

			dl = gBSPRenderer.CL_AllocDLight(0);
			dl->origin = pos;
			dl->radius = 200;
			dl->color.x = 250;
			dl->color.y = 250;
			dl->color.z = 150;
			dl->die = gEngfuncs.GetClientTime() + 0.01f;
			dl->decay = 80;

			dl = gBSPRenderer.CL_AllocDLight(0);
			dl->origin = pos;
			dl->radius = 150;
			dl->color.x = 255;
			dl->color.y = 190;
			dl->color.z = 40;
			dl->die = gEngfuncs.GetClientTime() + 1.0f;
			dl->decay = 200;
			
			SVC_Skip(1 + 2 + 2 + 2 + 2 + 1 + 1 + 1);
			
			return;
		}

		if (!strcmp(model->name, "sprites/eexplo.spr"))
		{
			SVC_Skip(1 + 2 + 2 + 2 + 2 + 1 + 1 + 1);
			return;
		}

		break;
	}
	/*case TE_DECAL:
	case TE_WORLDDECAL:
	//case TE_WORLDDECALHIGH:
	//case TE_DECALHIGH:
	{
		float pos[3];		

		pos[0] = READ_COORD();
		pos[1] = READ_COORD();
		pos[2] = READ_COORD();

		int entnumber = 0;
		int flags = 0;
		
		int decalTextureIndex = READ_BYTE();

		size += 2 + 2 + 2 + 1;

		if (c == TE_DECAL || c == TE_DECALHIGH)
		{
			entnumber = READ_SHORT();
			size += 2;
		}

		if (c == TE_DECALHIGH || c == TE_WORLDDECALHIGH)
			decalTextureIndex += 256;

		//efx.R_DecalShoot(efx.Draw_DecalIndex(decalTextureIndex), entnumber, modelIndex, pos, flags);

		if (decalTextureIndex == DECAL_SCORCH1 || decalTextureIndex == DECAL_SCORCH2)
		{
			// need to find normal
			gBSPRenderer.CreateDecal(pos, Vector(0, 0, 1), "scorch", FALSE);

			SVC_Skip(size);
			return;
		}
		
		break;
	}*/
	}

	pfnCL_Parse_TempEntity();
	
}