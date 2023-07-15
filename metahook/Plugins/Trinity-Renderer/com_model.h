/*
*
*   This program is free software; you can redistribute it and/or modify it
*   under the terms of the GNU General Public License as published by the
*   Free Software Foundation; either version 2 of the License, or (at
*   your option) any later version.
*
*   This program is distributed in the hope that it will be useful, but
*   WITHOUT ANY WARRANTY; without even the implied warranty of
*   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
*   General Public License for more details.
*
*   You should have received a copy of the GNU General Public License
*   along with this program; if not, write to the Free Software Foundation,
*   Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
*
*   In addition, as a special exception, the author gives permission to
*   link the code of this program with the Half-Life Game Engine ("HL
*   Engine") and Modified Game Libraries ("MODs") developed by Valve,
*   L.L.C ("Valve").  You must obey the GNU General Public License in all
*   respects for all of the code used other than the HL Engine and MODs
*   from Valve.  If you modify this file, you may extend this exception
*   to your version of the file, but you are not obligated to do so.  If
*   you do not wish to do so, delete this exception statement from your
*   version.
*
*/

#ifndef COM_MODEL_H
#define COM_MODEL_H
#ifdef _WIN32
#pragma once
#endif

#define STUDIO_RENDER 1
#define STUDIO_EVENTS 2

#define MAX_MODEL_NAME      64
#define MAX_MAP_HULLS       4
#define MIPLEVELS           4
#define NUM_AMBIENTS        4       // automatic ambient sounds
#define MAXLIGHTMAPS        4
#define PLANE_ANYZ          5

#define ALIAS_Z_CLIP_PLANE  5

// flags in finalvert_t.flags
#define ALIAS_LEFT_CLIP             0x0001
#define ALIAS_TOP_CLIP              0x0002
#define ALIAS_RIGHT_CLIP            0x0004
#define ALIAS_BOTTOM_CLIP           0x0008
#define ALIAS_Z_CLIP                0x0010
#define ALIAS_ONSEAM                0x0020
#define ALIAS_XY_CLIP_MASK          0x000F

#define ZISCALE ((float)0x8000)

#define CACHE_SIZE  32      // used to align key data structures

typedef enum modtype_e
{
    mod_brush,
    mod_sprite,
    mod_alias,
    mod_studio,
} modtype_t;

// must match definition in modelgen.h
#ifndef SYNCTYPE_T
#define SYNCTYPE_T

typedef enum
{
    ST_SYNC=0,
    ST_RAND
} synctype_t;

#endif

/*
==============================================================================

SPRITE MODELS

==============================================================================
*/


typedef enum { SPR_SINGLE=0, SPR_GROUP } spriteframetype_t;

#define SPR_VP_PARALLEL_UPRIGHT			0
#define SPR_FACING_UPRIGHT				1
#define SPR_VP_PARALLEL					2
#define SPR_ORIENTED					3
#define SPR_VP_PARALLEL_ORIENTED		4

#define SPR_NORMAL						0
#define SPR_ADDITIVE					1
#define SPR_INDEXALPHA					2
#define SPR_ALPHTEST					3

typedef struct mspriteframe_s
{
     int          width;
     int          height;
     float     up, down, left, right;
     int          gl_texturenum;
} mspriteframe_t;

typedef struct
{
     int                    numframes;
     float               *intervals;
     mspriteframe_t     *frames[1];
} mspritegroup_t;

typedef struct
{
     spriteframetype_t     type;
     mspriteframe_t          *frameptr;
} mspriteframedesc_t;

typedef struct
{
     short                    type;
     short                    texFormat;
     int                         maxwidth;
     int                         maxheight;
     int                         numframes;
     byte                    unknown_data[12];
     mspriteframedesc_t     frames[1];
} msprite_t;

typedef struct
{
    float       mins[3], maxs[3];
    float       origin[3];
    int         headnode[MAX_MAP_HULLS];
    int         visleafs;       // not including the solid leaf 0
    int         firstface, numfaces;
} dmodel_t;

