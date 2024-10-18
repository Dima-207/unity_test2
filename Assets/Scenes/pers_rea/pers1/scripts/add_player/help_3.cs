using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace play_sheme
{
    public class help_3 : MonoBehaviour
    {
        static public haract_ob udar_playe;
        static public haract_ob udar_enemy;
        static public health heal_playe;
        static public health heal_enemy;
        static public buld_sten player_sten;
        static public buld_sten enemy_sten;

        public help_3()
        {
            player_sten = new buld_sten(5, 3, 5);
            enemy_sten = new buld_sten(5, 3, 5);
            udar_playe = new haract_ob(5,0);
            udar_enemy = new haract_ob(5,0);
            heal_playe = new health();
            heal_enemy = new health();
        }

        public static void all_decrease()
        {
            try
            {
                player_sten.decrease();
                enemy_sten.decrease();
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
            }
        }
        public void buid_sten(Text tex_pla,GameObject stepla,Text tex_enem,
            GameObject ste_enem)
        {
            player_sten.ini_text_draw = tex_pla;
            player_sten.ini_sten_draw = stepla;
            enemy_sten.ini_text_draw = tex_enem;
            enemy_sten.ini_sten_draw = ste_enem;
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
    public struct buld_sten
    {
        private Text teex_dfen;
        private GameObject obj_sten;
        private int hod_remain { get; set; }
        private int max_hod_remain;
        private int val_save_h { get; set; }
        private int recover_wait { get; set; }
        private int max_rec_wait;

        public Text ini_text_draw
        {
            set
            {
                this.teex_dfen = value;
                set_tex = true;
            }
        }
        public GameObject ini_sten_draw
        {
            set
            {
                this.obj_sten = value;
                set_tex = true;
            }
        }
        private bool set_tex
        {
            set
            {
                string outuj = $"защ:{val_save_h}|действ:{hod_remain}|;ждать{recover_wait}";
                try
                {
                    this.teex_dfen.text = outuj;
                    if(this.hod_remain>0)
                        this.obj_sten.SetActive(true);
                    else
                    {
                        this.obj_sten.SetActive(false); 
                    }
                }
                catch (Exception e)
                {
                    Debug.Log(e.Message);
                }
            }
        }

        public int get_defense
        {
            get
            {
                int vaal = this.val_save_h;
                if (this.hod_remain < 1)
                    return 0;
                this.set_tex=true;
                return vaal;
            }
        }
        public buld_sten(int save_he,int hood,int max_wait)
        {
            this.val_save_h = save_he;
            this.hod_remain = 0;
            this.max_hod_remain = hood;
            this.max_rec_wait = max_wait;
            this.recover_wait = 0;
            this.teex_dfen = null;
            this.obj_sten = null;
            this.set_tex=true;
        }

        public void birth_new()
        {
            if(this.recover_wait>0)
                return;
            this.hod_remain = this.max_hod_remain;
            this.recover_wait = this.max_rec_wait;
            this.set_tex=true;
        }
        public void decrease(int val = 1)
        {
            this.hod_remain -= val;
            this.hod_remain = this.hod_remain < 0 ? 0 : this.hod_remain;
            this.recover_wait -= val;
            this.recover_wait = this.recover_wait < 0 ? 0 : this.recover_wait;
            this.set_tex=true;
        }
            
    }
    //------------------------------------------------------------------------------------------
    
        
        
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
    //-------------------------------------------------------------------------------------------
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
    //-------------------------------------------------------------------------------------------------------
    
}

