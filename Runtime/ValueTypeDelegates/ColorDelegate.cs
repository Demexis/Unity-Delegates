using UnityEngine;
using UnityEngine.Events;

namespace Demegraunt.Framework {
    public sealed class ColorDelegate : MonoBehaviour {
        [field: SerializeField] public Color Color { get; set; } = Color.white;
        [field: SerializeField] public UnityEvent<Color> OnTrigger { get; set; } = new();

        public void SetR(float r) {
            Color = Color.SetR(r);
        }
        
        public void SetG(float g) {
            Color = Color.SetG(g);
        }
        
        public void SetB(float b) {
            Color = Color.SetB(b);
        }
        
        public void SetA(float a) {
            Color = Color.SetA(a);
        }
        
        public void SetHue(float hue) {
            Color = Color.SetHue(hue);
        }
        
        public void SetSaturation(float saturation) {
            Color = Color.SetSaturation(saturation);
        }
        
        public void SetValue(float value) {
            Color = Color.SetValue(value);
        }
        
        public void MultiplyR(float r) {
            Color = Color.MultiplyR(r);
        }
        
        public void MultiplyG(float g) {
            Color = Color.MultiplyG(g);
        }
        
        public void MultiplyB(float b) {
            Color = Color.MultiplyB(b);
        }
        
        public void MultiplyA(float a) {
            Color = Color.MultiplyA(a);
        }

        public void Multiply(Color color) {
            Color *= color;
        }

        public void Trigger() {
            Trigger(Color);
        }

        public void Trigger(Color color) {
            OnTrigger.Invoke(color);
        }
    }
}