using UnityEngine;

namespace Scenes.Prototypes {
    public interface IPrototype<out T> where T : IPrototype<T> {
        T Clone();
    }
}