using UnityEngine;
using UnityEngine.Events;

namespace Demegraunt.Framework {
    /// <summary>
    /// Invokes unity-event on <see cref="OnMouseExit()"/>.
    /// </summary>
    public sealed class OnMouseExitDelegate : MonoBehaviour {
        [field: SerializeField] public UnityEvent OnMouseExitInvoke { get; set; } = new();
        
        private void OnMouseExit() {
            OnMouseExitInvoke.Invoke();
        }
    }
}