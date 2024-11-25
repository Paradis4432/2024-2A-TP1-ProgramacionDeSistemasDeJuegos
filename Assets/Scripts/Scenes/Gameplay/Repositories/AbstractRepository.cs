using System.Collections.Generic;
using UnityEngine;

namespace Scenes.Gameplay.Repositories {
    public abstract class AbstractRepository<T> {
        protected static readonly HashSet<T> Elements = new();

        public static void Register(T t) {
            Elements.Add(t);
        }

        public static void Unregister(T t) {
            Elements.Remove(t);
        }
    }
}