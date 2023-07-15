#include <metahook.h>
#include "util_vector.h"
#include "view.h"
#include "hud.h"
#include "exportfuncs.h"

//RENDERERS START
#include "bsprenderer.h"
#include "propmanager.h"
#include "mirrormanager.h"
#include "watershader.h"
//RENDERERS END

void V_CalcRefdef(struct ref_params_s *pparams)
{
	gExportfuncs.V_CalcRefdef(pparams);
	
	// RENDERER START
	//2012-02-25
	R_CalcRefDef(pparams);
	// RENDERER END
}
