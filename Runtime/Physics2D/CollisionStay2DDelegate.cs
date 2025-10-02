using UnityEngine;
using UnityEngine.Events;

namespace Demegraunt.Framework {
    public sealed class CollisionStay2DDelegate : MonoBehaviour {
        [field: SerializeField] public UnityEvent<Collision2D> OnCollision { get; set; } = new();
        
        private void OnCollisionStay2D(Collision2D other) {
            OnCollision.Invoke(other);
        }
    }
}