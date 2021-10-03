using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace HackedDesign
{
    public class Turret : MonoBehaviour
    {
        [SerializeField] private Transform turret;
        [SerializeField] private float brokenAngle;
        [SerializeField] private float fixedAngle;
        [SerializeField] private bool west;

        private WeaponsController weapons;

        void Awake()
        {
            weapons = GetComponentInChildren<WeaponsController>();
        }

        public void UpdateBehaviour()
        {
            turret.gameObject.SetActive(((west && GameManager.Instance.GameData.wturretWorking) || (!west && GameManager.Instance.GameData.eturretWorking)));

            var rangeSqr = (GameManager.Instance.GameSettings.turretRange * GameManager.Instance.GameSettings.turretRange);

            Enemy target = null;

            foreach (Enemy e in GameManager.Instance.Enemies.currentEnemies)
            {
                if (e.gameObject.activeInHierarchy)
                {
                    if (((e.transform.position - turret.transform.position).sqrMagnitude < rangeSqr) && (target == null || ((e.transform.position - turret.transform.position).sqrMagnitude < (target.transform.position - turret.transform.position).sqrMagnitude)))
                    {
                        target = e;
                    }
                }
            }

            // Consider adding some leading
            if (((west && GameManager.Instance.GameData.wturretWorking) || (!west && GameManager.Instance.GameData.eturretWorking)) && target != null)
            {
                var lookRotation = Quaternion.LookRotation(target.transform.position - turret.transform.position, Vector3.up);
                turret.transform.rotation = Quaternion.Euler(transform.eulerAngles.x, lookRotation.eulerAngles.y , transform.eulerAngles.z);

                weapons?.FireCurrentWeapon();
            }
        }
    }
}