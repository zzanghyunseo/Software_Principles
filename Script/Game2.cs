using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game2 : MonoBehaviour
{
    public Button[] ClickButton;
    public Button ReturnButton;
    public Text Countdown;
    public Text Timer;
    public Text Score;
    public Text Result;
    public float timeLimit = 15f;

    private float timeRemaining;
    private float score = 0f;
    private bool gameStarted = false;

    void Start()
    {
        foreach (Button button in ClickButton)
        {
            button.gameObject.SetActive(false);
        }
        ReturnButton.gameObject.SetActive(false); // Return 버튼 비활성화

        Countdown.gameObject.SetActive(true); // 카운트다운 텍스트 활성화
        StartCoroutine(StartCountdown());
    }

    void Update()
    {
        if (gameStarted)
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

        foreach (Button button in ClickButton) // 카운트다운 종료 시 클릭 버튼 활성화
        {
            button.gameObject.SetActive(true);
        }

        gameStarted = true;
        timeRemaining = timeLimit;
        foreach (Button button in ClickButton)
        {
            button.onClick.AddListener(() => OnButtonClick());
        }
    }

    public void OnButtonClick()
    {
        // 버튼 클릭 시 점수 +1
        if (gameStarted)
        {
            score += 1;
            Score.text = "Score : " + score.ToString();
        }
    }

    void EndGame()
    {
        // 게임 종료 시 최종 점수 표시
        gameStarted = false;
        Result.text = "Game Over!\nScore : " + score.ToString();
        ReturnButton.gameObject.SetActive(true); // 게임 종료시 Return 버튼 활성화
    }

    public void GameScene() // Return 버튼 클릭 시 게임 선택 화면으로 씬 전환
    {
        SceneManager.LoadScene("GameSelect");
    }
}
