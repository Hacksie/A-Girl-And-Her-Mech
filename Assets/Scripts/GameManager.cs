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
        [SerializeField] private Camera mainCamera;
        [SerializeField] private List<Camera> shopCameras;
        [SerializeField] private Pool pool = null;
        [Header("UI")]
        [SerializeField] private UI.IntroPresenter introPanel = null;
        [SerializeField] private UI.HudPresenter hudPanel = null;
        [SerializeField] private UI.ShopPresenter shopPanel = null;
        [Header("State")]
        [SerializeField] private GameData gameData;
        [Header("Settings")]
        [SerializeField] private GameSettings gameSettings;


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

        public void SetPlaying() => State = new PlayingState(Player, this.hudPanel);
        public void SetMainMenu() => State = new MainMenuState();
        public void SetIntro() => State = new IntroState(this.introPanel);
        public void SetShop() => State = new ShopState(this.mainCamera, this.shopCameras, this.hudPanel, this.shopPanel);
        public void SetDead() => State = new DeadState();


        public void Reset()
        {
            gameData.Reset();
            // Level = 0;
            // SpawnCountdown = 0;
            // Score = 0;
            // Pool.Reset();
            // Player.Reset();
        }

        private void HideAllUI()
        {
            this.hudPanel.Hide();
            this.introPanel.Hide();
            this.shopPanel.Hide();
        }

    }
}
