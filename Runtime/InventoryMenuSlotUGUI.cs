using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Pixygon.InventorySystem {
    public class InventoryMenuSlot : MonoBehaviour {
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private Image _icon;
        [SerializeField] private GameObject _activeFrame;
        
        public InventorySlot Item { get; private set; }
        public void Set(InventorySlot item) {
            if (item == null) {
                gameObject.SetActive(false);
                return;
            }
            _text.text = "";
            _icon.sprite = null;
            Item = item;
            gameObject.SetActive(true);
            _text.text = Item._quantity.ToString();
            _icon.sprite = Item._item.Icon;
        }

        public void Activate(bool active) {
            _activeFrame.SetActive(active);
        }
    }
}