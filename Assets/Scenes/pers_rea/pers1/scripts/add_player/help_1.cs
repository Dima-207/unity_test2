using System.Collections;
using System.Collections.Generic;
using System;
using System.Threading;
using UnityEngine;

namespace play_sheme
{
    public enum do_ogon_boi
    {
        its_off=0,
        ts_begiin=1,
        ts_run=2,
        do_boi=3,
        do_after_boi=4,
        do_vverh_ogon=5,
        do_aim_ogon=6,
        do_end_aim_ogon=7,
        ts_return=8
    }
    public enum do_lekar_repai
    {
        its_off=0,
        ts_begiin=1,
        ts_run=2,
        do_lekar=3,
        do_after_lekar=4,
        ts_return=5
    }
    public enum do_build_wall
    {
        its_off=0,
        ts_begiin=1,
        ts_run=2,
        do_bild=3,
        do_after_bild=4,
        ts_return=5
    }
    public enum do_mod_hit
    {
        do_off=0,
        do_begiin=1,
        do_run=2,
        do_hit=3,
        do_after_hit=4,
        do_return=5
    }
    public enum mode_main
    {
        mode_init=0,
        mode_wait=1,
        mode_action=2
    } 
    public enum typ_plaer
    {
        unknow=0,
        typ_player=1,
        ryp_enemy=2
    } 
    public class help_1 : MonoBehaviour
    {
        private bool its_rand_pokoi;
        private Animator ani_person;
        private Thread thhr;
        private bool do_anim;
        private bool do_anim_2;
        private int healt;
        public do_ogon_boi ma_boi_ogon {get; set;}
        public do_build_wall ma_build { get; set; }
        public do_lekar_repai ma_rekar {get; set;}
        public int heal_now
        {
            set
            {
                this.healt -= value;
            }
            get
            {
                return this.healt;
            }
        }
        public bool use_2_anim
        {
            get
            {
                bool vv = this.do_anim_2;
                this.do_anim_2 = false;
                return vv;
            }
        }
        public bool use_1_anim
        {
            get
            {
                bool vv = this.do_anim;
                this.do_anim = false;
                return vv;
            }
        }
        public mode_main ma_res { get; set; }
        public do_mod_hit ma_do_hit { get; set; }
        public help_1(Animator aani)
        {
            this.ani_person = aani;
            this.its_rand_pokoi = false;
            this.ma_res = mode_main.mode_init;
            this.ma_do_hit = do_mod_hit.do_off;
            this.ma_build = do_build_wall.its_off;
            this.do_anim = false;
            this.do_anim_2 = false;
            this.healt = 100;
        }

        public void set_param(Animator aani)
        {
            this.ani_person = aani;
        }
        void metod_rand()
        {
            this.its_rand_pokoi = true;
            //Debug.Log("thread start "+this.its_rand_pokoi.ToString());
            Thread.Sleep(new System.Random().Next(1000,10000));
            int vv = new System.Random().Next(0,100);
            //Debug.Log("thread cont");
            if (vv > 66)
            {
                try
                {
                    this.do_anim = true;
                }
                catch (Exception e)
                {
                    Debug.Log(e.Message);

                }
            }

            if (vv > 33 && vv <= 66)
            {
                this.do_anim_2 = true;
            }

            this.its_rand_pokoi = false;
        }
        public void do_anim_pokoi()
        {
            if(this.ma_res!=mode_main.mode_init||
               this.its_rand_pokoi)
                return;
            this.thhr = new Thread(metod_rand);
            this.thhr.Start();
            this.thhr.IsBackground = true;
            this.its_rand_pokoi = true;

        }
    }
}

