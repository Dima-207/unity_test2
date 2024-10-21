using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace play_sheme
{
    public class plater1 : MonoBehaviour
    {
        private bool calc_rasch;
        private Vector3 do_root;
        private help_1 hellp_1;
        private help_2 hellp_2;
        private help_3 hellp_3;
        private help_sten hellp_stte;
        private tablet hellp_table;
        private ogon_s hellp_ogon;
        public Animator anim_;
        public typ_plaer typpla;
        public Transform enemm;
        public Text tex_player;
        public Text tex_enemy;
        public Transform he_sca_player;
        public Text heat_playe_tex;
        public Transform he_sca_enemy;
        public Text heat_enemy_tex;
        public float speed_pla = 7.2f;
        public Text build_playe_tex;
        public Text build_enemy_tex;
        public GameObject sten_plal;
        public GameObject sten_enem;
        public Text lekar_playe_tex;
        public Text lekar_enemy_tex;
        public Text ogon_playe_tex;
        public Transform ogon_add_player;
        public GameObject ogon_main_player;
        public Text ogon_enemy_tex;
        public Transform ogon_add_enemy;
        public GameObject ogon_main_enemy;
        public GameObject zdorov_player_kub;
        public GameObject stena_player_kub;
        public GameObject ogon_player_kub;
        public GameObject zdorov_enemy_kub;
        public GameObject stena_enemy_kub;
        public GameObject ogon_enemy_kub;
        void Start()
        {
            
            this.hellp_2.sppe = this.speed_pla;
            this.hellp_table.sppe=this.speed_pla;
            this.hellp_stte.sppe=this.speed_pla;
            this.hellp_ogon.sppe = this.speed_pla;
            this.hellp_1.set_param(anim_);
            this.hellp_2.set_param(enemm);
            this.hellp_stte.set_param(enemm);
            this.hellp_table.set_param(enemm);
            this.hellp_ogon.set_param(enemm);
            this.hellp_2.set_antor = this.anim_;
            this.hellp_stte.set_antor = this.anim_;
            this.hellp_table.set_antor = this.anim_;
            this.hellp_ogon.set_antor = this.anim_;
            this.hellp_2.set_tipl = typpla;
            this.hellp_stte.set_tipl = typpla;
            this.hellp_table.set_tipl = typpla;
            this.hellp_ogon.set_tipl = typpla;
            this.hellp_2.maiin = transform;
            this.hellp_table.maiin = transform;
            this.hellp_stte.maiin = transform;
            this.hellp_ogon.maiin = transform;
            this.hellp_2.inti_begin_posi();
            this.hellp_stte.inti_begin_posi();
            this.hellp_table.inti_begin_posi();
            this.hellp_ogon.inti_begin_posi();
            this.hellp_stte.scan_coor_main();
            this.hellp_table.scan_coor_lekar();
            
            if(typpla==typ_plaer.typ_player)
            {
                this.hellp_3.set_gamo(ogon_player_kub,stena_player_kub,zdorov_player_kub,
                    ogon_enemy_kub,stena_enemy_kub,zdorov_enemy_kub);
                this.hellp_3.buid_ogon(this.ogon_playe_tex,this.ogon_add_player,this.ogon_main_player,
                    this.ogon_enemy_tex,this.ogon_add_enemy,this.ogon_main_enemy);
                this.hellp_3.buid_lekar(this.lekar_playe_tex,
                    this.lekar_enemy_tex);
                this.hellp_3.buid_sten(this.build_playe_tex,this.sten_plal,
                    this.build_enemy_tex,this.sten_enem);
                this.hellp_3.set_healths(200, this.he_sca_player,heat_playe_tex,
                    200, this.he_sca_enemy,heat_enemy_tex);
                this.hellp_3.set_init_udar(8, this.tex_player,
                    8, this.tex_enemy);
            }
            
            if (typpla == typ_plaer.ryp_enemy)
                this.hellp_ogon.scan_coor_ogon();
            if (typpla == typ_plaer.typ_player)
                this.hellp_ogon.scan_coor_ogon();
        }
        Vector3 tereba(Vector3 bb)
        {
            if (this.calc_rasch)
                return this.do_root;
            StartCoroutine(doiit());
            return this.do_root;
        }
        IEnumerator doiit()
        {
            this.calc_rasch = true;
            this.do_root = new Vector3(Random.Range(10, 360), Random.Range(10, 360), Random.Range(10, 360));
            yield return new WaitForSeconds(Random.Range(1.1f, 2.8f));
            this.calc_rasch = false;
        }
        
        public plater1()
        {
            this.do_root = new Vector3();
            this.calc_rasch = false;
            this.hellp_1 = new help_1(this.anim_);
            this.hellp_2 = new help_2(this.hellp_1);
            this.hellp_3 = new help_3();
            this.hellp_stte = new help_sten(this.hellp_1);
            this.hellp_table = new tablet(this.hellp_1);
            this.hellp_ogon = new ogon_s(this.hellp_1);
            this.hellp_ogon.day_coruut = tereba;
            this.hellp_ogon.udar_enem = this.do_damag_ene_udar_ogon;
        }
        void Update()
        {
            this.hellp_1.do_anim_pokoi();
            this.check_init();
            this.chhe_robo();
            this.hellp_2.do_command_hit();
            this.hellp_stte.do_command_bild();
            this.hellp_table.do_command_lekar();
            this.hellp_ogon.do_command_ogon();
        }
        public void after_boi_ogon()
        {
            this.hellp_ogon.do_cooman_after_boi_ogon();
        }
        public void do_coom_ogon()
        {
            this.hellp_ogon.set_comand_hit();
            
        }
        public void after_lecar()
        {
            this.hellp_table.do_cooman_after_lekar();
        }
        public void after_built()
        {
            this.hellp_stte.do_cooman_after_built();
        }
        public void do_real_damag_hit()
        {
            this.hellp_2.do_real_damag();
        }
        public void do_coom_hit()
        {
            this.hellp_2.set_comand_hit();
            
        }

        public void chhe_robo()
        {
            if (typpla != typ_plaer.ryp_enemy)
            {
                return;
            }
            if (new System.Random().Next(0, 100) < 25)
            {
                this.hellp_stte.set_comand_built(); 
            }
            if (new System.Random().Next(0, 100) < 25)
                {
                    this.hellp_2.set_comand_hit(); 
                }
            if (new System.Random().Next(0, 100) < 25)
            {
                this.hellp_table.set_comand_lecar(); 
            }
            if (new System.Random().Next(0, 100) < 25)
            {
                this.hellp_ogon.set_comand_hit(); 
            }
            
        }
        public void do_coom_lekar()
        {
            this.hellp_table.set_comand_lecar();
        }
        public void do_coom_bilt()
        {
            this.hellp_stte.set_comand_built();
        }
        public mode_main get_mode_main
        {
            get
            {
                return this.hellp_1.ma_res;
            }
        }
        public void set_wait()
        {
            this.hellp_2.set_wait();
        }
        public void set_wait_sten()
        {
            this.hellp_stte.set_wait();
        }


        

        public void have_damag_ini(int val)
        {
            this.anim_.SetBool("stay",true);
            this.anim_.SetTrigger("upal");
            //Debug.Log("pla " + typpla.ToString() + " upal");
        }
        public void do_damag_ene_udar(int val)
        {
            plater1 olaene=this.enemm.GetComponent<plater1>();
            this.do_real_damag_hit();
            olaene.have_damag_ini(val);
        }
        public void do_damag_ene_udar_ogon(int val)
        {
            plater1 olaene=this.enemm.GetComponent<plater1>();
            this.hellp_ogon.do_real_damag();
            olaene.have_damag_ini(val);
        }
        
        void check_init()
        {
            if (this.hellp_1.use_1_anim)
            {
                
                this.anim_.SetTrigger("smeh");
            }
            if (this.hellp_1.use_2_anim)
            {
                
                this.anim_.SetTrigger("muha");
            }
        }
       
        
    }
}
