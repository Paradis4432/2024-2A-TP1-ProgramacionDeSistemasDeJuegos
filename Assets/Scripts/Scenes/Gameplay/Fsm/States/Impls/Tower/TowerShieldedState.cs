using UnityEngine;

namespace Scenes.Gameplay.Fsm.States.Impls.Tower {
    public class TowerShieldedState : AbstractState {
        private readonly Entities.Towers.Tower _tower;

        public TowerShieldedState(Entities.Towers.Tower tower) {
            _tower = tower;
        }

        public override void Enter() {
            _tower.GetComponent<Renderer>().material.color = Color.blue;
        }

        public override void Execute() {
        }

        public override void Exit() {
        }
    }
}