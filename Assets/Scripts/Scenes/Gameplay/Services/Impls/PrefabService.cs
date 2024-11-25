using System;
using System.Collections.Generic;
using Scenes.Gameplay.Entities.Enemies;
using Scenes.Gameplay.Entities.Enemies.Impls;
using Scenes.Gameplay.Entities.Towers;
using Scenes.Gameplay.Strategies;
using Tools;
using Tools.Attributes;
using UnityEngine;

namespace Scenes.Gameplay.Services.Impls {
    public class PrefabService : MonoBehaviour, IService {
        [field: SerializeField] public AbstractEnemy<Fighter> Fighter { get; set; }

        [field: SerializeField] public Tower Tower { get; set; }

        public T Find<T>() where T : class {
            T t = null;
            Reflection.ForEachFieldIn(this, (o, fi) => {
                if (o == null)
                {
                    Debug.LogError("failed to index object with field info: " + fi);
                    return true;
                }

                if (o is not T find) return false;
                t = find;
                return true;
            });

            return t;
        }
    }
}