using UnityEngine;
using UnityEngine.Events;

namespace Demegraunt.Framework {
    /// <summary>
    /// Invokes unity-event(-s) on <see cref="OnEnable()"/> and <see cref="OnDisable()"/>.
    /// </summary>
    public sealed class EnableDisableDelegate : MonoBehaviour {
        [field: SerializeField] public UnityEvent OnEnabled { get; set; } = new();
        [field: SerializeField] public UnityEvent OnDisabled { get; set; } = new();
        [field: SerializeField] public UnityEvent OnEnabledOrDisabled { get; set; } = new();

        private void OnEnable() {
            OnEnabled.Invoke();
            OnEnabledOrDisabled.Invoke();
        }

        private void OnDisable() {
            OnDisabled.Invoke();
            OnEnabledOrDisabled.Invoke();
        }
    }
}