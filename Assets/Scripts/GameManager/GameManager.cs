using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public enum GameState { CountDownTimer,Running,Failed,Completed}
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;


    public List<GameObject> GameplayThings;
    public GameObject LevelCompleted;
    public GameObject LevelFailed;
    public Text TimerTxt;
    public Text LifesTxt;
    public Text StartTimerTxt;
    public float Timer;
    public float StartTimer;
    public GameState CurrentState;
    public Sprite[] BricksHealthImg;
    public int TotalBricks;
    public int Lifes = 3;
    private void Awake()
    {
        if(Instance==null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        Time.timeScale = 0;
        if (CurrentState == GameState.CountDownTimer)
        {
 
            StartTimerTxt.gameObject.SetActive(true);
       
            Time.timeScale = 0;
        }
        else
            Time.timeScale = 1;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(CurrentState==GameState.Running)
        {
            Timer -= Time.deltaTime;
            TimerTxt.text = ((int)Timer).ToString();
            if(Timer<=0)
            {
                OnGameFailed();
            }
        }
        if(CurrentState==GameState.CountDownTimer)
        {
            StartTimer -= Time.unscaledDeltaTime;
            StartTimerTxt.text = ((int)StartTimer).ToString();

            if (StartTimer<=0)
            {
                CurrentState = GameState.Running;
                StartTimerTxt.gameObject.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }
    public void OnGameFailed()
    {
        Debug.Log("Game Faild");
        Time.timeScale = 0;
        CurrentState = GameState.Failed;
        LevelFailed.SetActive(true);
    }
    public void OnGameCompleted()
    {
        Debug.Log("Game Won");
        Time.timeScale = 0;
        CurrentState = GameState.Completed;
        LevelCompleted.SetActive(true);
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void ExitTheGame()
    {
        Application.Quit();
    }
    public void BrickDestroyed()
    {
        TotalBricks--;
        if(TotalBricks==0)
        {
            OnGameCompleted();
        }
    }
}
