using UnityEngine;

namespace Scenes.Gameplay.Fsm.States.Impls.Tower {
    public class TowerChillState : AbstractState {
        private readonly Entities.Towers.Tower _tower;

        public TowerChillState(Entities.Towers.Tower tower) {
            _tower = tower;
        }

        public override void Enter() {
            _tower.GetComponent<Renderer>().material.color = Color.white;
        }

        public override void Execute() {
        }

        public override void Exit() {
        }
    }
}