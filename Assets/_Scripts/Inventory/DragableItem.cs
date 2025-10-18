using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class DragableItem : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public Transform parentAfter;
    public Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        parentAfter = this.transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(parentAfter);
        image.raycastTarget = true;
    }
}
