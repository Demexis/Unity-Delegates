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

Данный пакет является отправной демонстрацией того, как вы можете использовать `MonoBehaviour` компоненты общего назначения использующие `UnityEvent`-ы для того, чтобы вам не приходилось писать отдельные скрипты для выполнения простецких и примитивных действий.

> Вы когда-нибудь писали скрипты, типа: `DisableSpriteRendererOnAwake.cs`, `SetRawImageColorAlphaWithDelay.cs`? Эти скрипты вполне возможно используются всего лишь один раз в главном меню или где-то ещё, но они всё равно находятся в проекте и усложняют навигацию и поиск в IDE при увеличении их кол-ва. Ранее упомянутые скрипты работают с конкретными типами, и если нужно применить схожую логику, скажем, не только со спрайтами, но также с линиями, другими рендерами, или вашими кастомными скриптами, кол-во подобных скриптов увеличится, учитывая, что не всегда есть возможность просто указать базовый класс для того, чтобы логика срабатывала для всех типов с которыми вы работаете.
>
> Я не адепт прицнипа DRY (Don't Repeat Yourself), и я не говорю, что в проекте не должно быть повторяющегося кода, напротив, это нормально. Но во многих случаях можно избежать накопления лишних мусорных скриптов, используя `UnityEvent`(-ы), к которым можно подписать большую часть того, что вам может понадобиться.
>
> Надеюсь, что как и с любыми другими принципами и шаблонами в программировании, вы не будете слепо навешивать данную архитектурную парадигму на всё, а сможете осознать, где это удобно, легко, и уместно, а где стоит применить старый или другие подходы в угоду оптимизации или отладки.

## Содержание
- [Настройка](#setup)
- [Использование](#usage)
- [Примеры](#examples)
- [Напишите свой скрипт-делегат](#write-your-own-delegate-script)

<br>

## Настройка

### Требования

* Unity 2021.3 или позднее

### Установка

> ⚠️ После установки может потребоваться перезапустить проект для того, чтобы в инспекторе начали показываться компоненты из данного пакета.

Используйте __ОДИН__ из двух вариантов:

#### а) Юнити-пакет (Рекомендуется)
Скачайте юнити-пакет из [последнего релиза](../../releases).

#### б) Менеджер пакетов
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

## Использование

__1) Ознакомьтесь со списком уже существующих компонентов с описанием на wiki.__

__2) Добавьте на игровой объект необходимые компоненты для исполнения вашей игровой логики, свяжите их между собой через UntiyEvent(-ы), если нужно.__

__3) Для более сложной логики с использованием условий (if-else), может потребоваться интегрировать кастомный репозиторий с сериализуемыми калбеками, например, вот этот: https://github.com/Siccity/SerializableCallback.git__

## Примеры
__1: Сделать спрайт используемый только для работы в редакторе - невидимым во время игры__

![example-disable-sprite-on-awake](https://github.com/user-attachments/assets/5d31c140-92eb-487b-ab2d-a8fa2470bc2e)


__2: Заспавнить награду с некоторым шансом когда объект умирает__

![example-spawn-reward-on-destroy](https://github.com/user-attachments/assets/142f5ffa-90c6-4189-993e-3188cc0f6ec0)

* ⚠️ `SimpleSpawner` всего лишь пример простого скрипта для спавна префаба, этот скрипт не находится в пакете, но вы с лёгкостью можете написать такой сами.
* ⚠️ `MonoBehaviour.OnDestroy()` не всегда гарантированно вызывается, и используется в данном примере для упрощения самой идеи. Помните, что `OnDestroy` также вызывается при смене сцены, выхода из режима игры (Play Mode), а также при убирании скрипта в редакторе. Обычно каждый проект имеет свою собственную систему для спавна/де-спавна игровых объектов, и в таком случае, можно написать свой скрипт-делегат чтобы нивелировать недостатки `OnDestroy`.


__3: Кнопка которая проигрывает звук и перенаправляет на ваши соцсети при нажатии__

![example-play-audio-and-open-link-on-button-click](https://github.com/user-attachments/assets/0be44fdc-b008-4e82-9d3c-fb01c20daae2)

* ⚠️ `InstantiateSound` всего лишь пример простого скрипта для проигрывания звука (не включен в пакет). Вы можете написать скрипт-делегат для своего аудио-менеджера или чего-то подобного.


__4: Мерцающий спрайт с прозрачностью__

![example-flickering-sprite-with-transparency](https://github.com/user-attachments/assets/877b3e0d-7475-49df-998a-7e3e4b999a98)


__5: Переключатель для визуальных и прочих штучек__

![example-toggle-for-visuals](https://github.com/user-attachments/assets/1e7e0643-c871-41c4-bebb-22b34fa3601e)


## Напишите свой скрипт-делегат

> При создании игры, могут понадобиться скрипты-делегаты которые позволяют взаимодействовать с интерфейсом ваших систем через `UnityEvent`(-ы). Однако, скорее всего, вы могли придумать скрипт общего назначения который не связан ни с какой системой, или вы хотели сделать скрипт который позволяет вызвать исполнение некоторого алгоритма через `UnityEvent` который взаимодействует с существующими компонентами из официальных пакетов Unity.

В любом случае, вот пара полезных советов:

__1) Все публичные сериализуемые поля должны быть в виде авто-свойств, чтобы к ним можно было обратиться через `UnityEvent`(-ы).__
```cs
[field: SerializeField] public float Speed { get; set; } = 1f;
```
__2) Если класс (`class`) не является абстрактным (`abstract`), он должен быть запечатан (`sealed`)!__

> ⚠️ В экосистеме Unity, существующие скрипты трудно поддаются переписыванию без потери данных и ссылок на методы/поля. Не создавайте лишние деревья наследования там, где можно спокойно обойтись без них, даже если это требует дублирования некоторых фрагментов кода.

__3) Если вы используете кастомный пакет который предоставляет сериализуемые калбеки в Unity (схожие с `System.Func<T>`, но с возможностью указать свойство/метод через инспектор), тогда есть отличная возможность отделить фрагменты кода которые могут вернуть в дальнейшем используемое значение, например, `bool`.__
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
