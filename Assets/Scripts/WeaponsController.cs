using UnityEngine;

namespace HackedDesign
{
    public class WeaponsController : MonoBehaviour
    {
        [SerializeField] private GameData data;

        [Header("LeftArm")]
        [SerializeField] private GameObject leftArmNone;
        //[SerializeField] private GameObject leftArmBroken;
        [SerializeField] private GameObject leftArmCannon;
        [SerializeField] private GameObject leftArmGattling;
        [SerializeField] private GameObject leftArmPlasma;
        [SerializeField] private GameObject leftArmLaser;
        [SerializeField] private GameObject leftAutocannon;

        [Header("RightArm")]

        [Header("LeftShoulder")]
        [SerializeField] private GameObject leftShoulderNone;
        //[SerializeField] private GameObject leftShoulderBroken;
        [SerializeField] private GameObject leftShoulderCannon;
        [SerializeField] private GameObject leftShoulderGattling;
        [SerializeField] private GameObject leftShoulderPlasma;
        [SerializeField] private GameObject leftShoulderLaser;
        [SerializeField] private GameObject leftShoulderAutocannon;
        [SerializeField] private GameObject leftShoulderMissiles;

        [Header("RightShoulder")]
        [SerializeField] private GameObject rightShoulderNone;
        //[SerializeField] private GameObject rightShoulderBroken;
        [SerializeField] private GameObject rightShoulderCannon;
        [SerializeField] private GameObject rightShoulderGattling;
        [SerializeField] private GameObject rightShoulderPlasma;
        [SerializeField] private GameObject rightShoulderLaser;
        [SerializeField] private GameObject rightShoulderAutocannon;
        [SerializeField] private GameObject rightShoulderMissiles;        

        public void Start()
        {
            UpdateWeapons();
        }

        public void UpdateWeapons()
        {
            leftArmNone.SetActive(data.leftArmWeapon == WeaponType.None);
            leftArmCannon.SetActive(data.leftArmWeapon == WeaponType.Cannon);
            leftArmGattling.SetActive(data.leftArmWeapon == WeaponType.GattlingGun);
            leftArmPlasma.SetActive(data.leftArmWeapon == WeaponType.Plasma);
            leftArmLaser.SetActive(data.leftArmWeapon == WeaponType.LaserCannon);
            leftAutocannon.SetActive(data.leftArmWeapon == WeaponType.AutoCannon);

            leftShoulderNone.SetActive(data.leftShoulderWeapon == WeaponType.None);
            leftShoulderCannon.SetActive(data.leftShoulderWeapon == WeaponType.Cannon);
            leftShoulderGattling.SetActive(data.leftShoulderWeapon == WeaponType.GattlingGun);
            leftShoulderPlasma.SetActive(data.leftShoulderWeapon == WeaponType.Plasma);
            leftShoulderLaser.SetActive(data.leftShoulderWeapon == WeaponType.LaserCannon);
            leftShoulderAutocannon.SetActive(data.leftShoulderWeapon == WeaponType.AutoCannon);            
            leftShoulderMissiles.SetActive(data.leftShoulderWeapon == WeaponType.Missiles);            

            rightShoulderNone.SetActive(data.rightShoulderWeapon == WeaponType.None);
            rightShoulderCannon.SetActive(data.rightShoulderWeapon == WeaponType.Cannon);
            rightShoulderGattling.SetActive(data.rightShoulderWeapon == WeaponType.GattlingGun);
            rightShoulderPlasma.SetActive(data.rightShoulderWeapon == WeaponType.Plasma);
            rightShoulderLaser.SetActive(data.rightShoulderWeapon == WeaponType.LaserCannon);
            rightShoulderAutocannon.SetActive(data.rightShoulderWeapon == WeaponType.AutoCannon);            
            rightShoulderMissiles.SetActive(data.rightShoulderWeapon == WeaponType.Missiles);
        }
    }
}