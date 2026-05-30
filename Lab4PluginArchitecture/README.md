# Lab 4 - Plugins and Dynamic Hierarchy

## Description
This project demonstrates:
- Dynamic plugin loading
- Extensible class hierarchy
- Runtime module discovery
- No recompilation required for adding plugins

## Technologies
- C#
- .NET 8
- WPF
- Reflection
- DLL plugins

## Structure
- CoreApp -> Main application
- TeacherPlugin -> Example plugin

## How it works
1. Core application loads all DLL files from Plugins folder
2. Plugin classes implementing IPlugin are discovered
3. Plugins register new object creators
4. UI updates automatically

## Run
Copy TeacherPlugin.dll into:
Plugins/

Then run:

```bash
dotnet run
```
