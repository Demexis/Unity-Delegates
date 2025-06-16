using UnityEngine;
using UnityEngine.Events;

namespace Demegraunt.Framework {
    /// <summary>
    /// Invokes unity-event on <see cref="Update()"/>.
    /// </summary>
    public sealed class UpdateDelegate : MonoBehaviour {
        [field: SerializeField] public UnityEvent OnUpdate { get; set; } = new();
        
        private void Update() {
            OnUpdate.Invoke();
        }
    }
}