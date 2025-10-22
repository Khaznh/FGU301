using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public GameObject mapManagerPrefab; 
    private GameObject mapManagerInstance;
    public void UpgrateStatama()
    {
        if (PlayerMoney.instance.currentMoney >= 50)
        {
            PlayerMoney.instance.RemoveMoney(50);
            PlayerMoney.instance.maxHealth += 5;
            HealthBar.instance.SetMaxHealth(PlayerMoney.instance.maxHealth);
            PlayerMoney.instance.currentHealth = PlayerMoney.instance.maxHealth;
            HealthBar.instance.SetCurrentHealth(PlayerMoney.instance.currentHealth);
        }
    }

    public void UpgradeMoveBarSpeed()
    {
        if (PlayerMoney.instance.currentMoney >= 10)
        {
            PlayerMoney.instance.RemoveMoney(10);
            Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            player.moveBarSpeed += 10f;
        }
    }

    public void BuyMap()
    {
        if (PlayerMoney.instance.currentMoney >= 100)
        {
            if (mapManagerInstance == null)
            {
                mapManagerInstance = Instantiate(mapManagerPrefab);
            }
            else
            {
                mapManagerInstance.SetActive(true);
            }

            AudioManager.Instance.PlaySFX("Buy");
        }
    }
}
