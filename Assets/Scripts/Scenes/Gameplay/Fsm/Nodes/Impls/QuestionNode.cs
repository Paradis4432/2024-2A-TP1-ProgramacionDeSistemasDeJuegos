using System;

namespace Scenes.Gameplay.Fsm.Nodes.Impls {
    public class QuestionNode : INode {
        private readonly Func<bool> _q;
        private readonly INode _onValid;
        private readonly INode _onInvalid;

        public QuestionNode(Func<bool> q, INode onValid, INode onInvalid) {
            _q = q;
            _onValid = onValid;
            _onInvalid = onInvalid;
        }

        public void Execute() {
            if (_q()) _onValid.Execute();
            else _onInvalid.Execute();
        }
    }
}