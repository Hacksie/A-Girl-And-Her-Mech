using UnityEngine;

namespace HackedDesign
{
    [RequireComponent(typeof(Rigidbody))]
    public class Bullet : MonoBehaviour
    {
        [SerializeField] float speed;
        private new Rigidbody rigidbody;
        private GameObject firer;
        private float timeout = 3;
        private float damage = 0;

        private void Awake()
        {
            rigidbody = GetComponent<Rigidbody>();
        }

        public void Fire(GameObject firer, float damage)
        {
            timeout = 3;
            this.firer = firer;
            this.damage = damage;
            rigidbody.velocity = Vector3.zero;
            rigidbody.AddForce(transform.forward * speed, ForceMode.Impulse);
        }

        private void Update()
        {
            timeout -= Time.deltaTime;
            if(timeout <= 0)
            {
                Explode();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.isTrigger && other.gameObject != this.firer)
            {
                if(other.CompareTag("Enemy"))
                {
                    var e = other.GetComponent<Enemy>();
                    e.Damage(this.damage);
                }
                //Debug.Log("Explode");


                Explode();
            }
        }

        private void Explode()
        {
            
            this.gameObject.SetActive(false);
        }
    }
}