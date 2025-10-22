using UnityEngine;

public class MapManager : MonoBehaviour
{
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
