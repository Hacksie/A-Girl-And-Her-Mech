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

        
        public float maxBaseHealth = 100.0f;

        public float maxHeat = 100.0f;
        public float maxCoolant = 100.0f;
        public float maxArmour = 100.0f;

        public float ambientHeatLoss = 2.0f;
        public float heatDamage = 3.0f;
        public float coolantDump = 25.0f;

        public float interWaveTimer = 15.0f;

        public int priceBaseHeal = 100;
        public int priceRepairMech = 22;
        public int priceSpeedInc = 250;
        public int priceRepairRadar = 500;
        public int priceRepairWTurret = 5000;
        public int priceRepairETurret = 5000;

        public int priceCannon = 250;
        public int priceGattling = 1500;
        public int priceGauss = 2500;
        public int priceLaser = 1000;
        public int priceAutoCannon = 2500;
        public int priceMissiles = 4000;

        public int priceBulletAmmo = 10;
        public int priceMissileAmmo = 100;

        public float incomingTimer = 5.0f;
        public float intermissionTimer = 15.0f;

        public float spawnRange = 50.0f;
        public float stopRange = 12.5f;

        public List<Wave> waves;
    }
}