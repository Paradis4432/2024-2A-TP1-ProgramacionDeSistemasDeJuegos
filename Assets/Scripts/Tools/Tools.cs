using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Tools.Attributes;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Tools {
    public class FieldValidator : MonoBehaviour {
        private void Awake() {
            foreach (MonoBehaviour m in FindObjectsOfType<MonoBehaviour>()) Validate(m);
        }

        private static void Validate(MonoBehaviour m) {
            Type ct = m.GetType();

            Type[] ints = ct.GetInterfaces();
            if (!ints.Contains(typeof(IValidate))) return;

            Reflection.ForEachFieldIn(m, (o, f) => {
                if (o == null || (o is Object obj && obj == null))
                    Debug.LogError($"Field '{f.Name}' in '{ct.Name}' is null.");
                return false;
            });
        }
    }

    public static class Reflection {
        public static void ForEachFieldIn(MonoBehaviour m, Func<object, FieldInfo, bool> a, BindingFlags fs =
            BindingFlags.Instance |
            BindingFlags.Public |
            BindingFlags.NonPublic) {
            foreach (FieldInfo f in m.GetType().GetFields(fs))
            {
                if (Attribute.IsDefined(f, typeof(IgnoreAttribute))) continue;
                if (a.Invoke(f.GetValue(m), f)) break;
            }
        }

        public static IEnumerable<Type> GetImpls(Type type) {
            return Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => type.IsAssignableFrom(t) && t.IsClass && !t.IsAbstract);
        }
    }

    public interface IValidate {
    }
}