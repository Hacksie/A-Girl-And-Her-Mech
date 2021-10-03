using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace HackedDesign
{
    public class WeaponsController : MonoBehaviour
    {
        [SerializeField] private List<Weapon> rightArm;
        [SerializeField] private List<Weapon> leftArm;
        [SerializeField] private List<Weapon> rightShoulder;
        [SerializeField] private List<Weapon> leftShoulder;

        [SerializeField] public WeaponPosition selectedWeapon = 0;
        //[SerializeField] public WeaponPosition currentWeapon;

        [SerializeField] public WeaponType leftArmWeapon;
        [SerializeField] public WeaponType rightArmWeapon;
        [SerializeField] public WeaponType leftShoulderWeapon;
        [SerializeField] public WeaponType rightShoulderWeapon;

        [SerializeField] public WeaponType leftArmWeaponTemp;
        [SerializeField] public WeaponType rightArmWeaponTemp;
        [SerializeField] public WeaponType leftShoulderWeaponTemp;
        [SerializeField] public WeaponType rightShoulderWeaponTemp;        

        public void Start()
        {
            UpdateWeapons();
        }

        public bool FireCurrentWeapon()
        {
            var currentWeapon = GetCurrentWeapon();
            return currentWeapon ? currentWeapon.type != WeaponType.None && currentWeapon.Fire() : false;
        }

        public void FireAllWeapons()
        {
            for (int i = 0; i < 4; i++)
            {
                GetWeapon((WeaponPosition)i)?.Fire();
            }
        }

        public void NextWeapon()
        {
            selectedWeapon++;

            if (selectedWeapon > WeaponPosition.LeftShoulder)
            {
                selectedWeapon = WeaponPosition.RightArm;
            }
        }

        public void PrevWeapon()
        {
            selectedWeapon--;

            if (selectedWeapon < 0)
            {
                selectedWeapon = WeaponPosition.LeftShoulder;
            }
        }

        public Weapon GetCurrentWeapon()
        {
            Weapon weapon;
            switch (selectedWeapon)
            {
                case WeaponPosition.LeftShoulder:
                    weapon = leftShoulder.FirstOrDefault(w => w.type == leftShoulderWeapon);
                    break;
                case WeaponPosition.RightShoulder:
                    weapon = rightShoulder.FirstOrDefault(w => w.type == rightShoulderWeapon);
                    break;
                case WeaponPosition.LeftArm:
                    weapon = leftArm.FirstOrDefault(w => w.type == leftArmWeapon);
                    break;
                case WeaponPosition.RightArm:
                default:
                    weapon = rightArm.FirstOrDefault(w => w.type == rightArmWeapon);
                    break;
            }

            return weapon;
        }

        public Weapon GetWeapon(WeaponPosition position)
        {
            switch (position)
            {
                case WeaponPosition.LeftShoulder:
                    return leftShoulder.FirstOrDefault(w => w.type == leftShoulderWeapon);
                case WeaponPosition.RightShoulder:
                    return rightShoulder.FirstOrDefault(w => w.type == rightShoulderWeapon);
                case WeaponPosition.LeftArm:
                    return leftArm.FirstOrDefault(w => w.type == leftArmWeapon);
                default:
                case WeaponPosition.RightArm:
                    return rightArm.FirstOrDefault(w => w.type == rightArmWeapon);
            }

        }

        public void UpgradeWeapon(WeaponType newWeapon)
        {
            switch (selectedWeapon)
            {
                case WeaponPosition.LeftArm:
                    leftArmWeapon = newWeapon;
                    break;
                case WeaponPosition.RightShoulder:
                    rightShoulderWeapon = newWeapon;
                    break;
                case WeaponPosition.LeftShoulder:
                    leftShoulderWeapon = newWeapon;
                    break;
            }
        }        

        public void ClearTempWeapons()
        {
            leftShoulderWeaponTemp = WeaponType.None;
            rightShoulderWeaponTemp = WeaponType.None;
            leftArmWeaponTemp = WeaponType.None;
            UpdateWeapons();
        }

        public void SetTempWeapon(WeaponType type)
        {
            switch (selectedWeapon)
            {
                case WeaponPosition.LeftShoulder:
                    leftShoulderWeaponTemp = type;
                    break;
                case WeaponPosition.RightShoulder:
                    rightShoulderWeaponTemp = type;
                    break;
                case WeaponPosition.LeftArm:
                    leftArmWeaponTemp = type;
                    break;
            }

            UpdateWeapons();
        }

        public void UpdateWeapons()
        {
            if (leftArm != null && leftArm.Count > 0)
            {
                leftArm.ForEach((weapon) => { weapon.gameObject.SetActive(leftArmWeaponTemp != WeaponType.None ? weapon.type == leftArmWeaponTemp : weapon.type == leftArmWeapon); });
            }
            if (rightArm != null && rightArm.Count > 0)
            {
                rightArm.ForEach((weapon) => { weapon.gameObject.SetActive(weapon.type == rightArmWeapon); });
            }
            if (leftShoulder != null && leftShoulder.Count > 0)
            {
                leftShoulder.ForEach((weapon) => { weapon.gameObject.SetActive(leftShoulderWeaponTemp != WeaponType.None ? weapon.type == leftShoulderWeaponTemp : weapon.type == leftShoulderWeapon); });
            }
            if (rightShoulder != null && rightShoulder.Count > 0)
            {
                rightShoulder.ForEach((weapon) => { weapon.gameObject.SetActive(rightShoulderWeaponTemp != WeaponType.None ? weapon.type == rightShoulderWeaponTemp : weapon.type == rightShoulderWeapon); });
            }
        }
    }
}