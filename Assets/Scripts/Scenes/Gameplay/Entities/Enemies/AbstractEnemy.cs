using Scenes.Gameplay.Attributes;
using Scenes.Gameplay.Entities.Towers;
using Scenes.Gameplay.Factories.Impls.Enemies;
using Scenes.Gameplay.Pools.Enemies;
using Scenes.Gameplay.Strategies;
using Scenes.Gameplay.Strategies.Enemies;
using Scenes.Prototypes.Impls;
using Tools.Attributes;
using UnityEngine;

namespace Scenes.Gameplay.Entities.Enemies {
    public abstract class AbstractEnemy<T> : AbstractEntity, IEnemy, IEnemyPrototype<AbstractEnemy<T>>, IRenewable {
        [SerializeField] protected FighterAttributes attributes;

        [Ignore] protected Tower Target;

        private void Start() {
            Health.Hp = attributes.MaxHp;
            Health.OnDeath += Die;
        }

        public override void Die() {
            AbstractEnemyPool<T>.Save(this);
            gameObject.SetActive(false);
        }

        public int GetDamage() {
            return attributes.Damage;
        }

        public virtual AbstractEnemy<T> Clone() {
            return AbstractEnemyFactory<T>.GetFactory().Create();
        }

        public void Renew(Vector3 pos) {
            gameObject.SetActive(true);
            transform.position = pos;
            Target = null;
        }
    }
}