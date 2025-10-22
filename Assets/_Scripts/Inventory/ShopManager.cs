using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public void SellAtlanticBass()
    {
        Debug.Log("1 clicked!");
        if (InventoryManager.instance.DeleteItem("AtlanticBass"))
        {
            PlayerMoney.instance.AddMoney(10);
        }
        AudioManager.Instance.PlaySFX("Buy");
    }

    public void SellAxolotl()
    {
        Debug.Log("2 clicked!");
        if (InventoryManager.instance.DeleteItem("Axolotl"))
        {
            PlayerMoney.instance.AddMoney(25);
        }
        AudioManager.Instance.PlaySFX("Buy");
    }

    public void SellBandedShark()
    {
        Debug.Log("3 clicked!");
        if (InventoryManager.instance.DeleteItem("BandedShark"))
        {
            PlayerMoney.instance.AddMoney(25);
        }
        AudioManager.Instance.PlaySFX("Buy");
    }

    public void SellBlueGill()
    {
        Debug.Log("4 clicked!");
        if (InventoryManager.instance.DeleteItem("BlueGill"))
        {
            PlayerMoney.instance.AddMoney(50);
        }
        AudioManager.Instance.PlaySFX("Buy");
    }

    public void SellClownfish()
    {
        Debug.Log("5 clicked!");
        if (InventoryManager.instance.DeleteItem("Clownfish"))
        {
            PlayerMoney.instance.AddMoney(75);
        }
        AudioManager.Instance.PlaySFX("Buy");
    }

    public void SellDab()
    {
        Debug.Log("6 clicked!");
        if (InventoryManager.instance.DeleteItem("Dab"))
        {
            PlayerMoney.instance.AddMoney(50);
        }
        AudioManager.Instance.PlaySFX("Buy");
    }

    public void SellFreshwaterSnail()
    {
        Debug.Log("7 clicked!");
        if (InventoryManager.instance.DeleteItem("FreshwaterSnail"))
        {
            PlayerMoney.instance.AddMoney(25);
        }
        AudioManager.Instance.PlaySFX("Buy");
    }

    public void SellGoldenTench()
    {
        Debug.Log("8 clicked!");
        if (InventoryManager.instance.DeleteItem("GoldenTench"))
        {
            PlayerMoney.instance.AddMoney(30);
        }
        AudioManager.Instance.PlaySFX("Buy");
    }

    public void SellGuppy()
    {
        Debug.Log("9 clicked!");
        if (InventoryManager.instance.DeleteItem("Guppy"))
        {
            PlayerMoney.instance.AddMoney(20);
        }
        AudioManager.Instance.PlaySFX("Buy");
    }

    public void SellMossBall()
    {
        Debug.Log("10 clicked!");
        if (InventoryManager.instance.DeleteItem("MossBall"))
        {
            PlayerMoney.instance.AddMoney(1);
        }
        AudioManager.Instance.PlaySFX("Buy");
    }

    public void SellSeaSpider()
    {
        Debug.Log("11 clicked!");
        if (InventoryManager.instance.DeleteItem("SeaSpider"))
        {
            PlayerMoney.instance.AddMoney(10);
        }
        AudioManager.Instance.PlaySFX("Buy");
    }
}
