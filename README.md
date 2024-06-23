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

![image](https://github.com/thebookisclosed/StartMenuCompanionSample/assets/13197516/e9a34481-0a1c-4436-872e-00db6de292c0)
