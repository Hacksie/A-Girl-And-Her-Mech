using UnityEngine;

namespace HackedDesign
{
    [CreateAssetMenu(fileName = "GameData", menuName = "State/GameData")]
    public class GameData : ScriptableObject
    {

        public int wave = 1;
        public float baseHealth = 1000.0f;

        public int bonusWalkSpeed = 0;
        public int bonusHeatSink = 0;

        public int scrap = 0;

        public float armour = 100.0f;
        public float heat = 0.0f;
        public float coolant = 100.0f;

        public float ambientHeatLoss = 1.0f;
        public float heatDamage = 3.0f;
        public float coolantDump = 25.0f;


        //public float interWaveTimer = 15.0f;
        public float incomingTimer = 5;
        public float intermissionTimer = 15;

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
            bonusWalkSpeed = 0;
            bonusHeatSink = 0;
            scrap = 0;
            incomingTimer = 5;
            intermissionTimer = 5;
            waveState = WaveState.Intermission;
            menuState = UI.MenuState.Play;
            radarWorking = false;
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