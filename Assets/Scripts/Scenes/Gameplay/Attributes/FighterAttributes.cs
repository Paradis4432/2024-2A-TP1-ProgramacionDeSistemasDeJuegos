using UnityEngine;

namespace Scenes.Gameplay.Attributes {
    [CreateAssetMenu(fileName = "FighterAttributes", menuName = "Attributes/Fighter", order = 0)]
    public class FighterAttributes : ScriptableObject {
        [field: SerializeField] public int MaxHp { get; set; }
        [field: SerializeField] public int Speed { get; set; }
        [field: SerializeField] public int Damage { get; set; }
    }
}