using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Demegraunt.Framework {
    /// <summary>
    /// Performs action with a time-delay.
    /// </summary>
    public sealed class DelayedActionDelegate : MonoBehaviour {
        [field: SerializeField] public float DelayTime { get; set; } = 1f;
        [field: SerializeField, Tooltip("If disabled - will clear all previous calls and reset the timer.")] 
        public bool TriggersAreIndependent { get; set; }

        [field: SerializeField] public UnityEvent OnTriggerExpired { get; set; } = new();
        [field: SerializeField] public UnityEvent OnTrigger { get; set; } = new();

        private List<float> CallTimers { get; set; } = new();

        public void Trigger() {
            Trigger(DelayTime);
        }
        
        public void Trigger(float delayTime) {
            OnTrigger.Invoke();

            if (!TriggersAreIndependent) {
                CallTimers.Clear();
            }
            
            CallTimers.Add(delayTime);
        }

        private void Update() {
            // reversed for-loop prevents "collection modified exception"
            for (var i = CallTimers.Count - 1; i >= 0; i--) {
                var timer = CallTimers[i];
                timer -= Time.deltaTime;
                
                if (timer > 0f) {
                    CallTimers[i] = timer;
                    continue;
                }
                
                CallTimers.RemoveAt(i);
                OnTriggerExpired.Invoke();
            }
        }
    }
}