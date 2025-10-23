using UnityEngine;

public class PauseEvent : MonoBehaviour
{
    public static PauseEvent instance;

    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject pausePanel;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        Time.timeScale = 1f;
        pauseButton = transform.Find("PauseButton").gameObject;
        pausePanel = transform.Find("PausePanel").gameObject;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PaseGame()
    {
        pauseButton.SetActive(false);
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
    }
    public void ResumeGame()
    {
        pauseButton.SetActive(true);
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
