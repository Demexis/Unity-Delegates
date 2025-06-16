using UnityEngine;
using UnityEngine.Events;

namespace Demegraunt.Framework {
    /// <summary>
    /// Invokes unity-event on <see cref="OnMouseEnter()"/>.
    /// </summary>
    public sealed class OnMouseEnterDelegate : MonoBehaviour {
        [field: SerializeField] public UnityEvent OnMouseEnterInvoke { get; set; } = new();
        
        private void OnMouseEnter() {
            OnMouseEnterInvoke.Invoke();
        }
    }
}