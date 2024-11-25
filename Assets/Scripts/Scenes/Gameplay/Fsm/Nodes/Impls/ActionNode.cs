using System;

namespace Scenes.Gameplay.Fsm.Nodes.Impls {
    public class ActionNode : INode {
        private readonly Action _action;

        public ActionNode(Action action) {
            _action = action;
        }

        public void Execute() {
            _action();
        }
    }
}