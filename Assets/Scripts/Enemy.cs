using UnityEngine;
using UnityEngine.AI;

namespace HackedDesign
{
    [RequireComponent(typeof(Rigidbody))]
    public class Enemy : MonoBehaviour
    {
        [SerializeField] public EnemyTypes types;
        [SerializeField] public float health;
        [SerializeField] private NavMeshAgent agent;

        void Awake()
        {
            agent = GetComponent<NavMeshAgent>();
        }

        public void Spawn()
        {
            agent.SetDestination(Vector3.zero);
        }

        public void UpdateBehaviour()
        {
            CheckInRange();
            var playerDistance = (transform.position - GameManager.Instance.Player.transform.position).sqrMagnitude;
            var baseDistance = (transform.position - Vector3.zero).sqrMagnitude;

            if(playerDistance < baseDistance)
            {
                Debug.Log("Targeting player");
            }
            else
            {
                Debug.Log("Targeting base");
            }
        }

        private void CheckInRange()
        {
            var settings = GameManager.Instance.GameSettings;
            if (gameObject.activeInHierarchy)
            {
                if ((transform.position - Vector3.zero).sqrMagnitude < (settings.stopRange * settings.stopRange))
                {
                    agent.isStopped = true;
                }
            }
        }

        public void Damage(float amount)
        {
            health -= amount;

            if (health <= 0)
            {
                Debug.Log("Enemy destroyed");
                gameObject.SetActive(false);
                //Destroy(gameObject);
            }
        }

    }
}