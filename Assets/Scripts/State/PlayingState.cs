using UnityEngine;
using System.Linq;

namespace HackedDesign
{
    public class PlayingState : IState
    {
        PlayerController player;
        EnemyController enemies;
        UI.AbstractPresenter hudPanel;
        UI.AbstractPresenter incomingPanel;
        UI.AbstractPresenter intermissionPanel;

        public PlayingState(PlayerController player, EnemyController enemies, UI.AbstractPresenter hudPanel, UI.AbstractPresenter incomingPanel, UI.AbstractPresenter intermissionPanel)
        {
            this.player = player;
            this.enemies = enemies;
            this.hudPanel = hudPanel;
            this.incomingPanel = incomingPanel;
            this.intermissionPanel = intermissionPanel;
        }

        public bool Playing => true;

        public void Begin()
        {
            this.hudPanel.Show();
        }

        public void End()
        {
            this.hudPanel.Hide();
            this.player.Freeze();
        }

        public void Update()
        {
            UpdateWave();
            UpdateOverHeat();
            UpdateBaseDead();

            this.player.UpdateBehaviour();
            enemies.UpdateBehaviour();
            this.hudPanel.Repaint();

            GameManager.Instance.IncreaseHeat(-1 * GameManager.Instance.GameData.ambientHeatLoss * Time.deltaTime);


        }

        public void FixedUpdate()
        {
            this.player.FixedUpdateBehaviour();
        }

        public void Start()
        {

        }

        private void UpdateWave()
        {
            this.enemies.UpdateWave();

            switch (GameManager.Instance.GameData.waveState)
            {
                default:
                case WaveState.Incoming:
                    this.intermissionPanel.Hide();
                    this.incomingPanel.Show();
                    this.incomingPanel.Repaint();


                    break;
                case WaveState.Attacking:
                    this.intermissionPanel.Hide();
                    this.incomingPanel.Hide();

                    break;
                case WaveState.Intermission:
                    this.incomingPanel.Hide();
                    this.intermissionPanel.Show();
                    this.intermissionPanel.Repaint();
                    break;
            }
        }

        private void UpdateOverHeat()
        {
            if (GameManager.Instance.GameData.heat >= GameManager.Instance.GameSettings.maxHeat)
            {
                GameManager.Instance.DamageArmour(GameManager.Instance.GameData.heatDamage * Time.deltaTime);
            }
        }

        private void UpdateBaseDead()
        {

        }
    }
}