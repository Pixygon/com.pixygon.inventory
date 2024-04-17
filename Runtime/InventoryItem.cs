using Pixygon.ID;
using Pixygon.Skills;
using Pixygon.NFT;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Pixygon.InventorySystem {
    [CreateAssetMenu(fileName = "New InventoryItem", menuName = "Pixygon/New Inventory Item")]
    public class InventoryItem : IdObject {
        public string Title;
        public Sprite Icon;
        public AssetReference IconRef;
        public GameObject ItemPrefab;
        public int Price;
        public string Description;
        public bool HasEffect;
        public SkillData Effect;
        public float Chance;
        public int MaxAmount;

        public bool UniqueItem;
        public int CurrentDurability;
        public int MaxDurability;
        public float Weight;
        public string ExtraData;

        public bool GlobalItem;

        [InspectorButton("GetTemplate", ButtonWidth = 150), SerializeField] private bool GetTemplateInfo;
        public async void GetTemplate() {
            await NftData.GetTemplate();
#if UNITY_EDITOR
            UnityEditor.EditorUtility.SetDirty(this);
            UnityEditor.AssetDatabase.SaveAssets();
            UnityEditor.AssetDatabase.Refresh();
#endif
        }
        public NFTLink NftData;
    }
}