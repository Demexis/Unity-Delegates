using UnityEngine;
using UnityEngine.Events;

namespace Demegraunt.Framework {
    /// <summary>
    /// Invokes unity-event on <see cref="LateUpdate()"/>.
    /// </summary>
    public sealed class FixedUpdateDelegate : MonoBehaviour {
        [field: SerializeField] public UnityEvent OnFixedUpdate { get; set; } = new();
        
        private void LateUpdate() {
            OnFixedUpdate.Invoke();
        }
    }
}