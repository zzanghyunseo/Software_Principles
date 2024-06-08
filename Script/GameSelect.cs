using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSelect : MonoBehaviour
{
    public void LoadGameSelectScene()
    {
        SceneManager.LoadScene("GameSelect");
    }
}
