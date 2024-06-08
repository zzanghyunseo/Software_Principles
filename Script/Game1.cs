using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game1 : MonoBehaviour
{
    public Button[] numberButtons;
    public Button ReturnButton;
    public Text Timer;
    public Text Countdown;
    public Text Result;
    public float timeLimit = 15f;

    private int currentNumber = 1;
    private float timeRemaining;
    private bool gameStarted = false;

    void Start()
    {
        foreach (Button button in numberButtons) // 숫자 버튼 비활성화
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
                EndGame(false);
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

        foreach (Button button in numberButtons) // 카운트다운 종료 시 숫자 버튼 활성화
        {
            button.gameObject.SetActive(true);
        }

        gameStarted = true;
        timeRemaining = timeLimit;
        foreach (Button button in numberButtons)
        {
            button.onClick.AddListener(() => OnButtonClick(button));
        }
        ShuffleButtons();
    }

    void OnButtonClick(Button button)
    {
        if (button.GetComponentInChildren<Text>().text == currentNumber.ToString())
        {
            button.gameObject.SetActive(false);
            currentNumber++;
            if (currentNumber > 25)
            {
                EndGame(true);
            }
        }
    }

    void ShuffleButtons()
    {
        // 기존의 버튼 위치 저장
        Vector3[] originalPositions = new Vector3[numberButtons.Length];
        for (int i = 0; i < numberButtons.Length; i++)
        {
            originalPositions[i] = numberButtons[i].transform.position;
        }

        // 위치 랜덤
        for (int i = 0; i < numberButtons.Length; i++)
        {
            int randomIndex = Random.Range(0, numberButtons.Length);
            Vector3 tempPosition = numberButtons[i].transform.position;
            numberButtons[i].transform.position = numberButtons[randomIndex].transform.position;
            numberButtons[randomIndex].transform.position = tempPosition;
        }
    }

    void EndGame(bool success)
    {
        gameStarted = false;
        if (success)
        {
            float elapsedTime = timeLimit - timeRemaining;
            Result.text = "Game Over !\nTime : " + elapsedTime.ToString("F1");
        }
        else
        {
            Result.text = "Game Over !\nTime Over..";
        }

        ReturnButton.gameObject.SetActive(true); // 게임 종료시 Return 버튼 활성화

        // 게임 초기화
        // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameScene() // Return 버튼 클릭 시 게임 선택 화면으로 씬 전환
    {
        SceneManager.LoadScene("GameSelect");
    }

}