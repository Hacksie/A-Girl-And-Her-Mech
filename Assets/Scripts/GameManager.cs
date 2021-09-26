using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HackedDesign
{
    public class GameManager : MonoBehaviour
    {
        [Header("Referenced Game Objects")]
        [SerializeField] private PlayerController player = null;
        [SerializeField] private WeaponsController weapons = null;
        [SerializeField] private EnemyController enemies = null;
        [SerializeField] private Camera mainCamera;
        [SerializeField] private List<Camera> shopCameras;
        [SerializeField] private Pool pool = null;

        [Header("UI")]
        [SerializeField] private UI.IntroPresenter introPanel = null;
        [SerializeField] private UI.HudPresenter hudPanel = null;
        [SerializeField] private UI.ShopPresenter shopPanel = null;
        [SerializeField] private UI.IncomingPresenter incomingPanel = null;
        [SerializeField] private UI.IntermissionPresenter intermissionPanel = null;
        [SerializeField] private UI.GameOverDeadPresenter gameOverDeadPanel = null;

        [Header("State")]
        [SerializeField] private GameData gameData;

        [Header("Settings")]
        [SerializeField] private GameSettings gameSettings;
        [SerializeField] private List<Wave> waves;


        private IState state = new EmptyState();

        public IState State
        {
            get
            {
                return state;
            }
            private set
            {
                state.End();
                state = value;
                state.Begin();
            }
        }

        public PlayerController Player { get { return player; } private set { player = value; } }
        public WeaponsController Weapons { get { return weapons; } private set { weapons = value; } }
        public GameData GameData { get { return gameData; } private set { gameData = value; } }
        public GameSettings GameSettings { get { return gameSettings; } private set { gameSettings = value; } }
        public Pool EntityPool { get { return pool; } private set { pool = value; } }
        public EnemyController Enemies { get { return enemies; } private set { enemies = value; } }

        public static GameManager Instance { get; private set; }

        GameManager()
        {
            Instance = this;
        }

        void Update() => state.Update();
        void FixedUpdate() => state.FixedUpdate();

        void Start()
        {
            HideAllUI();
            Reset();
            SetIntro();
            mainCamera.gameObject.SetActive(true);
            shopCameras.ForEach((camera) => camera.gameObject.SetActive(false));
            //shopCamera.gameObject.SetActive(false);
        }

        public void SetPlaying() => State = new PlayingState(Player, Enemies, this.hudPanel, this.incomingPanel, this.intermissionPanel);
        public void SetMainMenu() => State = new MainMenuState();
        public void SetIntro() => State = new IntroState(this.introPanel);
        public void SetShop() => State = new ShopState(this.mainCamera, this.shopCameras, this.hudPanel, this.shopPanel);
        public void SetDead() => State = new DeadState(this.gameOverDeadPanel);


        public void Reset()
        {
            gameData.Reset();
        }

        public void IncreaseHeat(float amount)
        {
            GameData.heat = Mathf.Max(0, GameData.heat + amount);

            // if(heat >= 100)
            // {
            //     // Play overload effect
            // }
        }        

        public void UseCoolant()
        {
            if (GameData.coolant < (0 + GameSettings.coolantDump))
                return;

            GameData.coolant = Mathf.Max(0, GameData.coolant - GameSettings.coolantDump);
            IncreaseHeat(-1 * GameSettings.coolantDump);
        }        

        public void IncreaseArmour(float amount)
        {
            GameData.armour = Mathf.Clamp(GameData.armour + amount, 0, GameSettings.maxArmour);
            if (GameData.armour <= 0)
            {
                GameManager.Instance.SetDead();
            }
        }        

        private void HideAllUI()
        {
            this.hudPanel.Hide();
            this.introPanel.Hide();
            this.shopPanel.Hide();
            this.incomingPanel.Hide();
            this.intermissionPanel.Hide();
            this.gameOverDeadPanel.Hide();
        }

    }
}
