using Pixygon.ID;
using Pixygon.Skills;
using UnityEngine;

namespace Pixygon.InventorySystem {
    [CreateAssetMenu(fileName = "New InventoryItem", menuName = "Pixygon/New Inventory Item")]
    public class InventoryItem : IdObject {
        public string Title;
        public Sprite Icon;
        public int Price;
        public string Description;
        public bool HasEffect;
        public SkillData Effect;
    }
}