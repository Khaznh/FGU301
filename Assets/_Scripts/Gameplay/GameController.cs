using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    private int index = 0;
    private string[] arrSeasons = { "SpringScene", "SummerScene", "AutumnScene", "WinnterScene" };
    private float timer = 0.0f;
    private bool firstTime = true;


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

        if (timer > 60 * 15)
        {
            index++;
            if (index >= arrSeasons.Length)
            {
                index = 0;
            }
            timer = 0.0f;
        }
    }

    public void ChangeToGameScene()
    {
        if (firstTime)
        {
            index = 0;
            firstTime = false;
        }

        SceneManager.LoadScene(arrSeasons[index]);
    }

    public void ChangeToHomeScene()
    {
        SceneManager.LoadScene("HomeScene");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
