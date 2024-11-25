using System.Collections;
using Tools;
using UnityEngine;

namespace Scenes.Gameplay.Spawners {
    public abstract class AbstractSpawner : MonoBehaviour, IValidate {
        [SerializeField] private int spawnsPerPeriod = 1;
        [SerializeField] private float frequency = 1;
        [SerializeField] private float period;

        private void OnEnable() {
            if (frequency > 0) period = 1 / frequency;
        }

        private IEnumerator Start() {
            while (!destroyCancellationToken.IsCancellationRequested)
            {
                for (int i = 0; i < spawnsPerPeriod; i++) Run();

                yield return new WaitForSeconds(period);
            }
        }

        protected abstract void Run();
    }
}