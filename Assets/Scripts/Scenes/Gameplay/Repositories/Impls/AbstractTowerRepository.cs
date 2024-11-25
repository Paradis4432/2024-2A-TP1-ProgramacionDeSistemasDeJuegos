using Scenes.Gameplay.Entities.Towers;
using Tools;
using UnityEngine;

namespace Scenes.Gameplay.Repositories.Impls {
    public abstract class AbstractTowerRepository : AbstractRepository<Tower> {
        public static Optional<Tower> GetNearestTowerOf(Transform pos) {
            Tower cs = null;
            float cds = Mathf.Infinity;

            foreach (Tower element in Elements)
            {
                float d = Vector.Distance2d(pos.position, element.transform.position);
                if (!(d < cds)) continue;
                cs = element;
                cds = d;
            }

            return Optional<Tower>.OfNullable(cs);
        }
    }
}