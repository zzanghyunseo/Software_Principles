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
        ReturnButton.gameObject.SetActive(false); // Return ��ư ��Ȱ��ȭ

        Countdown.gameObject.SetActive(true); // ī��Ʈ�ٿ� �ؽ�Ʈ Ȱ��ȭ
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
        Countdown.gameObject.SetActive(false); // ī��Ʈ�ٿ� �ؽ�Ʈ ��Ȱ��ȭ

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
        // ���� ���� �� ���� ���� ǥ��
        gameStarted = false;
        Result.text = "Game Over !";
        ReturnButton.gameObject.SetActive(true); // ���� ����� Return ��ư Ȱ��ȭ
    }

    public void GameScene() // Return ��ư Ŭ�� �� ���� ���� ȭ������ �� ��ȯ
    {
        SceneManager.LoadScene("GameSelect");
    }
}