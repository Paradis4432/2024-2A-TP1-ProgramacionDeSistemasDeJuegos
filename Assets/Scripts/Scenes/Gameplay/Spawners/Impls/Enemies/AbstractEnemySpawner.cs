using Scenes.Gameplay.Pools.Enemies;
using Scenes.Gameplay.Strategies.Enemies;
using UnityEngine;

namespace Scenes.Gameplay.Spawners.Impls.Enemies {
    public abstract class AbstractEnemySpawner<T> : AbstractSpawner where T : IEnemy {
        [SerializeField] private AbstractEnemyPool<T> pool;

        protected override void Run() {
            // dont really care if inst came from pool or factory, renew either way
            pool.GetObj().Renew(transform.position);
        }
    }
}