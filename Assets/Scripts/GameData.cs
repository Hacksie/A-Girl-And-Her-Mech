using UnityEngine;

namespace HackedDesign
{
    [CreateAssetMenu(fileName = "GameData", menuName = "State/GameData")]
    public class GameData : ScriptableObject
    {

        public int wave = 1;
        //public int totalWaves = 24;
        public int bonusWalkSpeed = 0;
        public int bonusHeatSink = 0;
        

        public float baseHealth = 1000.0f;
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
        public UI.MenuState menuState;

        public void Reset()
        {
            wave = 0;
            heat = 0;
            armour = 100.0f;
            coolant = 100.0f;
            baseHealth = 1000.0f;
            selectedWeapon = 1;
            bonusWalkSpeed = 0;
            scrap = 0;
            incomingTimer = 5;
            intermissionTimer = 5;
            waveState = WaveState.Intermission;
            leftArmWeapon = WeaponType.Cannon;
            rightArmWeapon = WeaponType.Claw;
            leftShoulderWeapon = WeaponType.None;
            rightShoulderWeapon = WeaponType.None;
            menuState = UI.MenuState.Play;
            radarWorking = true;
            wturretWorking = false;
            eturretWorking = false;
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