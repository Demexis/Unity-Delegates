using UnityEngine;
using UnityEngine.Events;

namespace Demegraunt.Framework {
    public sealed class GradientPlayerDelegate : MonoBehaviour {
        [field: SerializeField] public Gradient Gradient { get; set; } = new();
        [field: SerializeField] public bool IsPlaying { get; set; }
        [field: SerializeField] public bool IsLooping { get; set; }

        [field: SerializeField] public float GradientTime { get; set; } = 1f;

        [field: SerializeField] public UnityEvent<Color> OnGradientEvaluated { get; set; } = new();

        public float GradientTimer { get; set; }

        public void Play() {
            IsPlaying = true;
        }

        public void Stop() {
            IsPlaying = false;
            GradientTimer = 0f;
        }

        public void Restart() {
            Stop();
            Play();
        }

        private void Update() {
            if (!IsPlaying) {
                return;
            }

            if (GradientTimer >= GradientTime) {
                if (!IsLooping) {
                    Stop();
                    return;
                }

                GradientTimer -= GradientTime;
            }

            GradientTimer += Time.deltaTime;

            var time = Mathf.Clamp01(GradientTimer / GradientTime);

            var evaluated = Gradient.Evaluate(time);

            OnGradientEvaluated.Invoke(evaluated);
        }
    }
}