using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Game3 : MonoBehaviour
{
    public UnityEngine.UI.Button ReturnButton;
    public Text Countdown;
    public Text Result;
    /*public Text Timer;*/
    /*public float timeLimit = 10f;*/
    /*private float timeRemaining;*/

    public Text Message;
    private bool signalActive = false;
    private float reactionTime;
    private float startTime;

    private bool gameStarted = false;

    void Start()
    {
        Message.gameObject.SetActive(false);
        ReturnButton.gameObject.SetActive(false); // Return 버튼 비활성화

        Countdown.gameObject.SetActive(true); // 카운트다운 텍스트 활성화
        StartCoroutine(StartCountdown());

        /*StartCoroutine(SignalRoutine());*/
    }

    void Update()
    {
        /*if (gameStarted)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                Timer.text = "Time : " + Mathf.Round(timeRemaining).ToString();
            }
            else
            {
                EndGame();
            }
        }*/

        if (signalActive && Input.GetMouseButtonDown(0))
        {
            reactionTime = Time.time - startTime;
            Message.text = "Reaction Time : " + reactionTime.ToString("F3");
            signalActive = false;
            EndGame();
        }
    }

    IEnumerator StartCountdown()
    {
        int countdown = 3;
        while (countdown > 0)
        {

            Countdown.text = countdown.ToString();
            yield return new WaitForSeconds(1f);
            countdown--;
        }

        Countdown.text = "Go !";
        yield return new WaitForSeconds(1f);
        Countdown.gameObject.SetActive(false); // 카운트다운 텍스트 비활성화

        Message.gameObject.SetActive(true);
        gameStarted = true;
        /*timeRemaining = timeLimit;*/
        StartCoroutine(SignalRoutine());
    }

    IEnumerator SignalRoutine()
    {
        Message.text = "Ready . .";
        yield return new WaitForSeconds(Random.Range(2, 5));
        Message.text = "Click now !";
        signalActive = true;
        startTime = Time.time;
        yield return new WaitForSeconds(5f);
        if (signalActive)
        {
            Message.text = "Too Slow . .";
            signalActive = false;
            EndGame() ;
        }
    }

    void EndGame()
    {
        // 게임 종료 시 최종 점수 표시
        gameStarted = false;
        Result.text = "Game Over !";
        ReturnButton.gameObject.SetActive(true); // 게임 종료시 Return 버튼 활성화
    }

    public void GameScene() // Return 버튼 클릭 시 게임 선택 화면으로 씬 전환
    {
        SceneManager.LoadScene("GameSelect");
    }
}