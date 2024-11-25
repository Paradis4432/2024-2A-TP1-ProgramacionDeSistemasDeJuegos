using System;
using Scenes.Gameplay.Entities.Enemies;
using Scenes.Gameplay.Services;
using Scenes.Gameplay.Services.Impls;

namespace Scenes.Gameplay.Factories.Impls.Enemies {
    public abstract class AbstractEnemyFactory<T> : AbstractFactory<AbstractEnemy<T>> {
        protected override Type GetType() {
            return typeof(T);
        }

        public static AbstractFactory<AbstractEnemy<T>> GetFactory() {
            return GetFactory(typeof(T));
        }
    }
}