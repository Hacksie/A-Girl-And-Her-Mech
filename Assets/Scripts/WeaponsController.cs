using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace HackedDesign
{
    public class WeaponsController : MonoBehaviour
    {
        [SerializeField] private GameData data;
        [SerializeField] private List<Weapon> rightArm;
        [SerializeField] private List<Weapon> leftArm;
        [SerializeField] private List<Weapon> rightShoulder;
        [SerializeField] private List<Weapon> leftShoulder;

        public void Start()
        {
            UpdateWeapons();
        }

        public void FireCurrentWeapon()
        {
            GetCurrentWeapon().Fire();
        }

        public Weapon GetCurrentWeapon()
        {
            Weapon weapon;
            switch (data.selectedWeapon)
            {
                case 3:
                    weapon = leftShoulder.FirstOrDefault(w => w.type == data.leftShoulderWeapon);
                    break;
                case 2:
                    weapon = rightShoulder.FirstOrDefault(w => w.type == data.rightShoulderWeapon);
                    break;
                case 1:
                    weapon = leftArm.FirstOrDefault(w => w.type == data.leftArmWeapon);
                    break;
                case 0:
                default:
                    weapon = rightArm.FirstOrDefault(w => w.type == data.rightArmWeapon);
                    break;
            }

            return weapon;
        }

        public void ClearTempWeapons()
        {
            data.leftShoulderWeaponTemp = WeaponType.None;
            data.rightShoulderWeaponTemp = WeaponType.None;
            data.leftArmWeaponTemp = WeaponType.None;
            UpdateWeapons();
        }

        public void SetTempWeapon(WeaponType type)
        {
            switch (data.selectedWeapon)
            {
                case 3:
                    data.leftShoulderWeaponTemp = type;
                    break;
                case 2:
                    data.rightShoulderWeaponTemp = type;
                    break;
                case 1:
                    data.leftArmWeaponTemp = type;
                    break;
            }

            UpdateWeapons();
        }

        public void UpdateWeapons()
        {
            leftArm.ForEach((weapon) => { weapon.gameObject.SetActive(data.leftArmWeaponTemp != WeaponType.None ? weapon.type == data.leftArmWeaponTemp : weapon.type == data.leftArmWeapon); });
            rightArm.ForEach((weapon) => { weapon.gameObject.SetActive(weapon.type == data.rightArmWeapon); });
            leftShoulder.ForEach((weapon) => { weapon.gameObject.SetActive(data.leftShoulderWeaponTemp != WeaponType.None ? weapon.type == data.leftShoulderWeaponTemp : weapon.type == data.leftShoulderWeapon); });
            rightShoulder.ForEach((weapon) => { weapon.gameObject.SetActive(data.rightShoulderWeaponTemp != WeaponType.None ? weapon.type == data.rightShoulderWeaponTemp : weapon.type == data.rightShoulderWeapon); });
            /*
            leftArmNone.SetActive(data.leftArmWeapon == WeaponType.None);
            leftArmCannon.SetActive(data.leftArmWeapon == WeaponType.Cannon);
            leftArmGattling.SetActive(data.leftArmWeapon == WeaponType.GattlingGun);
            leftArmPlasma.SetActive(data.leftArmWeapon == WeaponType.Gauss);
            leftArmLaser.SetActive(data.leftArmWeapon == WeaponType.LaserCannon);
            leftAutocannon.SetActive(data.leftArmWeapon == WeaponType.AutoCannon);

            leftShoulderNone.SetActive(data.leftShoulderWeapon == WeaponType.None);
            leftShoulderCannon.SetActive(data.leftShoulderWeapon == WeaponType.Cannon);
            leftShoulderGattling.SetActive(data.leftShoulderWeapon == WeaponType.GattlingGun);
            leftShoulderPlasma.SetActive(data.leftShoulderWeapon == WeaponType.Gauss);
            leftShoulderLaser.SetActive(data.leftShoulderWeapon == WeaponType.LaserCannon);
            leftShoulderAutocannon.SetActive(data.leftShoulderWeapon == WeaponType.AutoCannon);            
            leftShoulderMissiles.SetActive(data.leftShoulderWeapon == WeaponType.Missiles);            

            rightShoulderNone.SetActive(data.rightShoulderWeapon == WeaponType.None);
            rightShoulderCannon.SetActive(data.rightShoulderWeapon == WeaponType.Cannon);
            rightShoulderGattling.SetActive(data.rightShoulderWeapon == WeaponType.GattlingGun);
            rightShoulderPlasma.SetActive(data.rightShoulderWeapon == WeaponType.Gauss);
            rightShoulderLaser.SetActive(data.rightShoulderWeapon == WeaponType.LaserCannon);
            rightShoulderAutocannon.SetActive(data.rightShoulderWeapon == WeaponType.AutoCannon);            
            rightShoulderMissiles.SetActive(data.rightShoulderWeapon == WeaponType.Missiles);
            */
        }
    }
}