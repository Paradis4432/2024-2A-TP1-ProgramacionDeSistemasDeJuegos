using System.Collections;
using Scenes.Gameplay.Attributes;
using Scenes.Gameplay.Cmds;
using Scenes.Gameplay.Cmds.Impls;
using Scenes.Gameplay.Factories;
using Scenes.Gameplay.Fsm;
using Scenes.Gameplay.Fsm.Nodes;
using Scenes.Gameplay.Fsm.Nodes.Impls;
using Scenes.Gameplay.Fsm.States.Impls.Tower;
using Scenes.Gameplay.Repositories.Impls;
using Scenes.Gameplay.Strategies.Enemies;
using Scenes.Gameplay.Strategies.Towers;
using Scenes.Prototypes;
using UnityEngine;

namespace Scenes.Gameplay.Entities.Towers {
    public class Tower : AbstractEntity, ITower, IPrototype<Tower> {
        [SerializeField] private TowerAttributes attributes;

        private readonly FSM _fsm = new();

        private INode FsmNodes { get; set; }

        [field: SerializeField] public bool Shield { get; private set; }

        private void Start() {
            Health.Hp = attributes.MaxHp;
            Health.OnDeath += Die;

            AbstractTowerRepository.Register(this);

            PrepareFsm();
        }

        public override void Die() {
            Destroy(gameObject);
        }

        public Tower Clone() {
            return AbstractFactory<Tower>.GetFactory().Create();
        }

        private void OnDestroy() {
            AbstractTowerRepository.Unregister(this);
        }

        private void OnTriggerEnter2D(Collider2D other) {
            if (!other.gameObject.TryGetComponent(out IEnemy e)) return;

            CmdManager.EnqueueCmd(new EntityAttackTowerCmd(e, this));
        }

        public void ShieldFor(float s) {
            StartCoroutine(ShieldTimer(s));
        }

        private void SetShielded(bool s) {
            Shield = s;
        }

        private void Update() {
            FsmNodes.Execute();
            _fsm.UpdateFsm();
        }

        // TODO move this to some scheduler helper class, stupid unity
        private IEnumerator ShieldTimer(float d) {
            SetShielded(true);
            yield return new WaitForSeconds(d);
            SetShielded(false);
        }

        private void PrepareFsm() {
            TowerChillState towerChillState = new(this);
            TowerShieldedState towerShieldedState = new(this);

            towerChillState.Add(towerShieldedState);
            towerShieldedState.Add(towerChillState);

            _fsm.SetState(towerChillState);

            FsmNodes = new QuestionNode(() => Shield,
                new ActionNode(() =>
                    _fsm.Transition(towerShieldedState.GetType())),
                new ActionNode(() =>
                    _fsm.Transition(towerChillState.GetType())));
        }
    }
}