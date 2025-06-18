using UnityEngine;
using UnityEngine.Events;

namespace Demegraunt.Framework {
    /// <summary>
    /// An intermediate component to reduce duplicate subscriptions.
    /// </summary>
    public sealed class ActionDelegate : MonoBehaviour {
        #if UNITY_EDITOR
        [field: SerializeField, TextArea] public string EditorDescription { get; set; } = string.Empty;
        #endif
        [field: SerializeField] public UnityEvent OnTrigger { get; set; } = new();

        public void Trigger() {
            OnTrigger.Invoke();
        }
    }
}