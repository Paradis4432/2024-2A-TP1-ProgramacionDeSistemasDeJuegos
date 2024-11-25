using System;

namespace Scenes.Gameplay.Strategies {
    public interface IHealth {
        public event Action OnDeath;

        public int Hp { get; set; }

        void UpdateHp(int v);

        bool ShouldDie();
    }
}