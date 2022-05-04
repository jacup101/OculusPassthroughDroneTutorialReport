# Oculus Passthrough Drone Tutorial Report

This is a fork of the code written by Dilmer Valecillos, at the original repository [here](https://github.com/dilmerv/OculusPassthroughDrone). Full credit goes to him for writing the code, I have simply made a couple of modifications and figured out how to build and run the code myself. Build instructions can be found below:





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
