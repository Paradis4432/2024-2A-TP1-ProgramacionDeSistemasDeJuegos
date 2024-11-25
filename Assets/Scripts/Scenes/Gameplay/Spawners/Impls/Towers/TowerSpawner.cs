using Scenes.Gameplay.Entities.Towers;
using Scenes.Gameplay.Factories;
using Tools;
using UnityEngine;

namespace Scenes.Gameplay.Spawners.Impls.Towers {
    public class TowerSpawner : AbstractSpawner {
        [SerializeField] private Vector.Range x;
        [SerializeField] private Vector.Range y;

        protected override void Run() {
            // set position between random of from to to
            Tower t = AbstractFactory<Tower>.GetFactory().Create();
            t.transform.position = new Vector3(
                Random.Range(x.min, x.max),
                Random.Range(y.min, y.max),
                transform.position.z
            );
        }
    }
}