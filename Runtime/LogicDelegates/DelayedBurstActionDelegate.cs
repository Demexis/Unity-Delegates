using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Demegraunt.Framework {
    public sealed class DelayedBurstActionDelegate : MonoBehaviour {
        private sealed class DelayedBurstInstance {
            public int BurstCount { get; set; }
            public float DelayTime { get; set; }
            public float Timer { get; set; }

            public DelayedBurstInstance(int burstCount, float delayTime, float timer) {
                BurstCount = burstCount;
                DelayTime = delayTime;
                Timer = timer;
            }
        }
        
        [field: SerializeField] public int BurstCount { get; set; } = 1;
        [field: SerializeField] public float TriggerStartDelayTime { get; set; }
        [field: SerializeField] public float DelayTime { get; set; } = 1f;
        
        [field: SerializeField, Tooltip("If disabled - will clear all previous calls and reset the timer.")] 
        public bool TriggersAreIndependent { get; set; }

        [field: SerializeField] public UnityEvent OnTrigger { get; set; } = new();

        private List<DelayedBurstInstance> CallInstances { get; set; } = new();

        public void Trigger() {
            Trigger(TriggerStartDelayTime);
        }
        
        public void Trigger(float startDelayTime) {
            if (!TriggersAreIndependent) {
                CallInstances.Clear();
            }
            
            CallInstances.Add(new DelayedBurstInstance(BurstCount, DelayTime, startDelayTime));
        }

        private void Update() {
            // reversed for-loop prevents "collection modified exception"
            for (var i = CallInstances.Count - 1; i >= 0; i--) {
                var callInstance = CallInstances[i];
                callInstance.Timer -= Time.deltaTime;
                
                if (callInstance.Timer > 0f) {
                    continue;
                }

                callInstance.BurstCount--;

                // removing here, otherwise possible collection modification via unity-event
                if (callInstance.BurstCount <= 0) {
                    CallInstances.RemoveAt(i);
                }
                
                OnTrigger.Invoke();
                
                if (callInstance.BurstCount > 0) {
                    callInstance.Timer = callInstance.DelayTime;
                }
            }
        }
    }
}