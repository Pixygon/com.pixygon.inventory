﻿using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Pixygon.InventorySystem {
    public class InventoryMenuSlotUGUI : MonoBehaviour {
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private Image _icon;
        [SerializeField] private GameObject _activeFrame;
        [SerializeField] private bool _alwaysShow;
        
        public InventorySlot Item { get; private set; }
        public void Set(InventorySlot item) {
            _text.text = "";
            _icon.sprite = null;
            if (item == null) {
                if (_alwaysShow)
                    _icon.gameObject.SetActive(false);
                else
                    gameObject.SetActive(false);
                return;
            }
            Item = item;
            _icon.gameObject.SetActive(true);
            gameObject.SetActive(true);
            _text.text = Item._quantity.ToString();
            _icon.sprite = Item._item.Icon;
        }

        public void Activate(bool active) {
            _activeFrame.SetActive(active);
        }
    }
}