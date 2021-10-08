using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public void Scene1 ()
    {
        SceneManager.LoadScene("openfield");
    }

     public void Scene2 ()
    {
        SceneManager.LoadScene("testlevel");
    }

     public void QuitGame ()
    {
      Application.Quit();
    }
   
}
