using UnityEngine;
using UnityEngine.Events;

namespace Demegraunt.Framework {
    /// <summary>
    /// Invokes unity-event on <see cref="Start()"/>.
    /// </summary>
    public sealed class StartDelegate : MonoBehaviour {
        [field: SerializeField] public UnityEvent OnStart { get; set; } = new();
        
        private void Start() {
            OnStart.Invoke();
        }
    }
}