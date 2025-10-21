using UnityEngine;

public class HomeCollider : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //private void OnTrigger2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Player"))
    //    {
    //        PlayerMoney.instance.HealHealth();
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerMoney.instance.HealHealth();
        }
    }
}
