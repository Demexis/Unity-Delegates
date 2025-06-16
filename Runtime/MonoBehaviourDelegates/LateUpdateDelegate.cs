using UnityEngine;
using UnityEngine.Events;

namespace Demegraunt.Framework {
    /// <summary>
    /// Invokes unity-event on <see cref="LateUpdate()"/>.
    /// </summary>
    public sealed class LateUpdateDelegate : MonoBehaviour {
        [field: SerializeField] public UnityEvent OnLateUpdate { get; set; } = new();
        
        private void LateUpdate() {
            OnLateUpdate.Invoke();
        }
    }
}