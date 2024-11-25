using Scenes.Gameplay.Entities.Enemies;
using Scenes.Gameplay.Factories.Impls.Enemies;
using UnityEngine;

namespace Scenes.Gameplay.Pools.Enemies {
    public abstract class AbstractEnemyPool<T> : AbstractPool<AbstractEnemy<T>> {
        public override AbstractEnemy<T> GetObj() {
            if (Factory == null) Factory = AbstractEnemyFactory<T>.GetFactory();

            AbstractEnemy<T> e = Peek(typeof(T));
            if (e == null) e = Factory.Create();
            return e;
        }
    }
}