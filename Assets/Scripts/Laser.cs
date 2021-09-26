using System.Collections.Generic;
using UnityEngine;

namespace HackedDesign
{
    public class Laser : MonoBehaviour
    {
        [SerializeField] LayerMask mask;
        private LineRenderer line;
        private GameObject firer;
        private float timeout = 0.1f;

        private void Awake()
        {
            line = GetComponent<LineRenderer>();
            //rigidbody = GetComponent<Rigidbody>();
        }

        public void Fire(GameObject firer, float damage)
        {
            timeout = 0.1f;
            this.firer = firer;
            UnityEngine.Debug.Log("Fire laser");

            RaycastHit hit;

            float distance = 100;

            if (Physics.Raycast(transform.position, transform.forward, out hit, distance, mask, QueryTriggerInteraction.Ignore))
            {
                distance = (hit.point - transform.position).magnitude;

                if(hit.transform && hit.transform.gameObject.CompareTag("Enemy"))
                {
                    var e = hit.transform.gameObject.GetComponent<Enemy>();
                    e.Damage(damage);
                }
            }

            List<Vector3> positions = new List<Vector3>();
            positions.Add(transform.position);
            for (int i = 1; i < Mathf.CeilToInt(distance); i++)
            {
                positions.Add(transform.position + (transform.forward * i));
            }

            positions.Add(transform.position + (transform.forward * distance));
            var array = positions.ToArray();
            line.positionCount = array.Length; 
            line.SetPositions(array);
            line.enabled = true;
            
        }

        private void Update()
        {
            timeout -= Time.deltaTime;
            if (timeout <= 0)
            {
                Explode();
            }
        }

        /*
        private void OnTriggerEnter(Collider other)
        {
            if (!other.isTrigger && other.gameObject != this.firer)
            {
                Debug.Log("Explode");
                Explode();
            }
        }*/

        private void Explode()
        {

            this.gameObject.SetActive(false);
        }
    }
}