using System;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    public event Action<bool,Transform> OnNearPort;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pond"))
        {
            OnNearPort?.Invoke(true, collision.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pond"))
        {
            OnNearPort?.Invoke(false, null);
        }
    }
}
