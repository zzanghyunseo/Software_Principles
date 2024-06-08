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
        ReturnButton.gameObject.SetActive(false); // Return ��ư ��Ȱ��ȭ

        Countdown.gameObject.SetActive(true); // ī��Ʈ�ٿ� �ؽ�Ʈ Ȱ��ȭ
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
        Countdown.gameObject.SetActive(false); // ī��Ʈ�ٿ� �ؽ�Ʈ ��Ȱ��ȭ

        foreach (Button button in ClickButton) // ī��Ʈ�ٿ� ���� �� Ŭ�� ��ư Ȱ��ȭ
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
        // ��ư Ŭ�� �� ���� +1
        if (gameStarted)
        {
            score += 1;
            Score.text = "Score : " + score.ToString();
        }
    }

    void EndGame()
    {
        // ���� ���� �� ���� ���� ǥ��
        gameStarted = false;
        Result.text = "Game Over!\nScore : " + score.ToString();
        ReturnButton.gameObject.SetActive(true); // ���� ����� Return ��ư Ȱ��ȭ
    }

    public void GameScene() // Return ��ư Ŭ�� �� ���� ���� ȭ������ �� ��ȯ
    {
        SceneManager.LoadScene("GameSelect");
    }
}
