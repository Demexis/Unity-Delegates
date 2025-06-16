using UnityEngine;
using UnityEngine.Events;

namespace Demegraunt.Framework {
    /// <summary>
    /// Opens specified <see cref="Url"/> and invokes unity-event with that url.
    /// </summary>
    public sealed class OpenUrlDelegate : MonoBehaviour {
        // ReSharper disable once MemberCanBePrivate.Global
        public const string DEFAULT_URL_EXAMPLE = "https://unity.com/";
        
        [field: SerializeField] public string Url { get; set; } = DEFAULT_URL_EXAMPLE;
        [field: SerializeField] public UnityEvent<string> OnOpenUrl { get; set; } = new();

        public void Trigger() {
            OpenUrl(Url);
        }

        public void OpenUrl(string url) {
            Application.OpenURL(url);
            OnOpenUrl.Invoke(url);
        }
    }
}