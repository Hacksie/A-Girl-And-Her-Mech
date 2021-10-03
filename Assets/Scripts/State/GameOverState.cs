using UnityEngine;

namespace HackedDesign
{
    public class GameOverState : IState
    {
        UI.AbstractPresenter gameoverPanel;
        public GameOverState(UI.AbstractPresenter gameoverPanel)
        {
            this.gameoverPanel = gameoverPanel;
        }

        public bool Playing => false;

        public void Begin()
        {
            GameManager.Instance.CameraShake.Shake(0,0);
            GameManager.Instance.Enemies.Reset();
            this.gameoverPanel.Show();
        }

        public void End()
        {
            this.gameoverPanel.Hide();
            
        }

        public void FixedUpdate()
        {
            
        }

        public void Start()
        {
            
        }

        public void Update()
        {
            
        }
    }

}