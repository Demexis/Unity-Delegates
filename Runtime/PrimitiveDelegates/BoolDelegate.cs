using UnityEngine;
using UnityEngine.Events;

namespace Demegraunt.Framework {
    /// <summary>
    /// Manipulates a boolean variable and its contextually associated events.<br/><br/>
    /// Can be useful when building logic/behaviour via UnityEvent-s.
    /// </summary>
    public sealed class BoolDelegate : MonoBehaviour {
        [field: SerializeField] public bool BoolValue { get; set; }

        [field: SerializeField] public UnityEvent<bool> OnTrigger { get; set; } = new();
        [field: SerializeField] public UnityEvent OnTriggerTrue { get; set; } = new();
        [field: SerializeField] public UnityEvent OnTriggerFalse { get; set; } = new();
        
        public bool IsTrue => BoolValue;
        public bool IsFalse => !BoolValue;

        public void SetInvertValue(bool value) {
            BoolValue = !value;
        }

        public void InvertValue() {
            BoolValue = !BoolValue;
        }

        public void SetAndTrigger(bool value) {
            BoolValue = value;
            Trigger(value);
        }
        
        public void Trigger() {
            Trigger(BoolValue);
        }
        
        public void Trigger(bool value) {
            OnTrigger.Invoke(value);

            if (value) {
                OnTriggerTrue.Invoke();
            } else {
                OnTriggerFalse.Invoke();
            }
        }
    }
}