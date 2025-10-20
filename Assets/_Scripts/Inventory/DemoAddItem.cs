using UnityEngine;

public class DemoAddItem : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public Item[] itemToAdd;

    public void AddItem(int id)
    {
        if (inventoryManager.AddItem(itemToAdd[id]))
        {
            Debug.Log("Item Added: " + itemToAdd[id].name);
        }
        else
        {
            Debug.Log("Inventory Full. Cannot add item: " + itemToAdd[id].name);
        }
    }
}
