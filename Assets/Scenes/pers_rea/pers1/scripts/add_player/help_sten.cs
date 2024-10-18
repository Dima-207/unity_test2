using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace play_sheme
{
    public class help_sten : MonoBehaviour
    {
        private help_1 hellp_1;
        private Transform enemm;
        public Transform maiin;
        private typ_plaer typpla;
        private Animator aan;
        public float sppe;
        private Vector3 nachal_positi;
        private Vector3 build_posi;
        
        public help_sten(help_1 hehe)
        {
            this.hellp_1 = hehe;
            this.sppe = 4.1f;
        }
        public void do_coommand_simp_return()
        {
            if(this.hellp_1.ma_build!=do_build_wall.ts_return)
                return;
            
            this.maiin.position = Vector3.MoveTowards(this.maiin.position, nachal_positi, this.sppe* Time.deltaTime);
            if ((this.maiin.position - nachal_positi).sqrMagnitude < 0.2f)
            {
                this.hellp_1.ma_build = do_build_wall.its_off;
                this.hellp_1.ma_res = mode_main.mode_init;
                help_3.all_decrease();
                this.aan.SetBool("stay",true);
            }
            //Debug.Log("transform.position="+this.maiin.position);
        }
        public void set_comand_built()
        {
            if (this.hellp_1.ma_res != mode_main.mode_wait)
            {
                return;
            }
            this.hellp_1.ma_res = mode_main.mode_action;
            if (this.hellp_1.ma_build == do_build_wall.its_off)
            {
                this.aan.SetBool("stay",false);
                this.aan.SetTrigger("ruun");
                //Debug.Log("do run amation");
            }
            this.hellp_1.ma_build = do_build_wall.ts_begiin;
        }

        public void do_cooman_after_built()
        {
            if (this.typpla == typ_plaer.typ_player)
            {
                help_3.player_sten.birth_new();
            }   
            if (this.typpla == typ_plaer.ryp_enemy)
            {
                help_3.enemy_sten.birth_new();
            } 
            this.hellp_1.ma_build = do_build_wall.ts_return;
            this.aan.SetBool("stay",false);
            this.aan.SetTrigger("ruun");
        }
        public void do_command_bild()
        {
            if (this.hellp_1.ma_res != mode_main.mode_action )
            {
                return;
            } 
            this.do_coommand_run_build(); 
            this.do_coommand_simp_bilt();
            this.do_coommand_simp_return();

        }
        public void do_coommand_simp_bilt()
        {
            if(this.hellp_1.ma_build!=do_build_wall.do_bild)
                return;
            this.hellp_1.ma_build = do_build_wall.do_after_bild;
            this.aan.SetTrigger("stena");
            this.aan.SetBool("stay",true);
            
            //Debug.Log("transform.position="+this.maiin.position);
        }
        public void do_coommand_run_build()
        {
            if(this.hellp_1.ma_build!=do_build_wall.ts_begiin)
                return;
            this.maiin.position = Vector3.MoveTowards(this.maiin.position, build_posi, this.sppe* Time.deltaTime);
            if ((this.maiin.position - build_posi).sqrMagnitude < 1)
            {
                this.hellp_1.ma_build=do_build_wall.do_bild;
                this.aan.SetBool("stay",true);
            }
        }
        public void scan_coor_main()
        {
            Vector3 mww = maiin.position - this.enemm.position;
            mww = mww / 7;
            this.build_posi = this.maiin.position - mww;
        }
        public void set_param(Transform oob)
        {
            this.enemm = oob;
        }
        public void set_comand_build()
        {
            if (this.hellp_1.ma_res != mode_main.mode_wait)
            {
                return;
            }
            this.hellp_1.ma_res = mode_main.mode_action;
            if (this.hellp_1.ma_build ==do_build_wall.its_off)
            {
                this.aan.SetBool("stay",false);
                this.aan.SetTrigger("ruun");
                //Debug.Log("do run amation");
            }
            this.hellp_1.ma_build = do_build_wall.ts_begiin;
        }
        public void set_wait()
        {
            if(this.hellp_1.ma_res!=mode_main.mode_init)
                return;
            this.hellp_1.ma_res = mode_main.mode_wait;
            if (typpla == typ_plaer.ryp_enemy&&
                new System.Random().Next(0,100)<25)
            {
                //this.set_comand_hit();
            }
            
        }
        
        public Animator set_antor
        {
            set
            {
                this.aan = value;
            }
        }
        public typ_plaer set_tipl
        {
            set
            {
                this.typpla = value;
            }
        }

        public void inti_begin_posi()
        {
            this.nachal_positi = this.maiin.position;
        }
    }
}


