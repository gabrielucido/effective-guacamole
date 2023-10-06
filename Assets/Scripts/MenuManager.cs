using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    public void StartGame()
    {
        SceneManager.LoadScene("LucasTestScene");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Saiu");
    }

}
