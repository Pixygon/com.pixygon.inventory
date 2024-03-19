using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Pixygon.Inventory {
    public class Inventory : MonoBehaviour {
        [SerializeField] private List<InventorySlot> _startInventory;
        public int MaxSize;
        public List<InventorySlot> Slots { get; private set; }

        private void Awake() {
            Slots = _startInventory;
        }
        public void AddItem(InventoryItem item, int quantity = 1) {
            Slots ??= new List<InventorySlot>();
            foreach (var i in Slots.Where(i => i._item == item)) {
                i._quantity += quantity;
                return;
            }
            Slots.Add(new InventorySlot(item, quantity));
        }
        public void RemoveItem(InventoryItem item, int quantity) {
            foreach (var i in Slots) {
                if (i._item != item) continue;
                i._quantity -= quantity;
                if (i._quantity <= 0)
                    Slots.Remove(i);
                return;
            }
        }
        public void RemoveItem(InventorySlot item) {
            foreach (var i in Slots) {
                if (i._item != item._item) continue;
                i._quantity -= item._quantity;
                if (i._quantity <= 0)
                    Slots.Remove(i);
                return;
            }
        }
        public bool CheckAvailability(InventoryItem item, int quantity = 1) {
            if (Slots == null) return false;
            foreach (var i in Slots) {
                if (i._item != item) continue;
                if (i._quantity < quantity) continue;
                return true;
            }
            return false;
        }
        public int GetAmount(InventorySlot item) {
            if (Slots == null) return 0;
            foreach (var i in Slots) {
                if (i._item != item._item) continue;
                return i._quantity;
            }
            return 0;
        }
        public bool CheckAvailability(InventorySlot item) {
            if (Slots == null) return false;
            foreach (var i in Slots) {
                if (i._item != item._item) continue;
                if (i._quantity < item._quantity) continue;
                return true;
            }
            return false;
        }
        public bool CheckAvailability(InventoryItem[] items) {
            if (items == null) return true;
            foreach (var i in items) {
                if (!CheckAvailability(i)) return false;
            }
            return true;
        }
        public bool CheckAvailability(InventorySlot[] items) {
            if (items == null) return true;
            foreach (var i in items) {
                if (!CheckAvailability(i)) return false;
            }
            return true;
        }
        public void ResetSlots(List<InventorySlot> slots) {
            Slots = slots;
        }

        public void Clear() {
            Slots = new List<InventorySlot>();
        }
    }

    [Serializable]
    public class InventorySlot {
        public InventoryItem _item;
        public int _quantity;

        public InventorySlot(InventoryItem item, int quantity) {
            _item = item;
            _quantity = quantity;
        }
    }
}