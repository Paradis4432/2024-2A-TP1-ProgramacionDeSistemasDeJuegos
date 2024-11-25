using System;
using Scenes.Gameplay.Fsm.States;
using Scenes.Gameplay.Fsm.States.Impls.Tower;
using Scenes.Gameplay.Strategies;

namespace Scenes.Gameplay.Fsm {
    public class FSM {
        private IState _state;

        public void UpdateFsm() {
            _state?.Execute();
        }

        public void Transition(Type t) {
            IState s = _state.Get(t);
            if (s == null) return;
            _state.Exit();
            SetState(s);
        }

        public void SetState(IState s) {
            _state = s;
            s.SetFsm = this;
            _state.Enter();
        }
    }
}