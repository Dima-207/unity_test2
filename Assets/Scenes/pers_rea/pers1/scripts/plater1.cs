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
        private help_1 hellp_1;
        private help_2 hellp_2;
        private help_3 hellp_3;
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
        public plater1()
        {
            this.hellp_1 = new help_1(this.anim_);
            this.hellp_2 = new help_2(this.hellp_1);
            this.hellp_3 = new help_3();
        }
        public void do_real_damag_hit()
        {
            this.hellp_2.do_real_damag();
        }
        public void do_coom_hit()
        {
            this.hellp_2.set_comand_hit();
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


        void Start()
        {
            this.hellp_2.sppe = this.speed_pla;
            this.hellp_1.set_param(anim_);
            this.hellp_2.set_param(enemm);
            this.hellp_2.set_antor = this.anim_;
            this.hellp_2.set_tipl = typpla;
            this.hellp_2.maiin = transform;
            if(typpla==typ_plaer.typ_player)
            {
                this.hellp_3.set_healths(200, this.he_sca_player,heat_playe_tex,
                    200, this.he_sca_enemy,heat_enemy_tex);
                this.hellp_3.set_init_udar(8, this.tex_player,
                    8, this.tex_enemy);
            }
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
        void Update()
        {
            this.hellp_1.do_anim_pokoi();
            this.check_init();
            this.hellp_2.do_command_hit();
        }
    }
}
