using UnityEngine;
using UnityEngine.Events;

namespace Demegraunt.Framework {
    /// <summary>
    /// Invokes unity-event on <see cref="Awake()"/>.
    /// </summary>
    public sealed class AwakeDelegate : MonoBehaviour {
        [field: SerializeField] public UnityEvent OnAwake { get; set; } = new();
        
        private void Awake() {
            OnAwake.Invoke();
        }
    }
}