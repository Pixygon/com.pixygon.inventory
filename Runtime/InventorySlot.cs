using System;

namespace Pixygon.InventorySystem {
    [Serializable]
    public class InventorySlot {
        public InventoryItem _item;
        public int _quantity;
        public string _extraData;

        public InventorySlot(InventoryItem item, int quantity, string data = "") {
            _item = item;
            _quantity = quantity;
            _extraData = data;
        }
    }
}