
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class FishingGamePlay : MonoBehaviour
{
    public event Action<string> OnGetResult;

    [SerializeField] private GameObject moveBar;
    [SerializeField] private GameObject fishLoc;
    [SerializeField] private GameObject progressBar;

    [Header("Fishing Stats")]
    public float fishSpeed = 20f;
    public float fishChangeDirTimer = 4f;

    [SerializeField] private float moveBarSpeed = 120f;
    
    private float catchProgress = 0f;
    public float lostProgress = 3f;
    public float gainsProgress = 4f;

    private float timer;
    private float randomTime;
    private float fishRandomPosY;
    private PlayerInput playerInput;
    private Vector2 moveDir;
    private float delayTime = 2f;

    private float moveBarMax = 162f;
    private float moveBarMin = -155f;

    private float scaleProgressBarMin = 0;
    private float scaleProgressBarMax = 31f;

    private float fishBarMax = 200f;
    private float fishBarMin = -191f;

    private RectTransform barRectTranform;
    private RectTransform fishRectTranform;
    private RectTransform progressBarRectTranform;

    private void Awake()
    {
        moveBar = transform.Find("MoveBar").gameObject;
        fishLoc = transform.Find("FishLoc").gameObject;
        progressBar = transform.Find("ProgressBar").gameObject;

        barRectTranform = moveBar.GetComponent<RectTransform>();
        fishRectTranform = fishLoc.GetComponent<RectTransform>();
        progressBarRectTranform = progressBar.GetComponent<RectTransform>();

        playerInput = new PlayerInput();
    }

    private void OnEnable()
    {
        StopAllCoroutines();
        playerInput.Enable();
        timer = 0f;
        catchProgress = 0f;
        randomTime = 0f;
        StartCoroutine(Result());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
        playerInput.Disable();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StopAllCoroutines();
        timer = 0f;
        catchProgress = 0f;
        randomTime = 0f;
        StartCoroutine(Result());
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        MoveMoveBar();
        FishMovement();
        CatchLogic();
    }

    private void MoveMoveBar()
    {
        float yBarRect = barRectTranform.anchoredPosition.y;

        yBarRect += moveDir.y * Time.deltaTime * moveBarSpeed;
        yBarRect = Mathf.Clamp(yBarRect, moveBarMin, moveBarMax);
        barRectTranform.anchoredPosition = new Vector2(barRectTranform.anchoredPosition.x, yBarRect);
    }

    private void FishMovement()
    {
        timer += Time.deltaTime;
        if (timer > randomTime)
        {
            fishRandomPosY = UnityEngine.Random.Range(fishBarMin, fishBarMax);
            GetRandomTime();
            timer = 0f;
        }
        
        float posY = Mathf.MoveTowards(fishRectTranform.anchoredPosition.y, fishRandomPosY, fishSpeed * Time.deltaTime);
        fishRectTranform.anchoredPosition = new Vector2(fishRectTranform.anchoredPosition.x, posY);
    }

    private void CatchLogic()
    {
        float heightMoveBar = barRectTranform.sizeDelta.y;
        float yMoveBar = barRectTranform.anchoredPosition.y;

        float fishY = fishRectTranform.anchoredPosition.y;

        bool isInMoveBar = fishY < (yMoveBar + heightMoveBar / 2) && fishY > (yMoveBar - heightMoveBar / 2);
        
        if (isInMoveBar)
        {
            catchProgress += gainsProgress * Time.deltaTime;
        } else
        {
            catchProgress -= lostProgress * Time.deltaTime;
        }

        catchProgress = Mathf.Clamp(catchProgress, scaleProgressBarMin, scaleProgressBarMax);
        progressBarRectTranform.localScale = new Vector3(progressBarRectTranform.localScale.x, catchProgress, progressBarRectTranform.localScale.z);
    }

    private void GetInput()
    {
        moveDir = playerInput.GamePlay.Fishing.ReadValue<Vector2>();
    }

    private void GetRandomTime()
    {
        randomTime = UnityEngine.Random.Range(0, fishChangeDirTimer);
    }

    private IEnumerator Result()
    {
        yield return new WaitForSeconds(delayTime);
        
        while (true)
        {
            if (catchProgress == 31)
            {
                OnGetResult?.Invoke("Catch");
                yield break;
            }
            else if (catchProgress == 0)
            {
                OnGetResult?.Invoke("Fail");
                yield break;
            }

            yield return null;
        }
    }
}
