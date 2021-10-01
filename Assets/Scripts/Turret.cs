using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace HackedDesign
{
    public class Turret : MonoBehaviour
    {
        [SerializeField] private float brokenAngle;
        [SerializeField] private float fixedAngle;
        [SerializeField] private bool west;

        void Update()
        {
            transform.rotation = Quaternion.Euler(((west && GameManager.Instance.GameData.wturretWorking) || (!west && GameManager.Instance.GameData.eturretWorking)) ? fixedAngle : brokenAngle, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);

            var rangeSqr = (GameManager.Instance.GameSettings.turretRange * GameManager.Instance.GameSettings.turretRange);

            /*
            var enemy = GameManager.Instance.Enemies.currentEnemies
                .Where(e => (e.transform.position - this.transform.position).sqrMagnitude < rangeSqr)
                .Aggregate((min, item) => (min.transform.position - this.transform.position).sqrMagnitude < (item.transform.position - this.transform.position).sqrMagnitude ? min: item);

            if(enemy != null)
            {

            var lookRotation = Quaternion.LookRotation(enemy.transform.position - this.transform.position, Vector3.up);



            transform.rotation = Quaternion.Euler(transform.eulerAngles.x, lookRotation.eulerAngles.y , transform.eulerAngles.z);
            }*/
        }
    }
}