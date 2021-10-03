using UnityEngine;

namespace HackedDesign
{
    public class Radar : MonoBehaviour
    {
        [SerializeField] private float brokenAngle;
        [SerializeField] private float fixedAngle;

        void Update() =>
            transform.rotation = Quaternion.Euler(GameManager.Instance.GameData.radarWorking ? fixedAngle : brokenAngle, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
        
    }
}