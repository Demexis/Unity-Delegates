[![GitHub Release](https://img.shields.io/github/v/release/Demexis/Unity-Delegates.svg)](https://github.com/Demexis/Unity-Delegates/releases/latest)
[![MIT license](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE)
# Unity-Delegates

<table>
  <tr></tr>
  <tr>
    <td colspan="3">Readme Languages:</td>
  </tr>
  <tr></tr>
  <tr>
    <td nowrap width="100">
      <a href="https://github.com/Demexis/Unity-Delegates">
        <span>English</span>
      </a>  
    </td>
    <td nowrap width="100">
      <a href="https://github.com/Demexis/Unity-Delegates/blob/main/README-RU.md">
        <span>Русский</span>
      </a>  
    </td>
  </tr>
</table>

This package is a starting point for demonstrating how you can use general purpose `MonoBehaviour` components that use UnityEvents so that you don't have to write separate scripts to perform simple and primitive actions.

## Table of Contents
- [Setup](#setup)
- [Usage](#usage)
- [Examples](#examples)
- [Hints](#hints)

<br>

## Setup

### Requirements

* Unity 2021.3 or later

### Installation

Use __ONE__ of two options:

#### a) Package Manager (Recommended)
1. Open Package Manager from Window > Package Manager.
2. Click the "+" button > Add package from git URL.
3. Enter the following URL:
```
https://github.com/Demexis/Unity-Delegates.git
```

Alternatively, open *Packages/manifest.json* and add the following to the dependencies block:

```json
{
    "dependencies": {
        "com.demegraunt.unitydelegates": "https://github.com/Demexis/Unity-Delegates.git"
    }
}
```

#### b) Unity Package
Download a unity package from [the latest release](../../releases).

## Usage

__1) Check out the list of existing components with a detailed description on the wiki.__

__2) Add the necessary components to the game object to execute your game logic, link them together via UnityEvent(-s) if needed.__

__3) For more complex logic using conditions (if-else), you can refer to custom repositories with serializable callbacks, for example, this one: https://github.com/Siccity/SerializableCallback.git__

## Examples
__1: Make the sprite used only for work in the editor - invisible in the play mode.__

![example-disable-sprite-on-awake](https://github.com/user-attachments/assets/5d31c140-92eb-487b-ab2d-a8fa2470bc2e)

__2: Spawn a reward with some chance when the object dies.__

![example-spawn-reward-on-destroy](https://github.com/user-attachments/assets/142f5ffa-90c6-4189-993e-3188cc0f6ec0)

* Note: `SimpleSpawner` is just an example of a simple script for spawning a prefab, it is not in this package, but you can easily write one yourself.
* Note: `MonoBehaviour.OnDestroy()` is not always guaranteed to be called, and is used in this example to simplify the idea. Remember that `OnDestroy` is also called when changing a scene, exiting a play mode, or removing script in the editor. Usually each project has its own system of spawning/despawning game objects, and in this case, you could write your own delegate script to avoid the shortcomings of `OnDestroy`.

## Hints
