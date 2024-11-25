using System;
using Scenes.Gameplay.Fsm;

namespace Scenes.Gameplay.Strategies {
    public interface IState {
        void Enter();
        void Execute();
        void Exit();
        void Add(IState state);
        void Remove(Type input);
        void Remove(IState state);
        IState Get(Type input);
        FSM SetFsm { get; set; }
    }
}