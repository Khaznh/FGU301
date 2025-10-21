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
    }

    public void SellAxolotl()
    {
        Debug.Log("2 clicked!");
        if (InventoryManager.instance.DeleteItem("Axolotl"))
        {
            PlayerMoney.instance.AddMoney(25);
        }
    }

    public void SellBandedShark()
    {
        Debug.Log("3 clicked!");
        if (InventoryManager.instance.DeleteItem("BandedShark"))
        {
            PlayerMoney.instance.AddMoney(25);
        }
    }

    public void SellBlueGill()
    {
        Debug.Log("4 clicked!");
        if (InventoryManager.instance.DeleteItem("BlueGill"))
        {
            PlayerMoney.instance.AddMoney(50);
        }
    }

    public void SellClownfish()
    {
        Debug.Log("5 clicked!");
        if (InventoryManager.instance.DeleteItem("Clownfish"))
        {
            PlayerMoney.instance.AddMoney(75);
        }
    }

    public void SellDab()
    {
        Debug.Log("6 clicked!");
        if (InventoryManager.instance.DeleteItem("Dab"))
        {
            PlayerMoney.instance.AddMoney(50);
        }
    }

    public void SellFreshwaterSnail()
    {
        Debug.Log("7 clicked!");
        if (InventoryManager.instance.DeleteItem("FreshwaterSnail"))
        {
            PlayerMoney.instance.AddMoney(25);
        }
    }

    public void SellGoldenTench()
    {
        Debug.Log("8 clicked!");
        if (InventoryManager.instance.DeleteItem("GoldenTench"))
        {
            PlayerMoney.instance.AddMoney(30);
        }
    }

    public void SellGuppy()
    {
        Debug.Log("9 clicked!");
        if (InventoryManager.instance.DeleteItem("Guppy"))
        {
            PlayerMoney.instance.AddMoney(20);
        }
    }

    public void SellMossBall()
    {
        Debug.Log("10 clicked!");
        if (InventoryManager.instance.DeleteItem("MossBall"))
        {
            PlayerMoney.instance.AddMoney(1);
        }
    }

    public void SellSeaSpider()
    {
        Debug.Log("11 clicked!");
        if (InventoryManager.instance.DeleteItem("SeaSpider"))
        {
            PlayerMoney.instance.AddMoney(10);
        }
    }
}
