# Oculus Passthrough Drone Tutorial Report

This is a fork of the code written by Dilmer Valecillos, at the original repository [here](https://github.com/dilmerv/OculusPassthroughDrone). Full credit goes to him for writing the code, I have simply added comments to the code to understand what is going, and figured out how to build and run the code myself. I tried making modifications, but errors in the process made it impossible to really test them, so I have reverted for now. Build instructions can be found below:

## Steps to Build
1. Clone this repository to your local machine
2. Import the project to Unity, using Unity Hub (Note: it is fine to use a Unity version > 2020.3.16f1, I used 2021.3.1f1)
3. Select the StandaloneDroneClient scene
4. Connect to Tello drone over Wifi
5. Run the program in Unity, and verify that the drone works
6. Enable developer mode on your Oculus Quest ([instructions here](https://learn.adafruit.com/sideloading-on-oculus-quest/enable-developer-mode))
7. If not already installed, install Android build support for your Unity version
8. Reopen the Unity project, with the Oculus Quest 2 (in dev mode) connected to your machine over USB-C (you may have to allow USB debugging through the Quest)
9. Build and run the program for the Quets 2 ([instructions here](https://developer.oculus.com/documentation/unity/unity-build/))
10. Test that the program runs correctly (or not) :( 





# Original Github ReadME

Oculus Passthrough Drone Demos by using Oculus Quest 2, Unity, Tello, and Brain Computer Interfaces.

This repo aims to teach you how to build you own Drone FPV by using the following technologies:

* Unity 2020.3.16f1 or greater
* Oculus Integration + Oculus Passthrough API ([Tutorial About This Tech](https://github.com/dilmerv/OculusPassthroughDemos))
* Tello DJI Drone which communicates via UDP ([Get the Tello DJI Drone](https://amzn.to/3hdtSHD))

Two main scenes to look at for your own reference:
* StandaloneDroneClient.unity - the uses all components shown from the "Architecture" diagram except that OVR Passthrough Layer reference is not supported.
* OculusDroneClient.unity - all components of "Architecture" diagram are used.

Architecture:

<img src="https://github.com/dilmerv/OculusPassthroughDrone/blob/master/docs/architecture.png" width="500">

Demos:

|Demos|||
|---|---|---|
|Taking Off|Real-time Stats|Device Online|
|<img src="https://github.com/dilmerv/OculusPassthroughDrone/blob/master/docs/images/demo_0.gif" width="250">|<img src="https://github.com/dilmerv/OculusPassthroughDrone/blob/master/docs/images/demo_1.gif" width="250">|<img src="https://github.com/dilmerv/OculusPassthroughDrone/blob/master/docs/images/demo_2.gif" width="250">|
