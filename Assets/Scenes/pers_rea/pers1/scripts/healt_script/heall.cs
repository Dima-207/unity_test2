using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace space_healt
{
    public class heall : MonoBehaviour
    {
        public GameObject maiin;
        private Transform trr;
        private Vector3 ve_obg;
        public float val_vise = 1.7f;
        public float spe_rot = 2.1f;
        void Start()
        {
            this.trr = this.maiin.GetComponent<Transform>();
        }

        
        void do_rotate()
        {
            transform.Rotate(Vector3.up,this.spe_rot);
        }
        void ini_vec()
        {
            this.ve_obg = this.trr.position;
            this.ve_obg.y += val_vise;
            transform.position = this.ve_obg;
        }
        
        void Update()
        {
            ini_vec();
            do_rotate();
            //Debug.Log("pos="+transform.position.ToString());
        }
    }
}
