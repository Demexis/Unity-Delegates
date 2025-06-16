using UnityEngine;
using UnityEngine.Events;

namespace Demegraunt.Framework {
    /// <summary>
    /// Invokes unity-event on <see cref="OnMouseDrag()"/>.
    /// </summary>
    public sealed class OnMouseDragDelegate : MonoBehaviour {
        [field: SerializeField] public UnityEvent OnMouseDragInvoke { get; set; } = new();
        
        private void OnMouseDrag() {
            OnMouseDragInvoke.Invoke();
        }
    }
}