// plane_t structure
typedef struct mplane_s
{
    vec3_t  normal;         // surface normal
    float   dist;           // closest appoach to origin
    byte    type;           // for texture axis selection and fast side tests
    byte    signbits;       // signx + signy<<1 + signz<<1
    byte    pad[2];
} mplane_t;

typedef struct
{
    vec3_t      position;
} mvertex_t;

typedef struct
{
    unsigned short  v[2];
    unsigned int    cachededgeoffset;
} medge_t;


typedef struct texture_s
{
    char        name[16];
    unsigned    width;
    unsigned    height;
    int         gl_texturenum;
    struct msurface_s   *texturechain;  // for gl_texsort drawing
    int         anim_total;             // total tenths in sequence ( 0 = no)
    int         anim_min, anim_max;     // time for this frame min <=time< max
    struct texture_s *anim_next;        // in the animation sequence
    struct texture_s *alternate_anims;  // bmodels in frame 1 use these
    unsigned    offsets[MIPLEVELS];     // four mip maps stored
    unsigned    paloffset;

} texture_t;


typedef struct
{
    float       vecs[2][4];     // [s/t] unit vectors in world space.
                                // [i][3] is the s/t offset relative to the origin.
                                // s or t = dot(3Dpoint,vecs[i])+vecs[i][3]
    float       mipadjust;      // ?? mipmap limits for very small surfaces
    texture_t   *texture;
    int         flags;          // sky or slime, no lightmap or 256 subdivision
} mtexinfo_t;

#define VERTEXSIZE  7

typedef struct glpoly_s
{
	struct  glpoly_s    *next;
	struct  glpoly_s    *chain;
	int     numverts;
	int     flags;          	// for SURF_UNDERWATER
	float verts[4][VERTEXSIZE];   // variable sized (xyz s1t1 s2t2)
} glpoly_t;


typedef struct mnode_s
{
    // common with leaf
    int             contents;       // 0, to differentiate from leafs
    int             visframe;       // node needs to be traversed if current

    float           minmaxs[6];     // for bounding box culling

    struct mnode_s  *parent;

    // node specific
    mplane_t        *plane;
    struct mnode_s  *children[2];

    unsigned short      firstsurface;
    unsigned short      numsurfaces;
} mnode_t;


typedef struct msurface_s   msurface_t;
typedef struct decal_s      decal_t;

// JAY: Compress this as much as possible
struct decal_s
{
    decal_t     *pnext;         // linked list for each surface
    msurface_t  *psurface;      // Surface id for persistence / unlinking
    short       dx;             // Offsets into surface texture (in texture coordinates, so we don't need floats)
    short       dy;
    short       texture;        // Decal texture
    byte        scale;          // Pixel scale
    byte        flags;          // Decal flags

    short       entityIndex;    // Entity this is attached to
};

typedef struct mleaf_s
{
    // common with node
    int         contents;       // wil be a negative contents number
    int         visframe;       // node needs to be traversed if current

    float       minmaxs[6];     // for bounding box culling

    struct mnode_s  *parent;

    // leaf specific
    byte        *compressed_vis;
    struct efrag_s  *efrags;

    msurface_t  **firstmarksurface;
    int         nummarksurfaces;
    int         key;            // BSP sequence number for leaf's contents
    byte        ambient_sound_level[NUM_AMBIENTS];
} mleaf_t;

typedef struct msurface_s
{
    int         visframe;       // should be drawn when node is crossed

    mplane_t    *plane;
    int         flags;

    int         firstedge;  // look up in model->surfedges[], negative numbers
    int         numedges;   // are backwards edges

    short       texturemins[2];
    short       extents[2];

    int         light_s, light_t;           // gl lightmap coordinates

    glpoly_t    *polys;                     // multiple if warped
    struct msurface_s   *texturechain;

    mtexinfo_t  *texinfo;

    // lighting info
    int         dlightframe;
    int         dlightbits;

    int         lightmaptexturenum;
    byte        styles[MAXLIGHTMAPS];
    int         cached_light[MAXLIGHTMAPS]; // values currently used in lightmap
    qboolean    cached_dlight;              // true if dynamic light in cache

    color24     *samples;                   // note: this is the actual lightmap data for this surface
    decal_t     *pdecals;

} msurface_t;

