using Scenes.Gameplay.Entities.Enemies.Impls;

namespace Scenes.Prototypes.Impls {
    public interface IEnemyPrototype<out T> : IPrototype<T> where T : IPrototype<T> {
        
    }
}