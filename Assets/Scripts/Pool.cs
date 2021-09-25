using UnityEngine;

namespace HackedDesign
{
    public class Pool : MonoBehaviour
    {
        [SerializeField] Transform poolParent; 
        [SerializeField] Bullet bulletPrefab = null;
        [SerializeField] Bullet guassPrefab = null;
        [SerializeField] Bullet missilePrefab = null;
        [SerializeField] Laser laserPrefab = null;

        public void FireBullet(GameObject firer, Vector3 start, Vector3 forward, float damage)
        {
            var go = Instantiate(bulletPrefab, start, Quaternion.identity, poolParent);
            go.transform.forward = forward;
            Bullet bullet = go.GetComponent<Bullet>();
            bullet.Fire(firer);
        }

        public void FireGuass(GameObject firer, Vector3 start, Vector3 forward, float damage)
        {
            var go = Instantiate(guassPrefab, start, Quaternion.identity, poolParent);
            go.transform.forward = forward;
            Bullet bullet = go.GetComponent<Bullet>();
            bullet.Fire(firer);
        }

        public void FireMissile(GameObject firer, Vector3 start, Vector3 forward, float damage)
        {
            var go = Instantiate(missilePrefab, start, Quaternion.identity, poolParent);
            go.transform.forward = forward;
            Bullet bullet = go.GetComponent<Bullet>();
            bullet.Fire(firer);
        }

        public void FireLaser(GameObject firer, Vector3 start, Vector3 forward, float damage)
        {
            var go = Instantiate(laserPrefab, start, Quaternion.identity, poolParent);
            go.transform.forward = forward;
            Laser bullet = go.GetComponent<Laser>();
            bullet.Fire(firer);            
        }
    }
}