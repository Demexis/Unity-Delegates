using UnityEngine;
using UnityEngine.Events;

namespace Demegraunt.Framework {
    public sealed class AnimationCurvePlayerDelegate : MonoBehaviour {
        [field: SerializeField] public AnimationCurve AnimationCurve { get; set; } = new();
        [field: SerializeField] public bool IsPlaying { get; set; }
        [field: SerializeField] public bool IsLooping { get; set; }

        [field: SerializeField] public float CurveTime { get; set; } = 1f;
        [field: SerializeField] public float EvaluatedValueScale { get; set; } = 1f;

        [field: SerializeField] public UnityEvent<float> OnCurveEvaluated { get; set; } = new();

        public float CurveTimer { get; set; }

        public void Play() {
            IsPlaying = true;
        }

        public void Stop() {
            IsPlaying = false;
            CurveTimer = 0f;
        }

        public void Restart() {
            Stop();
            Play();
        }

        private void Update() {
            if (!IsPlaying) {
                return;
            }

            if (CurveTimer >= CurveTime) {
                if (!IsLooping) {
                    Stop();
                    return;
                }

                CurveTimer -= CurveTime;
            }

            CurveTimer += Time.deltaTime;

            var time = Mathf.Clamp(CurveTimer / CurveTime, 0f, AnimationCurve[AnimationCurve.length - 1].time);

            var evaluated = AnimationCurve.Evaluate(time) * EvaluatedValueScale;

            OnCurveEvaluated.Invoke(evaluated);
        }
    }
}