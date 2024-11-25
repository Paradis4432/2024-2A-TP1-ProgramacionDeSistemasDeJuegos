using System;
using Scenes.Gameplay.Entities.Towers;
using Scenes.Prototypes;
using UnityEngine;

namespace Scenes.Gameplay.Factories.Impls.Towers {
    public class TowerFactory : AbstractFactory<Tower> {
        protected override Type GetType() {
            return typeof(Tower);
        }
    }
}