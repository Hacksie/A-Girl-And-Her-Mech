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

        private float nextFireTime = 0;

        public void Fire()
        {
            if(Time.time >= nextFireTime)
            {
                nextFireTime = Time.time + fireRate;
                Debug.Log("Fire " + type.ToString());

                FireAmmo();

                GameManager.Instance.GameData.IncreaseHeat(heat);
            }
        }

        private void FireAmmo()
        {
            switch(ammoType)
            {
                case AmmoType.Bullet:
                GameManager.Instance.EntityPool.FireBullet(parent, firePoint.position, firePoint.forward, damage);
                break;
                case AmmoType.Guass:
                GameManager.Instance.EntityPool.FireGuass(parent, firePoint.position, firePoint.forward, damage);
                break;
                case AmmoType.Missile:
                GameManager.Instance.EntityPool.FireMissile(parent, firePoint.position, firePoint.forward, damage);
                break;
                case AmmoType.Laser:
                GameManager.Instance.EntityPool.FireLaser(parent, firePoint.position, firePoint.forward, damage);
                break;
                case AmmoType.Claw:
                break;
            }


        }

    }
}