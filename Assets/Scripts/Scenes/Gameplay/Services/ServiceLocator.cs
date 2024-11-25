using System;
using System.Collections.Generic;
using Scenes.Gameplay.Strategies;
using Tools;
using UnityEngine;

namespace Scenes.Gameplay.Services {
    public class ServiceLocator : MonoBehaviour, IValidate {
        private static readonly Dictionary<Type, IService> Services = new();

        private void Awake() {
            foreach (Type t in Reflection.GetImpls(typeof(IService))) RegisterService(t, (IService)FindObjectOfType(t));
        }

        private static void RegisterService(Type t, IService s) {
            if (Services.ContainsKey(t))
            {
                Debug.LogError("tried to register a service that's already registered: " + t.Name);
                return;
            }

            Debug.Log("self registering service: " + t.Name);
            Services.Add(t, s);
        }

        public static T GetService<T>() where T : IService {
            if (Services.TryGetValue(typeof(T), out IService s)) return (T)s;
            throw new ArgumentNullException("type: " + typeof(T).Name + " not found in registered services");
        }
    }
}