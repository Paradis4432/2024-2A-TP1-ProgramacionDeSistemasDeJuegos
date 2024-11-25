using UnityEngine;

namespace Scenes.Gameplay.Attributes {
    [CreateAssetMenu(fileName = "TowerAttributes", menuName = "Attributes/Tower", order = 0)]
    public class TowerAttributes : ScriptableObject {
        [field: SerializeField] public int MaxHp { get; set; }
    }
}