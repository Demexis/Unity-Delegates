using UnityEngine;
using UnityEngine.Events;

namespace Demegraunt.Framework {
    public sealed class TriggerStay2DDelegate : MonoBehaviour {
        [field: SerializeField] public UnityEvent<Collider2D> OnTrigger { get; set; } = new();
        
        private void OnTriggerStay2D(Collider2D other) {
            OnTrigger.Invoke(other);
        }
    }
}