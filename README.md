# Trinity Engine

This is a [Trinity Engine](https://github.com/TheOverfloater/trinity-engine) porting for Counter Strike 1.6

Client-Side part of the mod it´s introduced as a [metahook](https://github.com/Nagist/metahook) plugin.

Server-Side part of the mod it´s done with a modifidied [reGame](https://github.com/s1lentq/ReGameDLL_CS) dll.

![](/img/1.png)

## Installation

1. Download the binaries from [GitHub Release](https://github.com/ollerjoaco/MH_TrinityRender/releases), then unzip it.

2. Copy and paste the content from the 'resources' folder into your game mod folder (cstrike).

3. Paste the TrinityRenderer.dll file into your cstrike/metahook/plugins folder

4. Replace your actual dlls/mp.dll file with this new one.

5. Open your game from the metahook.exe file!

## Features

* Completely rewritten world and model renderers.
* A powerful and fully customizable particle engine.
* Real-time dynamic per pixel lighting for world.
* Real-time dynamic per vertex lighting for models.
* External .tga and .dds high resolution texture loader (4k).
* Client side entity manager that breaks the 512 entity limit the engine originally has.
* External detail data to load external geometry into the map.
* High resolution as well as 3D skyboxes.
* Shader based water.
* Real-time mirrors.
* New decal system.
* Per pixel fog (radial fog).

## Commands

* te_exportworld
* te_detail_auto
* te_dump

## Configuration (cvars)
<details>
<summary>Click to expand</summary>

| CVar                               | Default | Disable | Enable          | Description                                    |
| :--------------------------------- | :-----: | :-: | :----------: | :--------------------------------------------- |
| te_client_entities                      | 1       | 0   | 1            | Display of new client entities. |
| te_detail                 | 1       | 0   | 1            | Enables/Disables detail texturing. |
| te_dynlights                         | 1     | 0 | 1            | Enables/Disables dynamic lights in the world ( flashlight, env_spotlight ). |
| te_mirrors                       | 1   | 0   | 1     | Enables/Disables the use of mirrors in the game. |
| te_mirror_player                  | 1       | 0   | 1            | Enables/Disables players shown in mirrors. |
| te_model_decals                       | 1       | 0   | 1            | Enables/Disables model decals. |
| te_model_shaders              | 1       | 0   | 1            | Enables/Disables model shaders. |
| te_models            | 1       | 0   | 1            | Enables/Disables the rendering of models in the game. |
| te_models_debug_bbox                        | 0       | 0   | 1            | Show the bbox of models in the game. |
| te_models_debug_light               | 0      | 0   | 1            | Turns models into black to white color depending on the light that affects it |
| te_particles             | 1       | 0   | 1            | Enables/Disables the rendering of new particles system in the game |
| te_particles_debug           | 0       | 0   | 1            | Shows created, freed and active particles in the console in real time. Also the created, freed and active particle systems. |
| te_radialfog                   | 0       | 0   | 1            | Enables/Disables radial fog setting for rendering fog in the game. |
| te_shadows               | 1       | 0   | 1            | Enables/Disables models and brushes shadows in the game. |
| te_shadows_filter                  | 1       | 0   | 1            | Enables/Disables a shadows filter that reduces sharpness of shadows in the game. |
| te_speeds                   | 0       | 0   | 1            | Shows wpolys, epolys, studio polys, particles and fps count in the console in real time. |
| te_water                      | 1       | 0   | 1            | Enables/Disables shader based water rendering in the game. |
| te_water_debug                      | 0       | 0   | 1            | Shows water refract and reflect wpolys, epolys and studio polys drawn for water shader. |
| te_wireframe                        | 0       | 0   | 1            | Shows the wireframe structure of all the brushes in the world. |
| te_world                       | 0       | 0   | 1            | Enables/Disables the rendering of all the world brushes but not the models or entitys. |
| te_world_shaders                    | 1       | 0   | 1            | Enables/Disables world shaders in the game. |

</details>

## Compatibility

<b>Warning!</b> As Trinity Engine uses metahook for the client-side part of the code, it´s not binary compatible with gsClient since it has a modified client.dll . Also some plugins using StudioModelRenderer may not work such as BulletPhysics. This is a Renderer so it wont be compatible with other renderers such as Paranoia or MetaRenderer, choose the one you prefer the most.

RegameDLL does not allows [amxmodx](https://github.com/alliedmodders/amxmodx) versions older than 1.8.3, if you plan to use it please consider upgrading your version, preferibly to the latest one.

I highly recommend you to use the maintained version of the old metahook engine, [MetahookSv](https://github.com/hzqst/MetaHookSv). This is compatible with the Steam version of the game and will work fine with Trinity.
Notice that MetahookSV has problems running on engine build versions older than 8684. So if you are non-Steam check your version of the engine by typing 'version' in your console.
