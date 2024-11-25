using System;
using UnityEngine;

namespace Tools {
    public abstract class Vector {
        [Serializable]
        public struct Range
        {
            public float min;
            public float max;
        }
        
        public static float Distance2d(Vector3 a, Vector3 b) {
            float num1 = a.x - b.x;
            float num3 = a.y - b.y;
            return (float)Math.Sqrt(num1 * (double)num1 + num3 * (double)num3);
        }

        public static Vector3 GetDirection(Vector3 a, Vector3 b) {
            return (b - a).normalized;
        }
    }
}