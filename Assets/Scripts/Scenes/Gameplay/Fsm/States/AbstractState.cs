using System;
using System.Collections.Generic;
using Scenes.Gameplay.Strategies;

namespace Scenes.Gameplay.Fsm.States {
    public abstract class AbstractState : IState {
        private readonly Dictionary<Type, IState> _transitions = new();

        public abstract void Enter();
        public abstract void Execute();
        public abstract void Exit();

        public void Add(IState state) {
            Type type = state.GetType();
            if (_transitions.ContainsKey(type))
                throw new ArgumentException("state already registered");

            if (state.GetType() != type)
                throw new ArgumentException("type of state does not match instance");

            _transitions[type] = state;
        }

        public void Remove(Type input) {
            if (_transitions.ContainsKey(input)) _transitions.Remove(input);
        }

        public void Remove(IState state) {
            Remove(state.GetType());
        }

        public IState Get(Type input) {
            return _transitions.TryGetValue(input, out IState t) ? t : null;
        }

        public FSM SetFsm { get; set; }
    }
}