using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace play_sheme
{
    public struct health
    {
        public int max_val;
        public int cur_val;
        public int val_defense;
        public int hod_defense;
        private Vector3 razz;
        private Transform hel_ob_rot;
        private Text inf_healt;

        public void set_damag(int vva)
        {
            this.cur_val -= vva;
            if (this.hod_defense > 0)
            {
                this.cur_val += val_defense;
            }
            this.inf_healt.text = "Здоровье:" + this.cur_val.ToString();
            float znach=this.cur_val/this.max_val;
            razz = this.hel_ob_rot.localScale;
            razz.z = znach;
            this.hel_ob_rot.localScale = razz;
        }

        public Text set_text
        {
            set
            {
                this.inf_healt = value;
                this.inf_healt.text = "Здоровье:" + this.cur_val.ToString();
            }
        }
        public Transform set_trans
        {
            set
            {
                this.hel_ob_rot = value;
                this.val_defense = 0;
                this.hod_defense = 0;
            }
        }
        public void decrease(int vv)
        {
            this.hod_defense -= vv;
            if (this.hod_defense < 0)
            {
                this.hod_defense = 0;
                this.val_defense = 0;
            }
        }
        public void set_defense(int val_defen, int hod_defenc)
        {
            this.val_defense = val_defen;
            this.hod_defense = hod_defenc;
        }
    }
    public struct haract_ob
    {
        private Text teex;

        public Text set_tex
        {
            set
            {
                this.teex = value;
                this.teex.text = this.val_damag.ToString();
            }
        }
        public haract_ob(int damag,int hood)
        {
            this.val_damag = damag;
            this.hod_remain = hood;
            this.teex = null;
        }

        public void decrease(int val = 1)
        {
            this.hod_remain -= val;
            this.hod_remain = this.hod_remain < 0 ? 0 : this.hod_remain;
            try
            {
                teex.text = "Осталось " + this.hod_remain.ToString();
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
            }
        }
        public int hod_remain { get; set; }
        public int val_damag { get; set; }
    }
    public class help_3 : MonoBehaviour
    {
        static public haract_ob udar_playe;
        static public haract_ob udar_enemy;
        static public health heal_playe;
        static public health heal_enemy;

        public help_3()
        {
            udar_playe = new haract_ob(5,0);
            udar_enemy = new haract_ob(5,0);
            heal_playe = new health();
            heal_enemy = new health();
        }

        public void set_healths(int max_val_pla,Transform sca_pla,Text tex_pla,
            int max_val_enem,Transform sca_enem,Text tex_enem)
        {
            heal_enemy.max_val = max_val_pla;
            heal_enemy.cur_val = max_val_pla;
            heal_enemy.set_trans = sca_enem;
            heal_enemy.set_text = tex_enem;
            heal_playe.max_val = max_val_enem;
            heal_playe.cur_val = max_val_enem;
            heal_playe.set_trans = sca_pla;
            heal_playe.set_text = tex_pla;
        }
        public void set_init_udar(int val_damag, Text tex_playe,
            int val_damag_enem, Text tex_enem)
        {
            udar_playe.val_damag = val_damag;
            udar_playe.set_tex = tex_playe;
            udar_enemy.val_damag = val_damag_enem;
            udar_enemy.set_tex = tex_enem;
        }
    } 
}

