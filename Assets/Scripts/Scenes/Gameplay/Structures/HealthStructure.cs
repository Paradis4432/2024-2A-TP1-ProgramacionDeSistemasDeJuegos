using System;
using Scenes.Gameplay.Strategies;

namespace Scenes.Gameplay.Structures {
    public class HealthStructure : IHealth {
        public event Action OnDeath = delegate { };
        public int Hp { get; set; }

        public void UpdateHp(int v) {
            Hp += v;
        }

        public bool ShouldDie() {
            return Hp <= 0;
        }
    }
}