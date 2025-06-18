[![GitHub Release](https://img.shields.io/github/v/release/Demexis/Unity-Delegates.svg)](https://github.com/Demexis/Unity-Delegates/releases/latest)
[![MIT license](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE)
# Unity-Delegates

<table>
  <tr></tr>
  <tr>
    <td colspan="3">Языки Readme:</td>
  </tr>
  <tr></tr>
  <tr>
    <td nowrap width="100">
      <a href="https://github.com/Demexis/Unity-Buffs">
        <span>English</span>
      </a>  
    </td>
    <td nowrap width="100">
      <a href="https://github.com/Demexis/Unity-Buffs/blob/main/README-RU.md">
        <span>Русский</span>
      </a>  
    </td>
  </tr>
</table>

Данный пакет является отправной демонстрацией того, как вы можете использовать `MonoBehaviour` компоненты общего назначения использующие `UnityEvent`-ы для того, чтобы вам не приходилось писать отдельные скрипты для выполнения простецких и примитивных действий.

> Вы когда-нибудь писали скрипты, типа: `DisableSpriteRendererOnAwake.cs`, `SetRawImageColorAlphaWithDelay.cs`? Эти скрипты вполне возможно используются всего лишь один раз в главном меню или где-то ещё, но они всё равно находятся в проекте и усложняют навигацию и поиск в IDE при увеличении их кол-ва. Ранее упомянутые скрипты работают с конкретными типами, и если нужно применить схожую логику, скажем, не только со спрайтами, но также с линиями, другими рендерами, или вашими кастомными скриптами, кол-во подобных скриптов увеличится, учитывая, что не всегда есть возможность просто указать базовый класс для того, чтобы логика срабатывала для всех типов с которыми вы работаете.
>
> Я не адепт прицнипа DRY (Don't Repeat Yourself), и я не говорю, что в проекте не должно быть повторяющегося кода, напротив, это нормально. Но во многих случаях можно избежать накопления лишних мусорных скриптов, используя `UnityEvent`(-ы), к которым можно подписать большую часть того, что вам может понадобиться.
>
> Я также надеюсь, что как и с любыми другими принципами и шаблонами в программировании, вы не будете слепо навешивать данную архитектурную парадигму на всё, а сможете осознать, где это удобно, легко, и уместно, а где стоит применить старый или другие подходы в угоду оптимизации или отладки.

## Содержание
- [Настройка](#setup)
- [Использование](#usage)
- [Примеры](#examples)
- [Напишите Свой Скрипт-Делегат](#write-your-own-delegate-script)

<br>

## Настройка

### Требования

* Unity 2021.3 или позднее

### Установка

Используйте __ОДИН__ из двух вариантов:

#### а) Менеджер пакетов (Рекомендуется)
1. Откройте Package Manager из Window > Package Manager.
2. Нажмите на кнопку "+" > Add package from git URL.
3. Введите в поле этот URL:
```
https://github.com/Demexis/Unity-Delegates.git
```

Альтернативно, можете открыть *Packages/manifest.json* и добавить туда новую строку в блок "dependencies":

```json
{
    "dependencies": {
        "com.demegraunt.unitydelegates": "https://github.com/Demexis/Unity-Delegates.git"
    }
}
```

#### б) Юнити-пакет
Скачайте юнити-пакет из [последнего релиза](../../releases).

## Использование

__1) Ознакомьтесь со списком уже существующих компонентов с подробным описании на wiki.__

__2) Добавьте на игровой объект необходимые компоненты для исполнения вашей игровой логике, свяжите их между собой через UntiyEvent(-ы), если нужно.__

__3) Для более сложной логики с использованием условий (if-else), может потребоваться интегрировать кастомный репозиторий с сериализуемыми калбеками, например, вот этот: https://github.com/Siccity/SerializableCallback.git__

## Примеры
__1:  Make the sprite used only for work in the editor - invisible in the play mode__

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
