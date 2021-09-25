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

        private void Awake()
        {
            rigidbody = GetComponent<Rigidbody>();
        }

        public void Fire(GameObject firer)
        {
            this.firer = firer;
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
                Debug.Log("Explode");
                Explode();
            }
        }

        private void Explode()
        {
            
            this.gameObject.SetActive(false);
        }
    }
}