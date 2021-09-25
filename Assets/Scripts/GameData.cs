using UnityEngine;

namespace HackedDesign
{
    [CreateAssetMenu(fileName = "GameData", menuName = "State/GameData")]
    public class GameData : ScriptableObject
    {

        public int wave = 1;
        public int totalWaves = 24;
        //public float walkSpeed = 3.0f;
        //public float rotateSpeed = 180.0f;
        public int bonusWalkSpeed = 0;
        public int maxBonusWalkSpeed = 5;

        public float baseHealth = 100.0f;
        public float maxBaseHealth = 100.0f;
        public int selectedWeapon = 0;

        public int scrap = 0;

        public float armour = 100.0f;
        public float heat = 0.0f;
        public float coolant = 100.0f;

        public float maxHeat = 100.0f;
        public float maxCoolant = 100.0f;
        public float maxArmour = 100.0f;

        public float ambientHeatLoss = 1.0f;
        public float heatDamage = 3.0f;
        public float coolantDump = 25.0f;

        public float interWaveTimer = 15.0f;
        public float waveTime = 0;

        public WeaponType leftArmWeapon;
        public WeaponType rightArmWeapon;
        public WeaponType leftShoulderWeapon;
        public WeaponType rightShoulderWeapon;

        public WeaponType leftArmWeaponTemp;
        public WeaponType rightArmWeaponTemp;
        public WeaponType leftShoulderWeaponTemp;
        public WeaponType rightShoulderWeaponTemp;

        public bool radarWorking = false;
        public bool wturretWorking = false;
        public bool eturretWorking = false;

        public void Reset()
        {
            wave = 1;
            heat = 0;
            armour = 100.0f;
            coolant = 100.0f;
            baseHealth = 100.0f;
            selectedWeapon = 0;
            bonusWalkSpeed = 0;
            scrap = 666;
            leftArmWeapon = WeaponType.LaserCannon;
            rightArmWeapon = WeaponType.Claw;
            leftShoulderWeapon = WeaponType.None;
            rightShoulderWeapon = WeaponType.Missiles;

            wturretWorking = true;
        }

        public void IncreaseArmour(float amount)
        {
            armour = Mathf.Clamp(armour + amount, 0, maxArmour);
            if (armour <= 0)
            {
                GameManager.Instance.SetDead();
            }
        }

        public void IncreaseHeat(float amount)
        {
            heat = Mathf.Max(0, heat + amount);

            // if(heat >= 100)
            // {
            //     // Play overload effect
            // }
        }

        public void UseCoolant()
        {
            if (coolant < (0 + coolantDump))
                return;

            coolant = Mathf.Max(0, coolant - coolantDump);

            IncreaseHeat(-1 * coolantDump);

        }

    }
}