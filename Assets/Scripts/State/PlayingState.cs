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
            this.enemies.FreezeAll();
            GameManager.Instance.CameraShake.Shake(0, 0);
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
            switch (GameManager.Instance.GameData.waveState)
            {
                default:
                case WaveState.Incoming:
                    UpdateIncoming();
                    break;

                case WaveState.Attacking:
                    UpdateAttacking();
                    break;

                case WaveState.Intermission:
                    UpdateIntermission();
                    break;
            }
        }


        private void UpdateIncoming()
        {

            var data = GameManager.Instance.GameData;
            var settings = GameManager.Instance.GameSettings;

            this.intermissionPanel.Hide();
            this.incomingPanel.Show();
            this.incomingPanel.Repaint();
            AudioManager.Instance.PlayIncomingMusic();
            AudioManager.Instance.StopIntermissionMusic();


            data.incomingTimer -= Time.deltaTime;

            if (data.incomingTimer <= 0)
            {
                data.incomingTimer = settings.incomingTimer;
                data.waveState = WaveState.Attacking;
                this.enemies.SpawnWave();
            }
        }

        private void UpdateAttacking()
        {

            AudioManager.Instance.StopIncomingMusic();
            AudioManager.Instance.PlayAttackMusic();
            this.intermissionPanel.Hide();
            this.incomingPanel.Hide();

            // Check all enemies are dead
            if (this.enemies.AllEnemiesAreDead())
            {
                GameManager.Instance.GameData.waveState = WaveState.Intermission;
            }
        }

        private void UpdateIntermission()
        {
            var data = GameManager.Instance.GameData;

            AudioManager.Instance.StopAttackMusic();
            AudioManager.Instance.PlayIntermissionMusic();
            this.incomingPanel.Hide();
            this.intermissionPanel.Show();
            this.intermissionPanel.Repaint();

            data.intermissionTimer -= Time.deltaTime;

            if (data.intermissionTimer <= 0)
            {
                data.intermissionTimer = GameManager.Instance.GameSettings.intermissionTimer;
                data.waveState = WaveState.Incoming;
                GameManager.Instance.IncreaseWave();
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