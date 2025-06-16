using UnityEngine;
using UnityEngine.Events;

namespace Demegraunt.Framework {
    /// <summary>
    /// Invokes unity-event on <see cref="OnMouseUp()"/>.
    /// </summary>
    public sealed class OnMouseUpDelegate : MonoBehaviour {
        [field: SerializeField] public UnityEvent OnMouseUpInvoke { get; set; } = new();
        
        private void OnMouseUp() {
            OnMouseUpInvoke.Invoke();
        }
    }
}