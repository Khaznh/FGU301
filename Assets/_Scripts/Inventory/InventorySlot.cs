using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public Image image;

    public void Awake()
    {
        image = GetComponent<Image>();
        Unselected();
    }

    public void Selected()
    {
        image.color = new Color(1f, 1f, 1f, 1f);
    }

    public void Unselected()
    {
        image.color = new Color(1f, 1f, 1f, 0f);
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount != 0)
        {
            return;
        }

        GameObject dropped = eventData.pointerDrag;
        DragableItem dragableItem = dropped.GetComponent<DragableItem>();
        dragableItem.parentAfter = transform;
    }
}
