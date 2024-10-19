using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace play_sheme
{
    public class tablet : MonoBehaviour
    {
        private help_1 hellp_1;
        private Transform enemm;
        private Vector3 enemm_beg;
        public Transform maiin;
        private typ_plaer typpla;
        private Animator aan;
        public float sppe;
        private Vector3 nachal_positi;
        private Vector3 lekar_posi;
        
        public tablet(help_1 hehe)
        {
            this.hellp_1 = hehe;
            this.sppe = 4.1f;
        }
        public void do_command_lekar()
        {
            if (this.hellp_1.ma_res != mode_main.mode_action )
            {
                return;
            } 
            this.do_coommand_run_lekar(); 
            this.do_coommand_simp_lekar();
            this.do_coommand_simp_return();

        }
        public void do_coommand_simp_return()
        {
            if(this.hellp_1.ma_rekar!=do_lekar_repai.ts_return)
                return;
            
            this.maiin.position = Vector3.MoveTowards(this.maiin.position, nachal_positi, this.sppe* Time.deltaTime);
            if ((this.maiin.position - nachal_positi).sqrMagnitude < 0.2f)
            {
                this.hellp_1.ma_rekar = do_lekar_repai.its_off;
                this.hellp_1.ma_res = mode_main.mode_init;
                help_3.all_decrease();
                this.aan.SetBool("stay",true);
            }
            //Debug.Log("transform.position="+this.maiin.position);
        }
        public void do_cooman_after_lekar()
        {
            if (this.typpla == typ_plaer.typ_player)
            {
                help_3.player_tablet.birth_new();
            }   
            if (this.typpla == typ_plaer.ryp_enemy)
            {
                help_3.enemy_tablet.birth_new();
            } 
            this.hellp_1.ma_rekar = do_lekar_repai.ts_return;
            this.aan.SetBool("stay",false);
            this.aan.SetTrigger("ruun");
        }
        public void do_coommand_simp_lekar()
        {
            if(this.hellp_1.ma_rekar!=do_lekar_repai.do_lekar)
                return;
            this.hellp_1.ma_rekar = do_lekar_repai.do_after_lekar;
            this.aan.SetTrigger("balet");
            this.aan.SetBool("stay",true);
            
            //Debug.Log("transform.position="+this.maiin.position);
        }
        public void do_coommand_run_lekar()
        {
            if(this.hellp_1.ma_rekar!=do_lekar_repai.ts_begiin)
                return;
            this.maiin.position = Vector3.MoveTowards(this.maiin.position, lekar_posi, this.sppe* Time.deltaTime);
            if ((this.maiin.position - lekar_posi).sqrMagnitude < 1)
            {
                this.hellp_1.ma_rekar=do_lekar_repai.do_lekar;
                this.aan.SetBool("stay",true);
            }
        }
        public void set_comand_lecar()
        {
            if (this.hellp_1.ma_res != mode_main.mode_wait)
            {
                return;
            }
            this.hellp_1.ma_res = mode_main.mode_action;
            if (this.hellp_1.ma_rekar == do_lekar_repai.its_off)
            {
                this.aan.SetBool("stay",false);
                this.aan.SetTrigger("ruun");
                //Debug.Log("do run amation");
            }
            this.hellp_1.ma_rekar = do_lekar_repai.ts_begiin;
        }
        public void scan_coor_lekar()
        {
            Vector3 mww = this.nachal_positi - this.enemm_beg;
            mww = mww / Random.Range(3.4f,6.3f);
            this.lekar_posi = this.nachal_positi - mww;
            Vector3 axis = new Vector3(0, 1, 0);
            Vector3 perpendicular = Vector3.Cross(this.lekar_posi, axis);
            this.lekar_posi= perpendicular;
            if (Random.Range(0.01f, 2.02f) < 1)
            {
                this.lekar_posi *= -1;
            }; // ось, с которой мы берем векторное произведение
            
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
            this.enemm_beg=this.enemm.position;
        }
    }
}