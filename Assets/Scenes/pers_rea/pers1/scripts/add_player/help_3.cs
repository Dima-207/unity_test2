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
        static public lekar_lech player_tablet;
        static public lekar_lech enemy_tablet;
        static public build_ogon player_ogon;
        static public build_ogon enemy_ogon;

        public help_3()
        {
            player_tablet = new lekar_lech(2, 4, 6);
            enemy_tablet = new lekar_lech(2, 4, 6);
            player_sten = new buld_sten(5, 3, 5);
            enemy_sten = new buld_sten(5, 3, 5);
            udar_playe = new haract_ob(5,0);
            udar_enemy = new haract_ob(5,0);
            heal_playe = new health();
            heal_enemy = new health();
            player_ogon = new build_ogon(1, 5, 6, 5);
            enemy_ogon = new build_ogon(1, 5, 6, 5);
        }

        public void set_gamo(GameObject ogon_pla_ind,GameObject stena_pla_ind,GameObject zdorov_pla_ind,
            GameObject ogon_ene_ind,GameObject stena_ene_ind,GameObject zdorov_ene_ind)
        {
            enemy_ogon.indicator = ogon_ene_ind;
            enemy_ogon.indicator.SetActive(false);
            enemy_sten.indicator = stena_ene_ind;
            enemy_sten.indicator.SetActive(false);
            enemy_tablet.indicator = zdorov_ene_ind;
            enemy_tablet.indicator.SetActive(false);
            player_ogon.indicator = ogon_pla_ind;
            player_ogon.indicator.SetActive(false);
            player_sten.indicator = stena_pla_ind;
            player_sten.indicator.SetActive(false);
            player_tablet.indicator = zdorov_pla_ind;
            player_tablet.indicator.SetActive(false);
        }
        public void buid_ogon(Text tex_pla,Transform tra_add_pla,GameObject main_pla_coord,
            Text tex_enem,Transform tra_add_enem,GameObject main_enem_coord)
        {
            player_ogon.ini_text_draw = tex_pla;
            player_ogon.ini_add_ogon_draw = tra_add_pla;
            player_ogon.ini_main_ogon_draw = main_pla_coord;
            enemy_ogon.ini_text_draw = tex_enem;
            enemy_ogon.ini_add_ogon_draw = tra_add_enem;
            enemy_ogon.ini_main_ogon_draw = main_enem_coord;
        }
        public void buid_lekar(Text tex_pla,Text tex_enem)
        {
            player_tablet.ini_text_draw = tex_pla;
            enemy_tablet.ini_text_draw = tex_enem;
        }
        public static void all_decrease()
        {
            try
            {
                player_sten.decrease();
                enemy_sten.decrease();
                heal_playe.set_damag(enemy_ogon.get_uron);;
                heal_enemy.set_damag(player_ogon.get_uron);
                player_ogon.decrease();
                enemy_ogon.decrease();
                heal_playe.set_prib(player_tablet.get_lekar_repair);
                player_tablet.decrease();
                heal_enemy.set_prib(enemy_tablet.get_lekar_repair);
                enemy_tablet.decrease();
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
    public struct build_ogon
    {
        private Text teex_ogon;
        private Transform obj_ogon;
        private GameObject coordinate;
        private Vector3 beg_coord_ogon;
        public GameObject indicator;
        private int hod_remain { get; set; }
        private int max_hod_remain;
        private int val_damag_h { get; set; }
        private int recover_wait { get; set; }
        private int max_rec_wait;
        private int beginin_damage;

        public Text ini_text_draw
        {
            set
            {
                this.teex_ogon = value;
                set_tex = true;
            }
        }
        public GameObject ini_main_ogon_draw
        {
            set
            {
                this.coordinate = value;
                this.coordinate.SetActive(false);
                set_tex = true;
            }
        }
        public GameObject get_main_ogon
        {
            get
            {
                return this.coordinate;
            }
        }
        public Transform get_simp_ogon
        {
            get
            {
                return this.obj_ogon;
            }
        }
        public Transform ini_add_ogon_draw
        {
            set
            {
                this.obj_ogon = value;
                this.beg_coord_ogon = this.obj_ogon.position;
                set_tex = true;
            }
        }

        public int get_first_hit
        {
            get
            {
               return this.beginin_damage;
            }
        }
        private bool set_tex
        {
            set
            {
                string outuj = $"урон:{val_damag_h}|действ:{hod_remain}|;ждать:{recover_wait}";
                try
                {
                    this.teex_ogon.text = outuj;
                    /*if(this.hod_remain>0)
                        this.coordinate.SetActive(true);
                    else
                    {
                        this.coordinate.SetActive(false); 
                    }*/
                }
                catch (Exception e)
                {
                   // Debug.Log(e.Message);
                }
            }
        }

        public int get_uron
        {
            get
            {
                int vaal = this.val_damag_h;
                if (this.hod_remain < 1)
                    return 0;
                this.set_tex=true;
                return vaal;
            }
        }
        public build_ogon(int dama_he,int hood,int max_wait,int beg_daam)
        {
            this.val_damag_h = dama_he;
            this.hod_remain = 0;
            this.max_hod_remain = hood;
            this.max_rec_wait = max_wait;
            this.recover_wait = 0;
            this.teex_ogon = null;
            this.obj_ogon = null;
            this.beginin_damage = beg_daam;
            this.beg_coord_ogon = new Vector3();
            this.coordinate = null;
            this.indicator = null;
        }

        public void birth_new()
        {
            if(this.recover_wait>0)
                return;
            this.coordinate.SetActive(true);
            this.hod_remain = this.max_hod_remain;
            this.recover_wait = this.max_rec_wait;
            this.indicator.SetActive(true);
            this.set_tex=true;
        }
        public void decrease(int val = 1)
        {
            
            this.hod_remain -= val;
            this.hod_remain = this.hod_remain < 0 ? 0 : this.hod_remain;
            this.recover_wait -= val;
            this.recover_wait = this.recover_wait < 0 ? 0 : this.recover_wait;
            if (this.recover_wait < 1)
                this.indicator.SetActive(false);
            this.set_tex=true;
        }
            
    }
    public struct lekar_lech
    {
        private Text teex_dfen;
        public GameObject indicator;
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
        
        private bool set_tex
        {
            set
            {
                string outuj = $"лек:{val_save_h}|действ:{hod_remain}|;ждать:{recover_wait}";
                try
                {
                    this.teex_dfen.text = outuj;
                    
                }
                catch (Exception e)
                {
                    Debug.Log(e.Message+" lekar error");
                }
            }
        }

        public int get_lekar_repair
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
        public lekar_lech(int save_he,int hood,int max_wait)
        {
            this.val_save_h = save_he;
            this.hod_remain = 0;
            this.max_hod_remain = hood;
            this.max_rec_wait = max_wait;
            this.recover_wait = 0;
            this.teex_dfen = null;
            this.indicator = null;
            this.set_tex=true;
        }

        public void birth_new()
        {
            if(this.recover_wait>0)
                return;
            this.hod_remain = this.max_hod_remain;
            this.recover_wait = this.max_rec_wait;
            this.indicator.SetActive(true);
            this.set_tex=true;
        }
        public void decrease(int val = 1)
        {
            this.hod_remain -= val;
            this.hod_remain = this.hod_remain < 0 ? 0 : this.hod_remain;
            this.recover_wait -= val;
            this.recover_wait = this.recover_wait < 0 ? 0 : this.recover_wait;
            if (this.recover_wait < 1)
                this.indicator.SetActive(false);
            this.set_tex=true;
        }
            
    }
    public struct buld_sten
    {
        private Text teex_dfen;
        private GameObject obj_sten;
        public GameObject indicator;
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
                string outuj = $"защ:{val_save_h}|действ:{hod_remain}|;ждать:{recover_wait}";
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
                   // Debug.Log(e.Message);
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
            this.indicator = null;
            this.set_tex=true;
        }

        public void birth_new()
        {
            if(this.recover_wait>0)
                return;
            this.hod_remain = this.max_hod_remain;
            this.recover_wait = this.max_rec_wait;
            this.indicator.SetActive(true);
            this.set_tex=true;
        }
        public void decrease(int val = 1)
        {
            this.hod_remain -= val;
            this.hod_remain = this.hod_remain < 0 ? 0 : this.hod_remain;
            this.recover_wait -= val;
            this.recover_wait = this.recover_wait < 0 ? 0 : this.recover_wait;
            if (this.recover_wait < 1)
                this.indicator.SetActive(false);
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

        public void set_prib(int vva)
        {
            this.cur_val += vva;
            this.cur_val = this.cur_val > this.max_val ? this.max_val : this.cur_val;
            this.inf_healt.text = "Здоровье:" + this.cur_val.ToString()+"|+"+vva.ToString();
            float znach=((float)this.cur_val)/this.max_val;
            razz = this.hel_ob_rot.localScale;
            razz.y= znach;
            this.hel_ob_rot.localScale = razz;
        }
        public void set_damag(int vva)
        {
            this.cur_val -= vva;
            if (this.hod_defense > 0)
            {
                this.cur_val += val_defense;
            }
            this.inf_healt.text = "Здоровье:" + this.cur_val.ToString();
            float znach=((float)this.cur_val)/this.max_val;
            razz = this.hel_ob_rot.localScale;
            razz.y= znach*0.62f;
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

