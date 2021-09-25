using UnityEngine;

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
        }
    }
}