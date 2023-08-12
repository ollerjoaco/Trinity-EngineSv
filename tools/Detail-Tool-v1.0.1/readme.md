This tool is the copyrighted property of the developer, please provide proper credits if you intend to make use of this code.

This is a utility program developed for the Trinity\Abyss rendering engines for Half-Life. It is meant to auto generate a "detailtextures.txt" used by the engine to create detail texture files.

The Trinity\Abyss rendering engines just like the original Steam Half-Life use detail textures to enhance the quality of texture maps, for this to work a text file with the same name as the map with the sufix "_detail" must exist inside the "maps" folder, those files contain information for what detail texture should be used for each texture inside the map as well as scale values, the particular structure of individual detail files is irrelevant for the purpose of this tutorial since we wont be touching them directly, the point is that writing these files manually isn't easy and didn't always provide optimal results. The Trinity\Abyss engine added the ability to auto generate detail files by processing another text file called "detailtextures.txt" that should be located inside the "maps" folder too, this file contains information in the same fashion as the regular detail files except it does not contain any values. The "detailtextures.txt" works by specifying texture names followed by the detail texture name for each line.

![](/screenshot.png)

Example:

"basetrim01 dt_metal1"

After writing your "detailtextures.txt" you have to enter the "te_detail_auto" cvar in the game's console. Keep in mind that "detailtextures.txt" must contain all textures that all your maps combined use since it generates details for all of them at the same time.

But still, writing an entire "detailtextures.txt" with thousands of lines manually is still very frustrating.

And thats when I decided to develop this tool, it will auto generate the detail script by reading the material file that designates step sounds for each texture type.

Usage:

Specify the path to the material script, should be located in "sound\materials.txt";

Specify the path to the textures folder containing all of the textures used by your maps, this is used to compare file names, since the materials file does not contain the texture's full name, the full name must still be found by this program to write it into the detail script. You must extract the textures from your ".wad" files, you can do so using Wally or GCFScape.

After this you must open the "Material manager" and create a list of all texture types your mod is using and what detail texture should be used for each, this is how the program relates itself from texture types and materials, to texture names and detail textures. Default Trinity uses the same texture types as Half-Life, they are:

M Metal;
V Ventilation;
D Dirt;
S Slosh;
T Tile;
G Grate;
W Wood;
P Computer;
Y Glass;
C Concrete (default).

Custom mods may contain more texture types, you can enter them in the manager too, a max of 64 texture types can be handled by the application, you can modify this by editing the code. Only one detail texture can be specified for each texture type as you can obviously notice.

The default texture type will be recognized by the program as the first entry in the list of the material manager, so make sure you enter the "Concrete" texture type first, given that one is your mod's default texture type.

When you're finished hit "Start" and if the application has met it's internal requirements, you will receive a message informing you of the generation success.

This program uses hardcoded array limits, they are very large and will doubtfully be hit, but they can be altered in the source code, if you know how to.

Tool by Hunk Guerrius.