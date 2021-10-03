using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;
using System.Linq;

namespace HackedDesign
{
    [RequireComponent(typeof(Rigidbody))]
    public class Enemy : MonoBehaviour
    {
        [SerializeField] public EnemyTypes type;
        //[SerializeField] public GameData data;
        [SerializeField] public float health;
        [SerializeField] private NavMeshAgent agent;
        //[SerializeField] private List<Weapon> weapons;
        [SerializeField] private Transform turret;
        [SerializeField] private float rotateSpeed = 60;
        [SerializeField] private float attackRange = 20;
        [SerializeField] private Transform healthBar;

        private Animator animator;

        private WeaponsController weapons;
        private float nextBehaviourShift = 0;
        private float nextWeaponShift = 0;
        private Vector3 target;
        private float currentHealth;

        void Awake()
        {
            agent = GetComponent<NavMeshAgent>();
            animator = GetComponent<Animator>();
            weapons = GetComponent<WeaponsController>();
        }

        public void Spawn()
        {
            agent.SetDestination(Vector3.zero);
            weapons.rightArmWeapon = GameManager.Instance.GameSettings.armWeapons[type][Random.Range(0, GameManager.Instance.GameSettings.armWeapons[type].Length)];
            weapons.leftArmWeapon = GameManager.Instance.GameSettings.armWeapons[type][Random.Range(0, GameManager.Instance.GameSettings.armWeapons[type].Length)];
            weapons.rightShoulderWeapon = GameManager.Instance.GameSettings.shoulderWeapons[type][Random.Range(0, GameManager.Instance.GameSettings.shoulderWeapons[type].Length)];
            weapons.leftShoulderWeapon = GameManager.Instance.GameSettings.shoulderWeapons[type][Random.Range(0, GameManager.Instance.GameSettings.shoulderWeapons[type].Length)];
            currentHealth = health;
            weapons.UpdateWeapons();
        }

        public void UpdateBehaviour()
        {
            if (gameObject.activeInHierarchy)
            {
                var playerDistance = (transform.position - GameManager.Instance.Player.transform.position).sqrMagnitude;
                var baseDistance = (transform.position - Vector3.zero).sqrMagnitude;
                var attackSqr = attackRange * attackRange;

                if (Time.time < nextBehaviourShift)
                {
                    nextBehaviourShift = Time.time + GameManager.Instance.GameSettings.behaviourShiftTime;
                    var dest = Random.insideUnitCircle * GameManager.Instance.GameSettings.baseExplosionRadius;
                    agent.SetDestination(new Vector3(dest.x, 0, dest.y));
                }

                //agent.isStopped = playerDistance < baseDistance || CheckInRange();

                UpdateTurret(playerDistance < baseDistance ? GameManager.Instance.Player.transform.position : Vector3.zero);

                if (playerDistance < baseDistance ? (playerDistance < attackSqr) : (baseDistance < attackSqr))
                {
                    weapons.FireCurrentWeapon();
                    if (Time.time > nextWeaponShift)
                    {
                        nextWeaponShift = Time.time + GameManager.Instance.GameSettings.enemySwitchWeapon;
                        weapons.NextWeapon();
                    }
                }
                UpdateHealthBar();

                Animate();
            }
        }

        private void UpdateTurret(Vector3 target)
        {
            var rotation = Quaternion.LookRotation((target - transform.position), Vector3.up);
            //var forward = .normalized;
            var targetAngle = Quaternion.Euler(0, rotation.eulerAngles.y, 0);

            //turret.transform.forward = new Vector3(forward.x, 0, forward.z);
            turret.rotation = Quaternion.Lerp(turret.rotation, targetAngle, rotateSpeed * Time.deltaTime);
        }

        private bool CheckInRange() => !gameObject.activeInHierarchy || (transform.position - Vector3.zero).sqrMagnitude < (GameManager.Instance.GameSettings.stopRange * GameManager.Instance.GameSettings.stopRange);

        public void Damage(float amount)
        {
            currentHealth -= amount;

            if (currentHealth <= 0)
            {
                Debug.Log("Enemy destroyed");
                Explode();
            }
        }

        private void UpdateHealthBar()
        {
            var scale = healthBar.localScale;
            scale.x = currentHealth / health;
            if (healthBar != null)
            {
                healthBar.localScale = scale;
            }
        }

        private void Animate()
        {
            if (animator != null)
            {
                animator.SetFloat("Speed", agent.velocity.magnitude);
            }
        }

        private void Explode()
        {
            GameManager.Instance.Enemies.SpawnDestroyedEnemy(this);
            GameManager.Instance.EntityPool.SpawnExplosion(this.transform.position);
            gameObject.SetActive(false);
        }

    }
}