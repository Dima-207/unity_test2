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
        public float sperot = 7;
        private Vector3 vve;
        void Start()
        {

        }

        Vector3 get_better()
        {
            Vector3 vbn = (enem.position - playe.position)/3;
            vbn = playe.position - vbn;
            vbn += new Vector3(Random.Range(1.2f, 6.4f), Random.Range(2.2f, 3.4f), Random.Range(2.2f, 6.4f));
            return vbn;
        }
        IEnumerator besca()
        {
            int rebb = new System.Random().Next(0, 30);
            this.vve = this.get_ve();
            this.vve.y = vve.y + Random.Range(1.3f, 4.9f);
            if(rebb<14)
            {
                this.vve.z += Random.Range(-33.2f, 33.3f);
                this.vve.x += Random.Range(-33.2f, 33.3f);
            }
            else
            {
                if (rebb < 74)
                    this.vve = get_better();
                else
                {
                    this.vve.z += Random.Range(-6.2f, 6.3f);
                    this.vve.x += Random.Range(-6.2f, 6.3f);
                }
                
            }
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
            vv -= caal;
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
