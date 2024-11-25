using Scenes.Gameplay.Cmds;
using Scenes.Gameplay.Cmds.Impls;
using Scenes.Gameplay.Repositories.Impls;
using Tools;

namespace Scenes.Gameplay.Entities.Enemies.Impls {
    public class Fighter : AbstractEnemy<Fighter> {
        private void Update() {
            // find a tower, get close, explode, destroy tower
            if (Target == null)
            {
                FindTarget();
                return;
            }

            CmdManager.EnqueueCmd(new MoveCmd(
                Vector.GetDirection(transform.position, Target.transform.position),
                this,
                attributes.Speed)
            );
        }

        private void FindTarget() {
            AbstractTowerRepository.GetNearestTowerOf(transform).IfPresent(t => { Target = t; });
        }
    }
}