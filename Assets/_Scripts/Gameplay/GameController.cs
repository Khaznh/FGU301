using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    private int index = 0;
    private string[] arrSeasons = { "SpringScene", "SummerScene", "AutumnScene", "WinnterScene" };
    private float timer = 0.0f;
    private bool firstTime = true;
    public float changeTime = 10f;

    public Vector3 playerPositionToSpawn;


    private void Awake()
    {
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
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > changeTime)
        {
            index++;
            if (index >= arrSeasons.Length)
            {
                index = 0;
            }
            timer = 0.0f;
        }
    }

    public void ChangeToGameScene(Vector3 spawnPos)
    {
        playerPositionToSpawn = spawnPos;


        if (firstTime)
        {
            index = 0;
            firstTime = false;
        }

        SceneManager.LoadScene(arrSeasons[index]);
    }

    public void ChangeToGameSceneFromStart()
    {
        playerPositionToSpawn = new Vector3(-12, -1, 0);

        if (firstTime)
        {
            index = 0;
            firstTime = false;
        }
        SceneManager.LoadScene(arrSeasons[index]);
    }

    public void ChangeToGameSceneFromHome()
    {
        playerPositionToSpawn = new Vector3(30, -8, 0);
        SceneManager.LoadScene(arrSeasons[index]);
    }

    public void ChangeToHomeScene()
    {
        playerPositionToSpawn = new Vector3(-13.5f, 4.5f, 0);
        SceneManager.LoadScene("Shop");
    }

    public void ChangeFromHomeToMain()
    {
        playerPositionToSpawn = new Vector3(-12, -1, 0);
        SceneManager.LoadScene(arrSeasons[index]);
    }

    public void ChangeMainToHOme()
    {
        playerPositionToSpawn = new Vector3(-9, -9, 0);
        SceneManager.LoadScene("HomeScene");
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("VideoIntro");
        AudioManager.Instance.StopMusic();
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
