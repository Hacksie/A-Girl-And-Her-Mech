using UnityEngine;

namespace HackedDesign
{
    public class PlayingState : IState
    {
        PlayerController player;
        UI.AbstractPresenter hudPanel;
        public PlayingState(PlayerController player, UI.AbstractPresenter hudPanel)
        {
            this.player = player;
            this.hudPanel = hudPanel;
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
            this.player.UpdateBehaviour();
            this.hudPanel.Repaint();

            GameManager.Instance.GameData.IncreaseHeat(-1 * GameManager.Instance.GameData.ambientHeatLoss * Time.deltaTime);
            UpdateOverHeat();
        }

        public void FixedUpdate()
        {
            this.player.FixedUpdateBehaviour();
        }

        public void Start()
        {

        }

        private void UpdateOverHeat()
        {
            if(GameManager.Instance.GameData.heat >= GameManager.Instance.GameData.maxHeat)
            {
                GameManager.Instance.GameData.IncreaseArmour(-1 * GameManager.Instance.GameData.heatDamage * Time.deltaTime);
            }
        }
    }
}