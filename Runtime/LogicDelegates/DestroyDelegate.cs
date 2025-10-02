using UnityEngine;
using UnityEngine.Events;

namespace Demegraunt.Framework {
    public sealed class DestroyDelegate : MonoBehaviour {
        [field: SerializeField] public Object Object { get; set; }
        [field: SerializeField] public UnityEvent OnBeforeDestroy { get; set; } = new();

        public void Destroy() {
            OnBeforeDestroy.Invoke();
            Destroy(Object);
        }
    }
}