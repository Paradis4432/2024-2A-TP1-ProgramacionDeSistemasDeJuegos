using Scenes.Gameplay.Strategies;
using Scenes.Gameplay.Structures;
using UnityEngine;

namespace Scenes.Gameplay.Entities {
    public abstract class AbstractEntity : MonoBehaviour, IEntity {
        public IHealth Health { get; protected set; }

        private void Awake() {
            Health ??= new HealthStructure();
        }

        public abstract void Die();
    }
}