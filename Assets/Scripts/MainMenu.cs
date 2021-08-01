using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public void PlayPressed()
    {
        SceneManager.LoadScene(1);
        Debug.Log("pressed");
    }
    public void ExitPressed()
    {
        Application.Quit();
        Debug.Log("pressed");
    }
}
