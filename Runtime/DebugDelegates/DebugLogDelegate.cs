using JetBrains.Annotations;
using System;
using UnityEngine;

namespace Demegraunt.Framework {
    public sealed class DebugLogDelegate : MonoBehaviour {
        public enum DebugLogType {
            Log, 
            Warning,
            Error
        }

        [field: SerializeField] public DebugLogType LogType { get; set; } = DebugLogType.Log;
        [field: SerializeField] public string Text { get; set; } = string.Empty;

        [UsedImplicitly]
        public void Trigger() {
            switch (LogType) {
                case DebugLogType.Log:
                    Debug.Log(Text, gameObject);
                    break;
                case DebugLogType.Warning:
                    Debug.LogWarning(Text, gameObject);
                    break;
                case DebugLogType.Error:
                    Debug.LogError(Text, gameObject);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}