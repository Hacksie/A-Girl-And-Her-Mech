using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace HackedDesign
{
    public class Pool : MonoBehaviour
    {
        // FIXME: Actually pool !
        [SerializeField] Transform parent;
        [SerializeField] Bullet bulletPrefab = null;
        [SerializeField] Bullet guassPrefab = null;
        [SerializeField] Bullet missilePrefab = null;
        [SerializeField] Laser laserPrefab = null;

        private List<Bullet> bulletPool = new List<Bullet>();
        private List<Bullet> gaussPool = new List<Bullet>();
        private List<Bullet> missilePool = new List<Bullet>();
        private List<Laser> laserPool = new List<Laser>();

        void Awake()
        {
            if (!parent)
            {
                parent = this.transform;
            }
        }

        public void Reset()
        {
            for (int i = 0; i < parent.transform.childCount; i++)
            {
                Destroy(parent.transform.GetChild(i));
            }
        }

        public void FireBullet(GameObject firer, Vector3 start, Vector3 forward, float damage)
        {
            Bullet bullet = bulletPool.FirstOrDefault(b => !b.gameObject.activeInHierarchy);

            if (bullet == null)
            {
                var go = Instantiate(bulletPrefab, start, Quaternion.identity, parent);
                bullet = go.GetComponent<Bullet>();
                bulletPool.Add(bullet);
            }

            Debug.Log(bullet.name);

            bullet.gameObject.SetActive(true);
            bullet.transform.position = start;
            bullet.transform.forward = forward;
            bullet.Fire(firer, damage);

        }

        public void FireGuass(GameObject firer, Vector3 start, Vector3 forward, float damage)
        {
            Bullet bullet = gaussPool.FirstOrDefault(b => !b.gameObject.activeInHierarchy);

            if (bullet == null)
            {
                var go = Instantiate(guassPrefab, start, Quaternion.identity, parent);
                bullet = go.GetComponent<Bullet>();
                gaussPool.Add(bullet);
            }

            

            bullet.gameObject.SetActive(true);
            bullet.transform.position = start;
            bullet.transform.forward = forward;
            bullet.Fire(firer, damage);
        }

        public void FireMissile(GameObject firer, Vector3 start, Vector3 forward, float damage)
        {
            Bullet bullet = missilePool.FirstOrDefault(b => !b.gameObject.activeInHierarchy);

            if (bullet == null)
            {
                var go = Instantiate(missilePrefab, start, Quaternion.identity, parent);
                bullet = go.GetComponent<Bullet>();
                missilePool.Add(bullet);
            }



            bullet.gameObject.SetActive(true);
            bullet.transform.position = start;
            bullet.transform.forward = forward;
            bullet.Fire(firer, damage);
        }

        public void FireLaser(GameObject firer, Vector3 start, Vector3 forward, float damage)
        {
            Laser bullet = laserPool.FirstOrDefault(l => !l.gameObject.activeInHierarchy);

            if (bullet == null)
            {
                var go = Instantiate(laserPrefab, start, Quaternion.identity, parent);
                bullet = go.GetComponent<Laser>();
                laserPool.Add(bullet);
            }

            bullet.gameObject.SetActive(true);
            bullet.transform.position = start;
            bullet.transform.forward = forward;

            bullet.Fire(firer, damage);


        }


    }
}