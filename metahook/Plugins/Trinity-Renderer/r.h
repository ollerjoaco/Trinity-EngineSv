void R_Init();

void R_BloodSprite(float* org, int colorindex, int modelIndex, int modelIndex2, float size);
void R_BloodStream(float * org, float * dir, int pcolor, int speed);
//void R_Explosion(float *pos, int model, float scale, float framerate, int flags);
void R_DecalShoot(int textureIndex, int entity, int modelIndex, float * position, int flags);
void R_DecalRemoveAll(int textureIndex);

int Draw_DecalIndex(int id);
void R_DecalNode(mnode_t *node, float flScale);
void R_DecalCreate(msurface_t *psurface, int textureIndex, float scale, float x, float y);
texture_t* Draw_DecalTexture(int index);