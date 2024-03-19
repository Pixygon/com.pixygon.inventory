using Pixygon.Inventory;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Pixygon.Inventory {
    public class InventoryMenu : MonoBehaviour {
        [SerializeField] private InventoryMenuSlot[] _slots;
        [SerializeField] private Image _itemIcon;
        [SerializeField] private TextMeshProUGUI _itemPrice;
        [SerializeField] private TextMeshProUGUI _itemName;
        [SerializeField] private TextMeshProUGUI _itemDescription;
        private InventoryMenuSlot CurrentSlot => _slots[_currentSlot];
        private int _currentSlot;
        private Inventory _inventory;

        public void Populate(Inventory inventory) {
            gameObject.SetActive(true);
            ClearInventory();
            _inventory = inventory;
            RefreshInventory();
        }

        public void SwitchInventory() {
            //if (_inventory == _kuma.Inventory)
            //    _inventory = _kuma.RecipeInventory;
            //else
            //    _inventory = _kuma.Inventory;
            ClearInventory();
            RefreshInventory();
        }

        private void RefreshInventory() {
            if (_inventory.Slots == null) return;
            if (_inventory.Slots.Count == 0) return;
            for (var i = 0; i < _inventory.Slots.Count; i++) {
                _slots[i].Set(_inventory.Slots[i]);
            }

            _currentSlot = 0;
            CurrentSlot.Activate(true);
            SetTexts();
        }

        private void SetTexts() {
            if (CurrentSlot.Item == null) {
                _itemName.text = "";
                _itemPrice.text = "";
                _itemDescription.text = "";
                _itemIcon.sprite = null;
            }
            else {
                _itemName.text = CurrentSlot.Item._item.Title;
                _itemPrice.text = "x" + CurrentSlot.Item._quantity;
                _itemDescription.text = CurrentSlot.Item._item.Description;
                _itemIcon.sprite = CurrentSlot.Item._item.Icon;
            }
        }

        public void Move(int x, int y) {
            CurrentSlot.Activate(false);
            if (x == 1) {
                if (_currentSlot == 39) _currentSlot = 0;
                else _currentSlot += 1;
            }
            else if (x == -1) {
                if (_currentSlot == 0) _currentSlot = 39;
                else _currentSlot -= 1;
            }
            else if (y == -1) {
                if (_currentSlot >= 30) _currentSlot -= 30;
                else _currentSlot += 10;
            }
            else if (y == 1) {
                if (_currentSlot < 10) _currentSlot += 30;
                else _currentSlot -= 10;
            }

            CurrentSlot.Activate(true);
            SetTexts();
        }

        public void Select() {
            if (CurrentSlot.Item == null) return;
            switch (_slots[_currentSlot].Item._item.CategoryId) {
                case 0:
                    break;
                case 3:
                    break;
            }
        }

        public void ClearInventory() {
            for (var i = 0; i < _slots.Length; i++) {
                _slots[i].Set(null);
            }

            CurrentSlot.Activate(false);
            _currentSlot = 0;
            CurrentSlot.Activate(true);
            SetTexts();
        }

        public void Close() {
            gameObject.SetActive(false);
        }
    }
}