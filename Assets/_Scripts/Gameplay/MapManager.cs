using UnityEngine;

public class MapManager : MonoBehaviour
{
    public static MapManager instance;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        gameObject.SetActive(false);
    }

    public void Buymap()
    {
        gameObject.SetActive(true);
    }

    // Load Shop
    public void ChangeToHomeScene()
    {
        GameController.instance.ChangeToHomeScene();
    }

    //Load Home
    public void ChangeMainToHOme()
    {
        GameController.instance.ChangeMainToHOme();
    }
    
    //Load Map
    public void ChangeToGameSceneFromHome()
    {
        GameController.instance.ChangeToGameSceneFromHome();
    }

}
