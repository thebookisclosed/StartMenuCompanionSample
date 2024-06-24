# Start Menu Companion Sample

This repository contains a small WinUI 3 desktop app which registers itself as a Start Menu Companion provider.
A sample Adaptive Card JSON is included to make getting started simpler.

## Prerequisites
- [x] Any current Windows 11 Insider build as of 6/23/2024
- [x] Visual Studio 2022 and its "Windows application development" workload
- [x] Feature ID 48697323 enabled

## How do I try this?
1) Clone, build, and deploy the solution
2) Make sure the companion is enabled in the Settings app
3) Open the deployed app and configure the Adaptive Card JSON content to your liking & hit Save
4) If the companion isn't visible, simply restart the shell by ending `sihost.exe` and `explorer.exe`

## How can I change how the app identifies?
The app's name, package identity, as well as everything related to its Settings entry is configured in the `Package.appxmanifest` file.

## What can I use to design the card?
You can use the [AdativeCards.io designer](https://adaptivecards.io/designer/), make sure to set the `Target version` to `1.1` so you don't end up using elements not supported by the shell's renderer.

![image](https://github.com/thebookisclosed/StartMenuCompanionSample/assets/13197516/e9a34481-0a1c-4436-872e-00db6de292c0)
