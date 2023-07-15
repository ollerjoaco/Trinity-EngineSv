typedef struct
{
	void(*R_DecalNode)(mnode_t *node, float flScale);
	void(*R_DecalCreate)(msurface_t *psurface, int textureIndexfloat, float scale, float x, float y);
	texture_s*(*Draw_DecalTexture)(int index);
}
ref_funcs_t;

extern ref_funcs_t gRefFuncs;