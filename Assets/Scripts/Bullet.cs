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
            if (timeout <= 0)
            {
                Explode(this.transform.position);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.isTrigger && other.gameObject != this.firer)
            {
                if (other != null && other.CompareTag("Enemy"))
                {
                    var e = other.GetComponentInParent<Enemy>();
                    if (e != null)
                    {
                        e.Damage(this.damage);
                    }
                    else
                    {
                        Debug.LogError("untagged enemy error");
                    }

                }
                if (other != null && this.firer != null && other.CompareTag("Player") && !this.firer.CompareTag("Player"))
                {
                    GameManager.Instance.DamageArmour(damage);
                }
                if (other.gameObject != null && this.firer.gameObject != null && other.CompareTag("Base") && !this.firer.CompareTag("Player"))
                {
                    GameManager.Instance.DamageBase(damage);
                }

                Explode(this.transform.position);
            }
        }

        private void OnCollisionEnter(Collision other)
        {
            if (!other.collider.isTrigger && other.collider.gameObject != this.firer)
            {
                if (other.collider.CompareTag("Enemy"))
                {
                    var e = other.collider.GetComponent<Enemy>();
                    e.Damage(this.damage);
                }
                if (other.collider.CompareTag("Base") && !this.firer.CompareTag("Player"))
                {
                    GameManager.Instance.DamageBase(damage);
                }
                if (other.collider.CompareTag("Player") && !this.firer.CompareTag("Player"))
                {
                    GameManager.Instance.DamageArmour(damage);
                }
                Explode(this.transform.position);
            }
        }

        private void Explode(Vector3 position)
        {
            GameManager.Instance.EntityPool.SpawnMiniExplosion(position);
            this.gameObject.SetActive(false);
        }
    }
}