using UnityEngine;

namespace HackedDesign
{
    [CreateAssetMenu(fileName = "GameData", menuName = "State/GameData")]
    public class GameData : ScriptableObject
    {

        public int wave = 1;
        public int totalWaves = 24;
        public int bonusWalkSpeed = 0;
        public int maxBonusWalkSpeed = 5;

        public float baseHealth = 100.0f;
        public int selectedWeapon = 0;

        public int scrap = 0;

        public float armour = 100.0f;
        public float heat = 0.0f;
        public float coolant = 100.0f;

        // public float maxHeat = 100.0f;
        // public float maxCoolant = 100.0f;
        // public float maxArmour = 100.0f;

        public float ambientHeatLoss = 1.0f;
        public float heatDamage = 3.0f;
        public float coolantDump = 25.0f;


        public float interWaveTimer = 15.0f;
        public float incomingTimer = 5;
        public float intermissionTimer = 15;

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

        public WaveState waveState;

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
            incomingTimer = 5;
            intermissionTimer = 15;
            waveState = WaveState.Incoming;
            leftArmWeapon = WeaponType.Cannon;
            rightArmWeapon = WeaponType.Claw;
            leftShoulderWeapon = WeaponType.LaserCannon;
            rightShoulderWeapon = WeaponType.Missiles;

            //wturretWorking = false;
        }


    }

    public enum WaveState
    {
        Incoming,
        Attacking,
        Intermission
    }    

    public enum WaveDirection
    {
        North,
        NorthEast,
        East,
        SouthEast,
        South,
        SouthWest,
        West,
        NorthWest
    }
}