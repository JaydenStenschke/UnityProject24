using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void StartGame(){
        SceneManager.LoadScene("SmelldonRing");
    }

    public void ExitGame(){
        Debug.Log("Game is exiting....");
        Application.Quit();

    }
}
