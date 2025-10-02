using UnityEngine;
using UnityEngine.Events;

namespace Demegraunt.Framework {
    public sealed class CollisionExit2DDelegate : MonoBehaviour {
        [field: SerializeField] public UnityEvent<Collision2D> OnCollision { get; set; } = new();
        
        private void OnCollisionExit2D(Collision2D other) {
            OnCollision.Invoke(other);
        }
    }
}