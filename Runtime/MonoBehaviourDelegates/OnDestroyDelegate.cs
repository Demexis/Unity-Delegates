using UnityEngine;
using UnityEngine.Events;

namespace Demegraunt.Framework {
    /// <summary>
    /// Invokes unity-event on <see cref="OnDestroy()"/>.
    /// </summary>
    public sealed class OnDestroyDelegate : MonoBehaviour {
        [field: SerializeField] public UnityEvent OnDestroyed { get; set; } = new();

        private void OnDestroy() {
            OnDestroyed.Invoke();
        }
    }
}