using Scenes.Gameplay.Entities;
using UnityEngine;

namespace Scenes.Gameplay.Cmds.Impls {
    public class MoveCmd : ICmd {
        private readonly Vector3 _dir;
        private readonly AbstractEntity _t;
        private readonly float _s;

        public MoveCmd(Vector3 dir, AbstractEntity t, float s) {
            _dir = dir;
            _t = t;
            _s = s;
        }

        public void Execute() {
            _t.transform.position += _dir * (_s * Time.deltaTime);
        }
    }
}