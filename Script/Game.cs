using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public void LoadGame1Scene()
    {
        SceneManager.LoadScene("Game1");
    }

    public void LoadGame2Scene()
    {
        SceneManager.LoadScene("Game2");
    }

    public void LoadGame3Scene()
    {
        SceneManager.LoadScene("Game3");
    }

    public void LoadRandomGameScene()
    {
        SceneManager.LoadScene("RandomGame");
    }
}
