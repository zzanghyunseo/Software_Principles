using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Back : MonoBehaviour
{
    public void LoadTitleScene()
    {
        SceneManager.LoadScene("Title");
    }

    public void LoadRoomCreateScene()
    {
       SceneManager.LoadScene("RoomCreate");
    }

    public void LoadRoomJoinScene()
    {
        SceneManager.LoadScene("RoomJoin");
    }

    public void LoadGameSelectScene()
    {
        SceneManager.LoadScene("GameSelect");
    }
}
