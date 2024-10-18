using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using play_sheme;
using UnityEngine.UI;
using System.Threading;

namespace space_direc
{
    public class directo : MonoBehaviour
    {
        public plater1 player_ob;
        public plater1 enemy_ob;

        public Text tex_playe;
        public Text tex_penemy;
        public bool reshal;
        private Thread tthr;
        public directo()
        {
            this.reshal = false;
        }

        void do_miig()
        {
            string text1 = "Думаю пока, жди";
            string text2 = "Думаю пока";
            
            
                
                if (tex_playe.text.Length < 3)
                {
                    tex_playe.text = text1;
                    tex_penemy.text = "...";
                }
                else
                {
                    tex_penemy.text = text2;
                    tex_playe.text = "...";
                }
                tex_playe.text = text1;
                tex_penemy.text = text2;
        }
        public void do_resha()
        {
            float vva = Random.Range(0, 100);
            if (vva < 51)
            {
                this.player_ob.set_wait();
                this.tex_playe.text = "Ваш ход";
                this.tex_penemy.text = "Пропуск";
            }
            else
            {
                this.enemy_ob.set_wait();
                this.tex_penemy.text = "Врага ход";
                this.tex_playe.text = "Пропуск";
            }
        }
        IEnumerator nuume()
        {
            this.reshal = true;
            yield return new WaitForSeconds(Random.Range(3.1f, 6.8f));
            this.reshal = false;
            this.do_resha();
            
        }
        void scan_initi()
        {
            if(reshal)
                return;
            if (player_ob.get_mode_main == mode_main.mode_init &&
                enemy_ob.get_mode_main == mode_main.mode_init)
            {
                StartCoroutine(nuume());
                this.do_miig();
            }
        }
        void Start()
        {

        }

        
        void Update()
        {
            this.scan_initi();
        }
    }
}
