This tool is the copyrighted property of the developer, please provide proper credits if you intend to make use of this code.

This is a utility program developed for the Trinity\Abyss rendering engines for Half-Life. It is meant to auto generate large flag script files with the press of a button.

The Trinity\Abyss rendering engines have an external texture loader feature capable of loading ultra high resolution textures into a GoldSrc powered game\mod, the loader works by replacing a WAD texture or MDL texture by an external high resolution one of the same name. For this to function a folder named "world" or "models" must exist inside the "gfx\textures" folder, that will contain all the high resolution images of either .TGA or .DDS format with the name of the wad texture they are meant to replace. But for the textures to be loaded in the engine a texture script is required under the name "texture_flags.txt" in the "gfx\textures" folder, in there each line will contain the folder name the high resolution texture is curently in, followed by the name of the texture, followed by the flag macro that will specify how this texture is to be treated.

![](/screenshot.png)

Example:

"world -0out_rk3 alternate"

It works just the same for model textures, first the folder name, then the texture name, then the script flag.

While the texture loader as proved to be a powerful visual enhancer it isn't practical to use it's capabilities on a large scale, because all textures must be written manually in the script file, now imagine the curse of having to flag nearly a thousand external textures manually, into that file.

And thats when I decided to develop this tool, it will memorize all the textures from their folder and auto generate a flag script.

Usage:

Specify the path to the textures folder;
Mark which formats are to be parsed into the program (files of other formats will be ignored);
Select what type of textures do you want to generate a file for: World, Models, or both;
Hit "Start" and if the application has met it's internal requirements, you will receive a message informing you of the generation success.

This tool will only mark textures of the flag type "alternate" other flag types exist but are completely contextual and therefore not suitable for mass generation, you can simply copy paste all the marks of different flag types and paste them on the autogenerated file, but don't forget to backup before you auto generate it again, it will warn you first if an existing one was detected anyway.

The tool has high internal array limits for each entry type, if you exceed these limits the application will crash, you will need to increase the internal limits manually in the code for this particular situation, although I doubt the limit will be hit.