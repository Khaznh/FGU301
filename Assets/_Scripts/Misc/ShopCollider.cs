using UnityEngine;

public class ShopCollider : MonoBehaviour
{
    private GameObject icon;

    private void Awake()
    {
        icon = transform.Find("Icon").gameObject;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            icon.SetActive(true);
            collision.GetComponent<Player>().onNearShop = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            icon.SetActive(false);
            collision.GetComponent<Player>().onNearShop = false;
        }
    }
}
