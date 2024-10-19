using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace play_sheme
{
    public class ogon_s : MonoBehaviour
    {
        private help_1 hellp_1;
        private Transform enemm;
        private Vector3 enemm_beg;
        public Transform maiin;
        private typ_plaer typpla;
        private Animator aan;
        public float sppe;
        private Vector3 nachal_positi;
        private Vector3 ogon_posi;
        private Vector3 aim_ogon_vverh;
        private Transform ogon_boit;
        private bool calc_rasch;
        private Vector3 do_root;
        public delegate Vector3 ncorut(Vector3 bb);
        public delegate void nudar(int vaal);

        public ncorut day_coruut;
        public nudar udar_enem ;
        public ogon_s(help_1 hehe)
        {
            this.do_root = new Vector3();
            this.calc_rasch = false;
            this.hellp_1 = hehe;
            this.sppe = 3.1f;
        }

        
        public void do_command_ogon()
        {
            if (this.hellp_1.ma_res != mode_main.mode_action )
            {
                return;
            } 
            this.do_coommand_run_ogon(); 
            this.do_coommand_simp_ogon();
            this.do_coommand_ogon_vverh();
            this.do_coommand_ogon_cell();
            this.do_coommand_ogon_cell_end();
            this.do_coommand_simp_return();/**/

        }
        public void do_coommand_simp_return()
        {
            if(this.hellp_1.ma_boi_ogon!=do_ogon_boi.ts_return)
                return;
            
            this.maiin.position = Vector3.MoveTowards(this.maiin.position, nachal_positi, this.sppe* Time.deltaTime);
            if ((this.maiin.position - nachal_positi).sqrMagnitude < 0.2f)
            {
                this.hellp_1.ma_boi_ogon = do_ogon_boi.its_off;
                this.hellp_1.ma_res = mode_main.mode_init;
                help_3.all_decrease();
                this.aan.SetBool("stay",true);
            }
            //Debug.Log("transform.position="+this.maiin.position);
        }
        public void do_real_damag()
        {
            if (typpla == typ_plaer.typ_player)
                help_3.heal_enemy.set_damag(help_3.player_ogon.get_first_hit-
                                            help_3.enemy_sten.get_defense);
            if (typpla == typ_plaer.ryp_enemy)
                help_3.heal_playe.set_damag(help_3.enemy_ogon.get_first_hit-
                                            help_3.player_sten.get_defense);
            this.hellp_1.ma_boi_ogon = do_ogon_boi.ts_return;
            this.aan.SetBool("stay",false);
        }
        public void do_coommand_ogon_cell_end()
        {
            if(this.hellp_1.ma_boi_ogon!=do_ogon_boi.do_end_aim_ogon)
                return;
            if(typpla == typ_plaer.typ_player)
            {
                this.udar_enem(help_3.player_ogon.get_first_hit);
                help_3.player_ogon.get_simp_ogon.position = ogon_posi;
                help_3.player_ogon.get_main_ogon.SetActive(false);
            }
            if(typpla == typ_plaer.ryp_enemy)
            {
                this.udar_enem(help_3.enemy_ogon.get_first_hit);
                help_3.enemy_ogon.get_simp_ogon.position = ogon_posi;
                help_3.enemy_ogon.get_main_ogon.SetActive(false);
            }
        }

        public void do_coommand_ogon_cell()
        {
            if(this.hellp_1.ma_boi_ogon!=do_ogon_boi.do_aim_ogon)
                return;
            this.do_root=this.day_coruut(this.do_root);
            Quaternion targetRotation = Quaternion.Euler(this.do_root);
            ogon_boit.rotation = Quaternion.Slerp(ogon_boit.rotation, targetRotation,1.5f* Time.deltaTime);
            this.ogon_boit.position = Vector3.MoveTowards(this.ogon_boit.position, this.enemm.position, 3.4f* Time.deltaTime);
            if ((this.ogon_boit.position - this.enemm.position).sqrMagnitude < 0.1f)
                this.hellp_1.ma_boi_ogon = do_ogon_boi.do_end_aim_ogon;
        }
        public void do_coommand_ogon_vverh()
        {
            if(this.hellp_1.ma_boi_ogon!=do_ogon_boi.do_vverh_ogon)
                return;
            
            this.do_root=this.day_coruut(this.do_root);
            bool dotre = true;
            if (this.ogon_boit.localScale.sqrMagnitude < 1)
            {
                dotre = false;
                this.ogon_boit.localScale += new Vector3(Random.Range(0.01f, 0.03f), Random.Range(0.01f, 0.03f),
                    Random.Range(0.01f, 0.03f));
            }
            Quaternion targetRotation = Quaternion.Euler(this.do_root);
            ogon_boit.rotation = Quaternion.Slerp(ogon_boit.rotation, targetRotation,0.5f* Time.deltaTime);
            this.ogon_boit.position = Vector3.MoveTowards(this.ogon_boit.position, this.aim_ogon_vverh, 1.4f* Time.deltaTime);
            if ((this.aim_ogon_vverh - this.ogon_boit.position).sqrMagnitude < 0.1f&&dotre)
                this.hellp_1.ma_boi_ogon = do_ogon_boi.do_aim_ogon;
        }

        
        public void do_cooman_after_boi_ogon()
        {
            if(this.hellp_1.ma_boi_ogon!=do_ogon_boi.do_after_boi)
                return;
            this.hellp_1.ma_boi_ogon = do_ogon_boi.do_vverh_ogon;
            this.aan.SetBool("stay",true);
            if (this.typpla == typ_plaer.typ_player)
            {
                this.ogon_boit = help_3.player_ogon.get_simp_ogon;
                help_3.player_ogon.birth_new();
            }   
            if (this.typpla == typ_plaer.ryp_enemy)
            {
                this.ogon_boit = help_3.enemy_ogon.get_simp_ogon;
                help_3.enemy_ogon.birth_new();
            }
            this.ogon_boit.localScale = new Vector3(1, 1, 1) * 0.4f;
            this.aim_ogon_vverh=this.ogon_boit.position+new Vector3(0, 1, 0) * 4f;
        }
        public void do_coommand_simp_ogon()
        {
            if(this.hellp_1.ma_boi_ogon!=do_ogon_boi.do_boi)
                return;
            this.hellp_1.ma_boi_ogon = do_ogon_boi.do_after_boi;
            this.aan.SetTrigger("ogon");
            this.aan.SetBool("stay",true);
            
            //Debug.Log("transform.position="+this.maiin.position);
        }
        public void do_coommand_run_ogon()
        {
            if(this.hellp_1.ma_boi_ogon!=do_ogon_boi.ts_begiin)
                return;
            this.maiin.position = Vector3.MoveTowards(this.maiin.position, ogon_posi, this.sppe* Time.deltaTime);
            if ((this.maiin.position - ogon_posi).sqrMagnitude < 1)
            {
                this.hellp_1.ma_boi_ogon=do_ogon_boi.do_boi;
                this.aan.SetBool("stay",true);
            }
        }
        public void set_comand_hit()
        {
            if (this.hellp_1.ma_res != mode_main.mode_wait)
            {
                return;
            }
            this.hellp_1.ma_res = mode_main.mode_action;
            if (this.hellp_1.ma_boi_ogon == do_ogon_boi.its_off)
            {
                this.aan.SetBool("stay",false);
                this.aan.SetTrigger("ruun");
                //Debug.Log("do run amation");
            }
            this.hellp_1.ma_boi_ogon = do_ogon_boi.ts_begiin;
        }
        public void scan_coor_ogon()
        {
            if (typpla == typ_plaer.ryp_enemy)
            {
                this.ogon_posi = help_3.enemy_ogon.get_main_ogon.GetComponent<Transform>().position;
            }
            if (typpla == typ_plaer.typ_player)
            {
                this.ogon_posi = help_3.player_ogon.get_main_ogon.GetComponent<Transform>().position;
            }
            
        }
        public void inti_begin_posi()
        {
            this.nachal_positi = this.maiin.position;
            this.enemm_beg=this.enemm.position;
        }
        public typ_plaer set_tipl
        {
            set
            {
                this.typpla = value;
            }
        }
        public void set_param(Transform oob)
        {
            this.enemm = oob;
        }
        public Animator set_antor
        {
            set
            {
                this.aan = value;
            }
        }
    }

}


