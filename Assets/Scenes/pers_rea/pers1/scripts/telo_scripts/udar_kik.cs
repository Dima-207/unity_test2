using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace play_sheme
{
    public class udar_kik : MonoBehaviour
    {
        public plater1 pla;
        public void ud_kik()
        {
            this.pla.do_damag_ene_udar(help_3.udar_playe.val_damag);
        }
    }
}

