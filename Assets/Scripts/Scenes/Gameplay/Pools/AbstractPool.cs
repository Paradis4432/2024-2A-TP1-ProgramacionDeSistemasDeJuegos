using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Scenes.Gameplay.Factories;
using Scenes.Prototypes;
using Tools;
using Tools.Attributes;
using UnityEngine;

namespace Scenes.Gameplay.Pools {
    public abstract class AbstractPool<TV> : MonoBehaviour, IValidate where TV : MonoBehaviour, IPrototype<TV> {
        private static readonly Dictionary<Type, List<TV>> Pool = new();

        [Ignore] protected AbstractFactory<TV> Factory;

        [CanBeNull]
        protected TV Peek(Type k) {
            if (!Pool.TryGetValue(k, out List<TV> vs) || vs.Count == 0) return null;

            TV v = vs[0];
            vs.RemoveAt(0);
            return v;
        }

        public static void Save(TV v) {
            if (Pool.TryGetValue(v.GetType(), out List<TV> vs)) vs.Add(v);
            else Pool.Add(v.GetType(), new List<TV> { v });
        }

        public static void Clear() {
            Pool.Clear();
        }

        public static void Clear(Type k) {
            if (Pool.TryGetValue(k, out List<TV> vs)) vs.Clear();
        }

        public abstract TV GetObj();
    }
}