using TMPro;
using UnityEngine;

public class PlayerMoney : MonoBehaviour
{
    public static PlayerMoney instance;
    public int currentMoney = 0;
    public int maxHealth = 10;
    public int currentHealth;

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

        currentHealth = maxHealth;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moneyText.text = currentMoney.ToString();
        HealthBar.instance.SetMaxHealth(maxHealth);
        HealthBar.instance.SetCurrentHealth(maxHealth);
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

    public void IncreaseMaxHealth(int amount)
    {
        maxHealth += amount;
        HealthBar.instance.IncreaseMaxHealth(amount);
    }

    public void HealHealth()
    {
        currentHealth = maxHealth;
        HealthBar.instance.SetCurrentHealth(currentHealth);
    }

    public void ReduceHealth(int amount)
    {
        currentHealth -= amount;
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
        HealthBar.instance.SetCurrentHealth(currentHealth);
    }
}
