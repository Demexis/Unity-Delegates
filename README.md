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

> Have you ever written scripts like: `DisableSpriteRendererOnAwake.cs`, `SetRawImageColorAlphaWithDelay.cs`? These scripts maybe were used only once in the main menu or somewhere else, but they are still in the project and make code navigation and searching more difficult as their number increases. Previously mentioned scripts work with specific types, and if you need to apply similar logic, for example, not only to sprites, but also to lines, other renderers, or your custom scripts, the number of such scripts will increase, given that it is not always possible to simply specify a base class so that the logic works for all types you work with.
>
> I am not an adherent of DRY (Don't Repeat Yourself), and I am not saying that there must be no repeating code in the project, on the contrary, it is ok. But in many cases you can avoid the accumulation of unnecessary garbage scripts by using `UnityEvent`(-s), to which you can subscribe most of what you may need.
>
> I also hope that, just as with any other programming principles and patterns, you won't blindly attach a given architectural paradigm to everything, but will be able to recognize where it is truly convenient, easy, and appropriate, and where it is worth applying old or other approaches for the sake of optimization or debugging.

## Table of Contents
- [Setup](#setup)
- [Usage](#usage)
- [Examples](#examples)
- [Write Your Own Delegate Script](#write-your-own-delegate-script)

<br>

## Setup

### Requirements

* Unity 2021.3 or later

### Installation

> ⚠️ After installation, you may need to restart your project so that you can use `MonoBehaviour` components from this package in the inspector.

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

__3) For more complex logic using conditions (if-else), you may need to integrate a custom repository with serializable callbacks, for example, this one: https://github.com/Siccity/SerializableCallback.git__

## Examples
__1: Make the sprite used only for work in the editor - invisible in the play mode__

![example-disable-sprite-on-awake](https://github.com/user-attachments/assets/5d31c140-92eb-487b-ab2d-a8fa2470bc2e)


__2: Spawn a reward with some chance when the object dies__

![example-spawn-reward-on-destroy](https://github.com/user-attachments/assets/142f5ffa-90c6-4189-993e-3188cc0f6ec0)

* ⚠️ `SimpleSpawner` is just an example of a simple script for spawning a prefab, it is not in this package, but you can easily write one yourself.
* ⚠️ `MonoBehaviour.OnDestroy()` is not always guaranteed to be called, and is used in this example to simplify the idea. Remember that `OnDestroy` is also called when changing a scene, exiting a play mode, or removing script in the editor. Usually each project has its own system of spawning/despawning game objects, and in this case, you could write your own delegate script to avoid the shortcomings of `OnDestroy`.


__3: A button that plays a sound and redirects to your social networks when clicked__

![example-play-audio-and-open-link-on-button-click](https://github.com/user-attachments/assets/0be44fdc-b008-4e82-9d3c-fb01c20daae2)

* ⚠️ `InstantiateSound` is just an example of a simple script for playing an `AudioClip` asset (not included in this package). You can write delegate script for your own audio manager or something similar.


__4: Flickering sprite with transparency__

![example-flickering-sprite-with-transparency](https://github.com/user-attachments/assets/877b3e0d-7475-49df-998a-7e3e4b999a98)


__5: Toggle for visuals and other things__

![example-toggle-for-visuals](https://github.com/user-attachments/assets/1e7e0643-c871-41c4-bebb-22b34fa3601e)


## Write Your Own Delegate Script

> When creating a game, you may need delegate scripts that allow you to interact with the interface of your systems via `UnityEvent`(-s). Although most likely, you could come up with a general-purpose script that is not related to any systems, or you wanted to make a script that allows you to invoke some algorithm via `UnityEvent` that interacts with existing components from official Unity packages.

Either way, here are some useful tips for you:

__1) All public serializable fields must be auto-properties so that they can be accessed and assigned ​​via `UnityEvent`(-s).__
```cs
[field: SerializeField] public float Speed { get; set; } = 1f;
```
__2) If the `class` is not `abstract`, it should be `sealed`!__

> ⚠️ In the Unity ecosystem, existing scripts are difficult to rewrite without losing data and method/field references. Don't create inheritance trees where you can safely do without them, even if it requires some code repetition.

__3) If you use a custom package that provides serializable callbacks in Unity (similar to `System.Func<T>`, but with the ability to specify the property/method via the inspector), then you have a great opportunity to separate out pieces of code that might return a value, especially a `bool`.__
```cs
[Serializable]
public sealed class BoolCallback : SerializableCallback<bool> { }
```
```cs
public sealed class FuncBoolDelegate : MonoBehaviour {
    [field: SerializeField] public BoolCallback Callback { get; set; } = new();

    [field: SerializeField] public UnityEvent<bool> OnTrigger { get; set; } = new();
    [field: SerializeField] public UnityEvent OnTriggerTrue { get; set; } = new();
    [field: SerializeField] public UnityEvent OnTriggerFalse { get; set; } = new();
    
    public void Trigger() {
        var triggerResult = Callback.Invoke();
        
        OnTrigger.Invoke(triggerResult);
        
        if (triggerResult) {
            OnTriggerTrue.Invoke();
        } else {
            OnTriggerFalse.Invoke();
        }
    }
```
```cs
public sealed class SimplifiedShop : MonoBehaviour {
    [field: SerializeField] public int CurrentCurrencyAmount { get; set; }
    [field: SerializeField] public int ItemCost { get; set; } = 1;

    public bool TryPurchase() {
        if (CurrentCurrencyAmount >= ItemCost) {
            CurrentCurrencyAmount -= ItemCost;
            return true;
        }
        return false;
    }

    public void AddAmount(int amount) {
        CurrentCurrencyAmount += amount;
    }
}
```

![example-simplified-shop](https://github.com/user-attachments/assets/a8ce15b1-11ca-4971-bc58-3a56abfc275e)
