using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class DragableItem : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public Transform parentAfter;
    public Image image;
    public TextMeshProUGUI text;

    public int count = 1;
    public Item item;

    private LayoutElement layout;

    public void InitItem(Item newItem)
    {
        item = newItem;
        image = GetComponent<Image>();
        layout = GetComponent<LayoutElement>();
        text = GetComponentInChildren<TextMeshProUGUI>();
        image.sprite = newItem.fishImg;
        RefreshCount();
    }

    public void RefreshCount()
    {
        text.text = count.ToString();
        bool isActive = count > 1;
        text.gameObject.SetActive(isActive);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        parentAfter = this.transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        image.raycastTarget = false;
        text.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(parentAfter);
        image.raycastTarget = true;
        text.raycastTarget = true;
    }
}
