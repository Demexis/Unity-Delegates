using UnityEngine;
using UnityEngine.Events;

namespace Demegraunt.Framework {
    /// <summary>
    /// Performs action with random chance.
    /// </summary>
    public sealed class RandomActionDelegate : MonoBehaviour {
        private const float MIN_CHANCE = 0f;
        private const float MAX_CHANCE = 1f;
        
        [field: SerializeField, Range(MIN_CHANCE, MAX_CHANCE)] public float Chance { get; set; } = 0.5f;
        [field: SerializeField] public UnityEvent OnSuccess { get; set; } = new();
        [field: SerializeField] public UnityEvent OnFailure { get; set; } = new();
        
        public void Trigger() {
            Trigger(Chance);
        }
        
        public void Trigger(float chance) {
            var rand = Random.Range(MIN_CHANCE, MAX_CHANCE);

            if (rand > chance) {
                OnFailure.Invoke();
                return;
            }
            
            OnSuccess.Invoke();
        }
    }
}