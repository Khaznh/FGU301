using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public InventorySlot[] inventorySlots;
    public GameObject invenItemPrefaps;
    public int limitCount = 99;

    private int selectedSlotIndex = 0;

    private void Start()
    {
        ChangeSelectSlot(0);
    }

    private void Update()
    {
        if (Input.inputString != null)
        {
            bool isNumber = int.TryParse(Input.inputString, out int number);
            if (isNumber && number > 0 && number < 10)
            {
                ChangeSelectSlot(number - 1);
            }
        }
    }

    public void ChangeSelectSlot(int newValue)
    {
        inventorySlots[selectedSlotIndex].Unselected();

        inventorySlots[newValue].Selected();
        selectedSlotIndex = newValue;
    }

    public bool AddItem(Item item)
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            DragableItem existingItem = slot.GetComponentInChildren<DragableItem>();
            if (existingItem != null && existingItem.item == item && existingItem.count < limitCount && existingItem.item.canStack == true)
            {
                existingItem.count++;
                existingItem.RefreshCount();
                return true;
            }
        }

        for (int i = 0 ; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            DragableItem existingItem = slot.GetComponentInChildren<DragableItem>();
            if (existingItem == null)
            {
                SpawnNewItem(item, slot);
                return true;
            }
        }

        return false;
    }

    public void SpawnNewItem(Item item, InventorySlot inventorySlot)
    {
        GameObject newItem = Instantiate(invenItemPrefaps, inventorySlot.transform);
        DragableItem dragableItem = newItem.GetComponent<DragableItem>();
        dragableItem.InitItem(item);
    }
}
