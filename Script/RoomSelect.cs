using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomSelect : MonoBehaviour
{
    public void LoadRoomCreateScene()
    {
        SceneManager.LoadScene("RoomCreate");
    }

    public void LoadRoomJoinScene()
    {
        SceneManager.LoadScene("RoomJoin");
    }
}
