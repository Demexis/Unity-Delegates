using UnityEngine;
using UnityEngine.Events;

namespace Demegraunt.Framework {
    /// <summary>
    /// Invokes unity-event on <see cref="OnMouseDown()"/>.
    /// </summary>
    public sealed class OnMouseDownDelegate : MonoBehaviour {
        [field: SerializeField] public UnityEvent OnMouseDownInvoke { get; set; } = new();
        
        private void OnMouseDown() {
            OnMouseDownInvoke.Invoke();
        }
    }
}