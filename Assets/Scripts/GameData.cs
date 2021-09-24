using UnityEngine;

namespace HackedDesign
{
    [CreateAssetMenu(fileName="GameData", menuName="State/GameData")]
    public class GameData : ScriptableObject
    {
        public int wave = 1;
        public float walkSpeed = 3.0f;
        public float rotateSpeed = 180.0f;
        public float heat = 0.0f;
        public float baseHealth = 100.0f;

        public WeaponType leftArmWeapon;
        public WeaponType leftShoulderWeapon;
        public WeaponType rightShoulderWeapon;

        public bool radarWorking = false;
        public bool turretWorking = false;

        public void Reset()
        {
            wave = 1;
            walkSpeed = 2.5f;
            rotateSpeed = 180.0f;
            heat = 0;
            baseHealth = 100.0f;
            leftArmWeapon = WeaponType.Cannon;
            leftShoulderWeapon = WeaponType.None;
            rightShoulderWeapon = WeaponType.None;
        }
    }

    public enum WeaponType
    {
        None,
        Cannon,
        GattlingGun,
        Plasma,
        AutoCannon,
        LaserCannon,
        Missiles
    }
}