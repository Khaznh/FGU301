using TMPro;
using UnityEngine;

public class PlayerMoney : MonoBehaviour
{
    public static PlayerMoney instance;
    public int currentMoney = 0;

    private TextMeshProUGUI moneyText;

    private void Awake()
    {
        moneyText = GameObject.Find("InventoryCanvas/PlayerCoin/CoinText").GetComponent<TextMeshProUGUI>();

        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moneyText.text = currentMoney.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddMoney(int amount)
    {
        currentMoney += amount;
        moneyText.text = currentMoney.ToString();
    }

    public void RemoveMoney(int amount)
    {
        currentMoney -= amount;

        if (currentMoney < 0)
        {
            currentMoney = 0;
        }

        moneyText.text = currentMoney.ToString();
    }
}
