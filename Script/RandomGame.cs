using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RandomGame : MonoBehaviour
{
    public GameObject GamePrefab1;
    public GameObject GamePrefab2;
    public GameObject GamePrefab3;

    void Start()
    {
        int random = Random.Range(0, 3);

        GameObject selectedGame = null;
        switch (random)
        {
            case 0 :
                selectedGame = Instantiate(GamePrefab1);
                break;
            case 1:
                selectedGame = Instantiate(GamePrefab2);
                break;
            case 2:
                selectedGame = Instantiate(GamePrefab3);
                break;
        }

        if (selectedGame != null)
        {
            selectedGame.transform.position = Vector3.zero;
        }
    }
}