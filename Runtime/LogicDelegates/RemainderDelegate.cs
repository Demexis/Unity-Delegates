using UnityEngine;
using UnityEngine.Events;

namespace Demegraunt.Framework {
    /// <summary>
    /// Remainder calculator and its contextually associated events.
    /// </summary>
    public sealed class RemainderDelegate : MonoBehaviour {
        [field: Header("General")]
        [field: SerializeField] public int Dividend { get; set; } = 1;
        [field: SerializeField] public int Divisor { get; set; } = 2;
        
        [field: SerializeField] public UnityEvent<int> OnResultRemainder { get; set; } = new();
        [field: SerializeField] public UnityEvent<int> OnResultQuotient { get; set; } = new();
        
        [field: SerializeField] public bool AllowNegative { get; set; }
        
        [field: Header("Expected")]
        [field: SerializeField] public int ExpectedRemainder { get; set; }
        [field: SerializeField] public UnityEvent OnResultExpectedRemainder { get; set; } = new();
        
        [field: SerializeField] public int ExpectedQuotient { get; set; }
        [field: SerializeField] public UnityEvent OnResultExpectedQuotient { get; set; } = new();

        public void Trigger() {
            var remainder = GetRemainder();
            var quotient = GetQuotient();
            
            OnResultRemainder.Invoke(remainder);
            OnResultQuotient.Invoke(quotient);

            if (remainder == ExpectedRemainder) {
                OnResultExpectedRemainder.Invoke();
            }

            if (quotient == ExpectedQuotient) {
                OnResultExpectedQuotient.Invoke();
            }
        }
        
        public void AddOne() {
            Add(1);
        }
        
        public void Add(int value) {
            Dividend += value;
            ClampNegative();
        }

        public void SubtractOne() {
            Subtract(1);
        }

        public void Subtract(int value) {
            Dividend -= value;
            ClampNegative();
        }

        public void ClampNegative() {
            if (AllowNegative) {
                return;
            }
            
            Dividend = Mathf.Clamp(Dividend, 0, int.MaxValue);
        }
        
        public bool CheckRemainder(int value) {
            return GetRemainder() == value;
        }

        public bool CheckQuotient(int value) {
            return GetQuotient() == value;
        }

        public int GetRemainder() {
            return Dividend % Divisor;
        }

        public int GetQuotient() {
            return Dividend / Divisor;
        }
    }
}