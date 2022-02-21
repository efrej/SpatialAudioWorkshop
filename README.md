# SpatialAudioWorkshop

Downloading and installing demo scene:

- Download demo-scene file from GitHub to your computer: https://github.com/efrej/SpatialAudioWorkshop/ 
- Open the Unity Hub and go to: projects → add
- Select the file path to the root-folder which you downloaded from GitHub
- Open the project you just added from the Unity Hub. Unity will generate some general project-files now and it may take a few minutes. 


Steam Audio Steps:

1. Install Steam Audio in Unity Project
- Download Steam Audio Unity package from: https://valvesoftware.github.io/steam-audio/ 
- Add the package to Unity. Assets → Import Package → Custom Package → Select Steam Audio Package you just downloaded
- Update project settings to use Steam Audio. Edit > Project settings > Audio: select Steam Audio for the Spatializer Plugin and Ambisonics Decoder Plugin
- For each Audio Source, enable “Spatialize” in the Audio Source Component

Play the scene and listen, each audio source should be spatialized using Steam Audio using HRTFs decoding. You will be able to hear when sounds are in front, back up, and down. 

2. Add directivity 
- Add a steam audio source to the component that you want to spatialize (Component > Steam Audio > Steam Audio Source). 
- Enable directivity. Choose simulation defined and play around with the dipole weight and power. The weight enables you to blend between monopole or dipole and the power defines how focused the directivity is. 

Play the scene and listen, you should now hear a difference when you move around an object.

3. Add Occlusion
- If not added already, add a steam audio source to the component that you want to spatialize (Component > Steam Audio > Steam Audio Source). 
- Enable Occlusion in Steam Audio Source Component and choose simulation defined
- Choose occlusion type
Raycast will use a single ray from the listener to the emitter, when this is occluded the source is considered occluded. This works alright for occlusion of rooms, but in order to get realistic occlusion of objects or person in the room choose volumetric.
Volumetric uses multiple rays based on the occlusion radius. When the radius is larger (larger sound sources), an object must be larger in order to fully occlude a sound source. Occlusion samples determine the amount of rays that are used. More rays means a smoother transition between no occlusion and full occlusion.
- Transmission (optional). If checked, a filter based on the transmission of sound through occluding scene geometry will be applied to the Audio Source. For this, you can choose frequency-dependent or independent filtering.

- In order to apply the occlusion to an object you need to “tag acoustic geometry”: 
- This can be done by adding a Steam Audio Geometry component to the object or parent of the objects (in this case click: “export all children”). Objects that you want to tag need a mesh filter component (these are automatically added when adding a standard 3D object in Unity). 
- Once every object that you want to add occlusion to is tagged, click Steam Audio from the menu, and click “Export Active Scene”.

Play the scene and listen, sounds should be attenuated when an object is blocking the sound source.

4. Add reflections
Adding reflection is similar to adding occlusion. First, select “reflections” in the Steam Audio Source component. You can spatialize the reverb by enabling HRTFs, with the cost of (slightly) increased CPU load. The amount of reverb can be changed using the reflection mix level slider, increasing this will increase the reflection sound level.
- reflections can be added in different ways, for now select real-time. However, it is also possible to “bake” effects. 
- If not done yet, you need to tag room geometry, y adding the Steam Audio Geometry to the parent of the object (scene geometry) and click “export all children” and click “Export Active Scene” in the Steam Audio menu.

Play the scene and listen, you should now be able to hear indirect sounds reflected on gameobjects in the scene.
