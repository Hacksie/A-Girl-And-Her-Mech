using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace HackedDesign
{
    public class Pool : MonoBehaviour
    {

        [SerializeField] Transform parent;
        [SerializeField] Bullet bulletPrefab = null;
        [SerializeField] Bullet guassPrefab = null;
        [SerializeField] Bullet missilePrefab = null;
        [SerializeField] Laser laserPrefab = null;

        [SerializeField] ParticleSystem explosionPrefab = null;
        [SerializeField] ParticleSystem miniExplosionPrefab = null;


        private List<Bullet> bulletPool = new List<Bullet>();
        private List<Bullet> gaussPool = new List<Bullet>();
        private List<Bullet> missilePool = new List<Bullet>();
        private List<Laser> laserPool = new List<Laser>();
        private List<ParticleSystem> explosionPool = new List<ParticleSystem>();
        private List<ParticleSystem> miniExplosionPool = new List<ParticleSystem>();

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
            bulletPool.Clear();
            gaussPool.Clear();
            missilePool.Clear();
            laserPool.Clear();
            explosionPool.Clear();
            miniExplosionPool.Clear();
        }

        public void SpawnExplosion(Vector3 position)
        {
            ParticleSystem explosion = explosionPool.FirstOrDefault(e => !e.isPlaying);

            if (explosion == null)
            {
                var go = Instantiate(explosionPrefab.gameObject, position, Quaternion.identity, parent);
                explosion = go.GetComponent<ParticleSystem>();
                explosionPool.Add(explosion);
            }
            var sfx = explosion.GetComponentInChildren<AudioSource>();
            if (sfx != null)
            {
                sfx.Play();
            }
            explosion.transform.position = position;
            explosion.Play();
        }

        public void SpawnMiniExplosion(Vector3 position)
        {
            ParticleSystem explosion = miniExplosionPool.FirstOrDefault(e => !e.isPlaying);

            if (explosion == null)
            {
                var go = Instantiate(miniExplosionPrefab.gameObject, position, Quaternion.identity, parent);
                explosion = go.GetComponent<ParticleSystem>();
                miniExplosionPool.Add(explosion);
            }

            var sfx = explosion.GetComponentInChildren<AudioSource>();
            if (sfx != null)
            {
                sfx.Play();
            }
            explosion.transform.position = position;
            explosion.Play();


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