using System;

namespace Pixygon.InventorySystem {
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