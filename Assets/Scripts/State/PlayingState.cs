using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace HackedDesign
{
    public class PlayingState : IState
    {
        PlayerController player;
        EnemyController enemies;
        List<Turret> turrets;
        CameraShake shake;
        UI.AbstractPresenter hudPanel;
        UI.AbstractPresenter incomingPanel;
        UI.AbstractPresenter intermissionPanel;

        public PlayingState(PlayerController player, EnemyController enemies, List<Turret> turrets, CameraShake shake, UI.AbstractPresenter hudPanel, UI.AbstractPresenter incomingPanel, UI.AbstractPresenter intermissionPanel)
        {
            this.player = player;
            this.enemies = enemies;
            this.turrets = turrets;
            this.shake = shake;
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
            this.intermissionPanel.Hide();
            this.incomingPanel.Hide();
            this.player.Freeze();
            GameManager.Instance.CameraShake.Shake(0, 0);
            AudioManager.Instance.StopIncomingMusic();
            AudioManager.Instance.StopAttackMusic();
            AudioManager.Instance.StopIntermissionMusic();
        }

        public void Update()
        {
            UpdateWave();
            UpdateOverHeat();
            UpdateNearDeath();

            this.player.UpdateBehaviour();
            this.enemies.UpdateBehaviour();
            this.turrets.ForEach((turret) => turret.UpdateBehaviour());
            this.shake.UpdateBehaviour();

            this.hudPanel.Repaint();

            GameManager.Instance.IncreaseHeat(-1 * (GameManager.Instance.GameData.ambientHeatLoss + GameManager.Instance.GameData.bonusHeatSink) * Time.deltaTime);

        }

        public void FixedUpdate()
        {
            this.player.FixedUpdateBehaviour();
        }

        public void Start()
        {
            GameManager.Instance.SetPaused();
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
                    AudioManager.Instance.PlayIncomingMusic();
                    AudioManager.Instance.StopIntermissionMusic();


                    break;
                case WaveState.Attacking:
                    AudioManager.Instance.StopIncomingMusic();
                    AudioManager.Instance.PlayAttackMusic();
                    this.intermissionPanel.Hide();
                    this.incomingPanel.Hide();

                    break;
                case WaveState.Intermission:
                    AudioManager.Instance.StopAttackMusic();
                    AudioManager.Instance.PlayIntermissionMusic();
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
                AudioManager.Instance.PlayWarning();
            }
        }

        private void UpdateNearDeath()
        {
            if (GameManager.Instance.GameData.armour <= 10)
            {
                AudioManager.Instance.PlayWarning();
            }
        }


    }
}