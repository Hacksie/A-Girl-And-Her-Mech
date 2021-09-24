using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HackedDesign
{
    public class GameManager : MonoBehaviour
    {
        [Header("Referenced Game Objects")]
        [SerializeField] private PlayerController player = null;
        [Header("UI")]
        [SerializeField] private UI.IntroPresenter introPanel = null;
        [Header("State")]
        [SerializeField] private GameData gameData;
        

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

        public static GameManager Instance { get; private set; }

        GameManager()
        {
            Instance = this;
        }

        void Update() => state.Update();
        void FixedUpdate() => state.FixedUpdate();

        void Start()
        {
            Reset();
            SetIntro();
        }

        public void SetPlaying() => State = new PlayingState();
        public void SetMainMenu() => State = new MainMenuState();
        public void SetIntro() => State = new IntroState(this.introPanel);


        public void Reset()
        {
            gameData.Reset();
            // Level = 0;
            // SpawnCountdown = 0;
            // Score = 0;
            // Pool.Reset();
            // Player.Reset();
        }

    }
}
