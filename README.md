# APS490
Will store APS490 project files here
Christian's first commit (Jan 13 2015)
Christian's last commit (Apr 9 2015)

Project was in collaberation with Defence Research and Development Canada. 

Team DRDC2: Tingcheng Cui, Christian Sangle, Chong Wang.

Building the Project with Unity

1) Download and install Unity 5 Personal Edition (http://unity3d.com/get-unity).

2) Start Unity and select the option "Open Other"

3) Navigate to the root directory of the project (Should see Assets and Project Settings) and select the option "Select folder".

4) Unity will begin importing the project into the environment (~10min on first load).

5) In the Unity Environment go to File> "Build Settings".

6) Ensure that there are 8 "scenes" selected in the following order: 
    0. menu
    1. MainGame
    2. Attention Control
    3. Memory
    4. SelfTalk
    5. FinishScene
    6. Store
    7. Achievements.
    
    6a) If any scenes are missing, navigate to the "Project" window in the Unity Environment find the folder "Scenes" and
    click-and-drag. The scene into the "Build Settings" window.
  
    6b) If the scenes are not in the correct order click-and-drag the scene and position it in its correct position in the
    list.
 
 7) In the Build Settings window select the platform that it needs to be built on.
 
    7a) IF building for iOS select "Player Settings" in the "Build Settings" window, and locate the "Insepector" window in
    the Unity Environment.
    
    7b) Ensure that "target device" is set to "iPad+iPhone". SDk version is set to "Device SDK" and Target iOS version is
    8.1. 
    
 8) Navigate back to the "Build Settings" window and select "Build". Create a new folder where yopur build will be saved, 
    and save it in the new folder.
    WARNING: The first build, this will take between 1-3 hours for it to build. All builds after, should take ~5-10min.
     
     8a) (If building for iOS on a Mac) Navigate to location of the iOS build in Finder, and there will be an Xcode project 
     that must be run. Plug in an iOS device and Build + run the project in Xcode. App should be installed on the device.
