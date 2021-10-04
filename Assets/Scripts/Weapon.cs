using UnityEngine;

namespace HackedDesign
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] public GameObject parent;
        [SerializeField] public WeaponType type;
        [SerializeField] public Transform firePoint;
        [SerializeField] public int ammo = 0;
        [SerializeField] public int maxAmmo = 0;
        [SerializeField] public AmmoType ammoType;
        [SerializeField] public float fireRate = 0;
        [SerializeField] public float damage = 10;
        [SerializeField] public float heat = 10;
        [SerializeField] public Sprite sprite;
        [SerializeField] public bool isPlayer = false;

        private float nextFireTime = 0;

        public bool Fire()
        {
            if (Time.time >= nextFireTime)
            {
                nextFireTime = Time.time + fireRate;
                FireAmmo();
                if (isPlayer)
                {
                    GameManager.Instance.IncreaseHeat(heat);
                }
                GameManager.Instance.CameraShake.Shake(0.5f, 0.1f);
                var sfx = GetComponentInChildren<AudioSource>();
                if (sfx != null)
                {
                    sfx.Play();
                }
                return true;
            }

            return false;
        }

        private void FireAmmo()
        {
            switch (ammoType)
            {
                case AmmoType.Bullet:
                    GameManager.Instance.EntityPool.FireBullet(parent, firePoint.position, firePoint.forward, damage);
                    break;
                case AmmoType.Guass:
                    GameManager.Instance.EntityPool.FireGuass(parent, firePoint.position, firePoint.forward, damage);
                    break;
                case AmmoType.Missile:
                    Debug.Log("Fire missile");
                    GameManager.Instance.EntityPool.FireMissile(parent, firePoint.position, firePoint.forward, damage);
                    break;
                case AmmoType.Laser:
                    GameManager.Instance.EntityPool.FireLaser(parent, firePoint.position, firePoint.forward, damage);
                    break;
                case AmmoType.Claw:
                    if (isPlayer)
                    {
                        ClawAttack();
                    }
                    break;
            }
        }

        private void ClawAttack()
        {

            var colliders = Physics.OverlapSphere(firePoint.position, GameManager.Instance.GameSettings.clawRange);
            foreach (Collider c in colliders)
            {
                if (c.gameObject.CompareTag("Enemy"))
                {
                    var e = c.GetComponentInParent<Enemy>();
                    if (e != null)
                    {
                        e.Damage(this.damage);
                    }
                    else
                    {
                        Debug.LogError("untagged enemy error");
                    }
                }

            }
        }

    }
}