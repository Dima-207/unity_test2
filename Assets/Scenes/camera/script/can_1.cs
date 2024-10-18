using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace cam_obrab
{
    
    public class can_1 : MonoBehaviour
    {
        public Transform playe;
        public Transform enem;
        private Vector3 vec_its;
        private bool rehect;
        private float ditancee = 11;
        public float sperot = 2;
        private Vector3 vve;
        void Start()
        {

        }

        IEnumerator besca()
        {
            this.vve = this.get_ve();
            this.vve.y = vve.y + Random.Range(1.3f, 4.9f);
            this.vve.z += Random.Range(-33.2f, 33.3f);
            this.vve.x += Random.Range(-33.2f, 33.3f);
            this.rehect = true;
            yield return new WaitForSeconds(Random.Range(11.3f, 21.9f));
            
            this.rehect = false;
        }
        Vector3 get_aim_tr()
        {
            if (!this.rehect)
            {
                StartCoroutine(besca());
            }
            return this.vve;
        }
        void do_Rotat()
        {
            Vector3 gg = get_ve();
            Vector3 vv = transform.position - gg;
            vv = vv.normalized*ditancee;
            transform.RotateAround(gg,vv,sperot);
        }
        Vector3 get_ve()
        {
            Vector3 vv = playe.position;
            Vector3 caal = playe.position - enem.position;
            caal /= 5;
            vv += caal;
            return vv;
        }
        // Update is called once per frame
        void Update()
        {
            transform.LookAt(this.get_ve());
            Vector3 direction = (get_aim_tr() - transform.position);
            if (direction.sqrMagnitude < 3)
            {
                this.rehect = false;
            }
                
            transform.position += direction.normalized * sperot * Time.deltaTime;
        }
    }
}
