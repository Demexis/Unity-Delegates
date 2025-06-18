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

This package is a starting point for demonstrating how you can use general purpose `MonoBehaviour` components that use `UnityEvent`(-s) so that you don't have to write separate scripts to perform simple and primitive actions.

Have you ever written scripts like: `DisableSpriteRendererOnAwake.cs`, `SetRawImageColorAlphaWithDelay.cs`? These scripts maybe were used only once in the main menu or somewhere else, but they are still in the project and make code navigation and searching more difficult as their number increases. Previously mentioned scripts work with specific types, and if you need to apply similar logic, for example, not only to sprites, but also to lines, other renderers, or your custom scripts, the number of such scripts will increase, given that it is not always possible to simply specify a base class so that the logic works for all types you work with.

I am not an adherent of DRY (Don't Repeat Yourself), and I am not saying that there must be no repeating code in the project, on the contrary, it is ok. But in many cases you can avoid the accumulation of unnecessary garbage scripts by using `UnityEvent`(-s), to which you can subscribe most of what you may need.

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

* ⚠️ `SimpleSpawner` is just an example of a simple script for spawning a prefab, it is not in this package, but you can easily write one yourself.
* ⚠️ `MonoBehaviour.OnDestroy()` is not always guaranteed to be called, and is used in this example to simplify the idea. Remember that `OnDestroy` is also called when changing a scene, exiting a play mode, or removing script in the editor. Usually each project has its own system of spawning/despawning game objects, and in this case, you could write your own delegate script to avoid the shortcomings of `OnDestroy`.

__3: A button that plays a sound and redirects to your social networks when clicked.__

![example-play-audio-and-open-link-on-button-click](https://github.com/user-attachments/assets/0be44fdc-b008-4e82-9d3c-fb01c20daae2)

* ⚠️ `InstantiateSound` is just an example of a simple script for playing an `AudioClip` asset (not included in this package). You can write delegate script for your own audio manager or something similar.

## Hints