typedef struct
{
    int         planenum;
    short       children[2];    // negative numbers are contents
} dclipnode_t;

typedef struct hull_s
{
    dclipnode_t *clipnodes;
    mplane_t    *planes;
    int         firstclipnode;
    int         lastclipnode;
    vec3_t      clip_mins;
    vec3_t      clip_maxs;
} hull_t;

#if !defined( CACHE_USER ) && !defined( QUAKEDEF_H )
#define CACHE_USER
typedef struct cache_user_s
{
    void    *data;
} cache_user_t;
#endif

typedef struct model_s
{
    char        name[ MAX_MODEL_NAME ];     // +0x000
    qboolean    needload;                   // +0x040   bmodels and sprites don't cache normally

    modtype_t   type;                       // +0x044
    int         numframes;                  // +0x048
    synctype_t  synctype;                   // +0x04C

    int         flags;                      // +0x050

    // volume occupied by the model
    vec3_t      mins, maxs;                 // +0x054, +060
    float       radius;                     // +0x06C

    // brush model
    int         firstmodelsurface, nummodelsurfaces;    // +0x070, +0x074

    int         numsubmodels;               // +0x078
    dmodel_t    *submodels;                 // +0x07C

    int         numplanes;                  // +0x080
    mplane_t    *planes;                    // +0x084

    int                 numleafs;           // +0x088      number of visible leafs, not counting 0
    struct mleaf_s      *leafs;             // +0x08C

    int         numvertexes;                // +0x090
    mvertex_t   *vertexes;                  // +0x094

    int         numedges;                   // +0x098
    medge_t     *edges;                     // +0x09C

    int         numnodes;                   // +0x0A0
    mnode_t     *nodes;                     // +0x0A4

    int         numtexinfo;                 // +0x0A8
    mtexinfo_t  *texinfo;                   // +0x0AC

    int         numsurfaces;                // +0x0B0
    msurface_t  *surfaces;                  // +0x0B4

    int         numsurfedges;
    int         *surfedges;

    int         numclipnodes;
    dclipnode_t *clipnodes;

    int         nummarksurfaces;
    msurface_t  **marksurfaces;

    hull_t      hulls[MAX_MAP_HULLS];

    int         numtextures;
    texture_t   **textures;

    byte        *visdata;

    color24     *lightdata;

    char        *entities;

    // additional model data
    cache_user_t    cache;      // only access through Mod_Extradata

} model_t;

typedef vec_t vec4_t[4];

typedef struct alight_s
{
    int         ambientlight;   // clip at 128
    int         shadelight;     // clip at 192 - ambientlight
    vec3_t      color;
    float       *plightvec;
} alight_t;

typedef struct auxvert_s
{
    float   fv[3];      // viewspace x, y
} auxvert_t;

//
// ------------------  Player Model Animation Info ----------------
//
#include "custom.h"

#define MAX_INFO_STRING         256
#define MAX_SCOREBOARDNAME      32
typedef struct player_info_s
{
    // User id on server
    int     userid;

    // User info string
    char    userinfo[ MAX_INFO_STRING ];

    // Name
    char    name[ MAX_SCOREBOARDNAME ];

    // Spectator or not, unused
    int     spectator;
    int     ping;
    int     packet_loss;

    // skin information
    char    model[MAX_QPATH];
    int     topcolor;
    int     bottomcolor;

    // last frame rendered
    int     renderframe;

    // Gait frame estimation
    int     gaitsequence;
    float   gaitframe;
    float   gaityaw;
    vec3_t  prevgaitorigin;

    customization_t customdata;

} player_info_t;

extern mvertex_t *globalVertexTable;

#endif // COM_MODEL_H