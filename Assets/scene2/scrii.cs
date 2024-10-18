using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class scrii : MonoBehaviour
{
    public void exit()
    {
        Application.Quit();
        Debug.Log("exit");
    }

    public void Sstart()
    {
        SceneManager.LoadScene(1);
        Debug.Log("start");
    }
}
