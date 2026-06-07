# Pixygon — Inventory

Item definitions, stacked slot storage, and a grid menu UI for Pixygon games.

## Overview

This package handles what a game keeps and carries. Items are authored as `InventoryItem` ScriptableObjects — each one an `IdObject` with price, durability, weight, an optional skill effect, and an NFT link — and held at runtime by an `Inventory` component that stacks them into quantity-tracked slots. A ready-made `InventoryMenu` renders the inventory as a navigable UGUI grid. It sits on top of `com.pixygon.skills` (items can fire `SkillData` effects) and the engine's ID/NFT layers.

## Key types

| Type | What it is |
| --- | --- |
| `InventoryItem` | ScriptableObject (`IdObject`) defining an item — title, icon, prefab, price, description, durability, weight, stack cap, optional `SkillData` effect, and `NFTLink`. Created via `Pixygon/New Inventory Item`. |
| `InventorySlot` | Serializable stack: one `InventoryItem`, a quantity, and an `_extraData` string. |
| `Inventory` | `MonoBehaviour` storing a `List<InventorySlot>` — add, remove, availability checks, amounts, reset, and clear. |
| `InventoryMenu` | `MonoBehaviour` UGUI controller — populates a slot grid, moves a cursor, and shows the selected item's icon/name/price/description. |
| `InventoryMenuSlotUGUI` | `MonoBehaviour` for a single menu cell — binds an `InventorySlot` to icon + quantity text and toggles the active frame. |

## How games use it

1. Author items as `InventoryItem` assets (`Assets > Create > Pixygon > New Inventory Item`).
2. Add an `Inventory` component to the actor that carries items; optionally seed `_startInventory`.
3. Mutate it from gameplay code:

```csharp
inventory.AddItem(potion, 3);
if (inventory.CheckAvailability(potion, 1))
    inventory.RemoveItem(potion, 1);

int held = inventory.GetAmount(new InventorySlot(potion, 1));
```

4. To show it, call `inventoryMenu.Populate(inventory)`, then drive the cursor with `Move(x, y)` and `Select()`.

## Dependencies

- `com.pixygon.skills` — supplies `SkillData`, the effect an item triggers when used.

## Install

```json
"com.pixygon.inventory": "https://github.com/Pixygon/com.pixygon.inventory.git"
```
```

Note: I attempted to write this to `README.md` but the write permission wasn't granted, so I've output it to stdout as the prompt also specified. Let me know if you'd like me to write the file.
