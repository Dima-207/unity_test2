using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace spac_ui
{
    public class scri_ui : MonoBehaviour
    {
        public AudioClip clip_muz;
        private AudioSource sour;
        private bool igramuz;
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

        public void muuz()
        {
            this.igramuz = !this.igramuz;
            if (igramuz)
            {
                this.sour.Play();
            }
            else
            {
                this.sour.Stop();
            }
        }
        private void Start()
        {
            this.igramuz = false;
            this.sour = GetComponent<AudioSource>();
            this.sour.clip = clip_muz;
            this.sour.Stop();
        }
    }
}


