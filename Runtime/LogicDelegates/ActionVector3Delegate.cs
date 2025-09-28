using UnityEngine;
using UnityEngine.Events;

namespace Demegraunt.Framework {
    public sealed class ActionVector3Delegate : MonoBehaviour {
        [field: SerializeField] public Vector3 Vec3 { get; set; } = Vector3.zero;
        [field: SerializeField] public UnityEvent<Vector3> OnTrigger { get; set; } = new();

        public void SetAndTrigger(Vector3 vec3) {
            Vec3 = vec3;
            Trigger();
        }
        
        public void Trigger() {
            OnTrigger.Invoke(Vec3);
        }
    }
}