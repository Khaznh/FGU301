using UnityEngine;
using UnityEngine.Video;
using System.Collections;

public class VideoController : MonoBehaviour
{
    public VideoPlayer videoPlayer;  
    DelayHelper delay = new DelayHelper();
    private void Start()
    {

        videoPlayer.loopPointReached += OnVideoEnd;
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        if (GameController.instance != null)
        {
            GameController.instance.ChangeToGameSceneFromStart();
            AudioManager.Instance.PlayMusic("Theme");
        }
    }

}
