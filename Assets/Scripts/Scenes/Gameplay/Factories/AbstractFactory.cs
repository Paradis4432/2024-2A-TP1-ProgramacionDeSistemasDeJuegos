using System;
using System.Collections.Generic;
using Scenes.Gameplay.Services;
using Scenes.Gameplay.Services.Impls;
using Scenes.Prototypes;
using Tools;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Scenes.Gameplay.Factories 
{
    public abstract class AbstractFactory<T> : MonoBehaviour, IValidate where T : Object, IPrototype<T> {
        private static readonly Dictionary<Type, AbstractFactory<T>> Factories = new();

        private T _t;

        public static AbstractFactory<T> GetFactory(Type t = default) {
            t ??= typeof(T);
            if (Factories.TryGetValue(t, out AbstractFactory<T> factory)) return factory;

            throw new NullReferenceException("invalid type t: " + t.Name);
        }

        public T Create() {
            return Instantiate(_t);
        }

        private void Start() {
            if (Factories.ContainsKey(GetType()))
            {
                Debug.LogError("factory: " + GetType().Name + " already registered!");
                return;
            }

            Factories.Add(GetType(), this);

            _t = ServiceLocator.GetService<PrefabService>().Find<T>();
        }

        protected new abstract Type GetType();
    }
}
