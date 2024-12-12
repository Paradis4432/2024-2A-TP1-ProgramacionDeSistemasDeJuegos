using System;
using Scenes.Gameplay.Strategies;

namespace Scenes.Gameplay.Structures.Wrappers.Impls {
    public class TowerShieldWrapper : IHealth, IWrapper {
        private readonly IHealth _original;

        public TowerShieldWrapper(IHealth original) {
            _original = original;
        }

        public event Action OnDeath;

        public int Hp {
            get => _original.Hp;
            set => _original.Hp = value;
        }

        public void UpdateHp(int v) {
            // ignore
        }

        public bool ShouldDie() {
            return false;
        }

        public IHealth Unwrap() {
            return _original;
        }
    }
}