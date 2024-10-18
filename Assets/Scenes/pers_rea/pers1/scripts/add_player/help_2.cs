using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace play_sheme
{
    public class help_2 : MonoBehaviour
    {
        private help_1 hellp_1;
        private Transform enemm;
        public Transform maiin;
        private typ_plaer typpla;
        private Animator aan;
        public float sppe;

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

        public void do_real_damag()
        {
            if (typpla == typ_plaer.typ_player)
                help_3.heal_enemy.set_damag(help_3.udar_playe.val_damag);
            if (typpla == typ_plaer.ryp_enemy)
                help_3.heal_playe.set_damag(help_3.udar_enemy.val_damag);
            this.hellp_1.ma_do_hit = do_mod_hit.do_return;
        }
        public void do_coommand_run_hit()
        {
            if(this.hellp_1.ma_do_hit!=do_mod_hit.do_begiin)
                return;
            this.maiin.position = Vector3.MoveTowards(this.maiin.position, enemm.position, this.sppe* Time.deltaTime);
            if ((this.maiin.position - enemm.position).sqrMagnitude < 2)
            {
                this.hellp_1.ma_do_hit=do_mod_hit.do_hit;
                this.aan.SetBool("stay",true);
            }
            //Debug.Log("transform.position="+this.maiin.position);
        }
        public void do_coommand_simp_hit()
        {
            if(this.hellp_1.ma_do_hit!=do_mod_hit.do_hit)
                return;
            this.hellp_1.ma_do_hit = do_mod_hit.do_after_hit;
                this.aan.SetTrigger("kik");
                this.aan.SetBool("stay",true);
            
            //Debug.Log("transform.position="+this.maiin.position);
        }
        public void do_command_hit()
        {
            if (this.hellp_1.ma_res != mode_main.mode_action )
            {
                return;
            } 
            //Debug.Log("do start hit "+this.hellp_1.ma_do_hit.ToString());
            this.do_coommand_run_hit();
            this.do_coommand_simp_hit();
            
        }
        public help_2(help_1 hehe)
        {
            this.hellp_1 = hehe;
            this.sppe = 7.1f;
        }

        public void set_param(Transform oob)
        {
            this.enemm = oob;
        }
        public void set_wait()
        {
            if(this.hellp_1.ma_res!=mode_main.mode_init)
                return;
            this.hellp_1.ma_res = mode_main.mode_wait;
            if (typpla == typ_plaer.ryp_enemy)
            {
                this.set_comand_hit();
            }
            
        }

        public void set_comand_hit()
        {
            if (this.hellp_1.ma_res != mode_main.mode_wait)
            {
                return;
            }
            this.hellp_1.ma_res = mode_main.mode_action;
            if (this.hellp_1.ma_do_hit == do_mod_hit.do_off)
            {
                this.aan.SetBool("stay",false);
                this.aan.SetTrigger("ruun");
                //Debug.Log("do run amation");
            }
            this.hellp_1.ma_do_hit = do_mod_hit.do_begiin;
        }
        
    }
}


