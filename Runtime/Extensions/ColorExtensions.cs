using System.Diagnostics.Contracts;
using UnityEngine;

namespace Demegraunt.Framework {
    public static class ColorExtensions {
        [Pure]
        public static Color SetR(this Color color, float r) {
            return new Color(r, color.g, color.b, color.a);
        }

        [Pure]
        public static Color SetG(this Color color, float g) {
            return new Color(color.r, g, color.b, color.a);
        }

        [Pure]
        public static Color SetB(this Color color, float b) {
            return new Color(color.r, color.g, b, color.a);
        }

        [Pure]
        public static Color SetA(this Color color, float a) {
            return new Color(color.r, color.g, color.b, a);
        }
        
        [Pure]
        public static Color MultiplyR(this Color color, float r) {
            return new Color(color.r * r, color.g, color.b, color.a);
        }
        
        [Pure]
        public static Color MultiplyG(this Color color, float g) {
            return new Color(color.r, color.g * g, color.b, color.a);
        }

        [Pure]
        public static Color MultiplyB(this Color color, float b) {
            return new Color(color.r, color.g, color.b * b, color.a);
        }

        [Pure]
        public static Color MultiplyA(this Color color, float a) {
            return new Color(color.r, color.g, color.b, color.a * a);
        }
        
        [Pure]
        public static Color SetHue(this Color color, float hue) {
            Color.RGBToHSV(color, out _, out var s, out var v);
            return Color.HSVToRGB(hue, s, v);
        }
        
        [Pure]
        public static Color SetSaturation(this Color color, float saturation) {
            Color.RGBToHSV(color, out var h, out _, out var v);
            return Color.HSVToRGB(h, saturation, v);
        }
        
        [Pure]
        public static Color SetValue(this Color color, float value) {
            Color.RGBToHSV(color, out var h, out var s, out _);
            return Color.HSVToRGB(h, s, value);
        }
    }
}