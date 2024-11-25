using System.Collections.Generic;
using Tools;
using UnityEngine;

namespace Scenes.Gameplay.Cmds {
    public class CmdManager : MonoBehaviour, IValidate {
        private static readonly Queue<ICmd> CmdQueue = new();

        public static void EnqueueCmd(ICmd c) {
            CmdQueue.Enqueue(c);
        }

        private void Update() {
            while (CmdQueue.Count > 0) CmdQueue.Dequeue().Execute();
        }
    }
}