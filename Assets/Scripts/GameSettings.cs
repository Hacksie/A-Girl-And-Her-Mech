using System.Collections.Generic;
using UnityEngine;


namespace HackedDesign
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "State/GameSettings")]
    public class GameSettings : ScriptableObject
    {
        public int totalWaves = 24;
        public float walkSpeed = 2.5f;
        public float rotateSpeed = 180.0f;
        public float orbitSpeed = 180.0f;
        public int maxBonusWalkSpeed = 5;
        public int maxBonusHeatSink = 5;

        public float maxBaseHealth = 1000.0f;

        public float maxHeat = 100.0f;
        public float maxCoolant = 100.0f;
        public float maxArmour = 100.0f;

        public float ambientHeatLoss = 2.0f;
        public float heatDamage = 3.0f;
        public float coolantDump = 25.0f;

        //public float interWaveTimer = 15.0f;

        public int repairBaseHealth = 100;
        public int repairMechArmour = 10;

        public int priceBaseHeal = 100;
        public int priceRepairMech = 22;
        public int priceSpeedInc = 250;
        public int priceHeatSink = 333;
        public int priceRepairRadar = 750;
        public int priceRepairWTurret = 5000;
        public int priceRepairETurret = 5000;

        public int priceCannon = 250;
        public int priceGattling = 1500;
        public int priceGauss = 2500;
        public int priceLaser = 1000;
        public int priceAutoCannon = 2500;
        public int priceMissiles = 4000;

        public float incomingTimer = 5.0f;
        public float intermissionTimer = 15.0f;

        public float spawnRange = 50.0f;
        public float stopRange = 12.5f;
        public float turretRange = 25.0f;

        public int baseExplosionCount = 10;
        public float baseExplosionRadius = 6.0f;
        public float behaviourShiftTime = 15.0f;

        public float shootIntensity = 1.0f;
        public float hitIntensity = 1.0f;

        public float clawRange = 0.7f;
        public float enemySwitchWeapon = 0.33f;

        public Vector3 startPosition = new Vector3(0,0,0);

        public Dictionary<EnemyTypes, WeaponType[]> armWeapons = new Dictionary<EnemyTypes, WeaponType[]>()
            {
                { EnemyTypes.LightMech, new WeaponType[] { WeaponType.Cannon, WeaponType.GattlingGun } },
                { EnemyTypes.MediumMech, new WeaponType[] { WeaponType.Cannon, WeaponType.Gauss, WeaponType.GattlingGun, WeaponType.LaserCannon } },
                { EnemyTypes.HeavyMech, new WeaponType[] { WeaponType.Gauss, WeaponType.LaserCannon, WeaponType.AutoCannon } },
            };

        public Dictionary<EnemyTypes, WeaponType[]> shoulderWeapons = new Dictionary<EnemyTypes, WeaponType[]>()
            {
                { EnemyTypes.LightMech, new WeaponType[] { WeaponType.None, WeaponType.Cannon} },
                { EnemyTypes.MediumMech, new WeaponType[] { WeaponType.None, WeaponType.Gauss, WeaponType.Missiles } },
                { EnemyTypes.HeavyMech, new WeaponType[] { WeaponType.None, WeaponType.LaserCannon, WeaponType.AutoCannon, WeaponType.Missiles } },
            };            
    }
}