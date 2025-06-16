using UnityEngine;
using UnityEngine.Events;

namespace Demegraunt.Framework {
    /// <summary>
    /// Invokes unity-event on <see cref="OnMouseOver()"/>.
    /// </summary>
    public sealed class OnMouseOverDelegate : MonoBehaviour {
        [field: SerializeField] public UnityEvent OnMouseOverInvoke { get; set; } = new();
        
        private void OnMouseOver() {
            OnMouseOverInvoke.Invoke();
        }
    }
}