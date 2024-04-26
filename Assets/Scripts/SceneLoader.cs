using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    
    public void LoadLogin()
    {
        SceneManager.LoadScene("Login");
    }
    public void LoadBinding()
    {
        SceneManager.LoadScene("binding");
    }
    public void Salir()
    {
        Debug.Log("SAliendo del vieoJOGO");
        Application.Quit();
    }

}
