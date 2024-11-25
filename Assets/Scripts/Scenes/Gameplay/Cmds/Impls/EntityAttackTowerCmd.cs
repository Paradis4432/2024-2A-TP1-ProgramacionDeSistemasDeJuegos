using Scenes.Gameplay.Entities.Towers;
using Scenes.Gameplay.Strategies.Enemies;

namespace Scenes.Gameplay.Cmds.Impls {
    public class EntityAttackTowerCmd : ICmd {
        private readonly IEnemy _e;
        private readonly Tower _tower;

        public EntityAttackTowerCmd(IEnemy e, Tower tower) {
            _e = e;
            _tower = tower;
        }

        public void Execute() {
            if (!_tower.Shield)
            {
                _tower.Health.UpdateHp(-_e.GetDamage());
                if (_tower.Health.ShouldDie()) _tower.Die();
            }

            _e.Die();
        }
    }
}