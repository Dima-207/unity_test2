using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace spac_ui
{
    public class scri_ui : MonoBehaviour
    {
        public void load_scene(int n)
        {
            try
            {
                SceneManager.LoadScene(n);
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
            }
        }
    }
}


