using UnityEngine;

namespace HackedDesign
{
    public class SuccessState : IState
    {
        UI.AbstractPresenter gameoverPanel;
        public SuccessState(UI.AbstractPresenter gameoverPanel)
        {
            this.gameoverPanel = gameoverPanel;
        }

        public bool Playing => false;

        public void Begin()
        {
            GameManager.Instance.CameraShake.Shake(0,0);
            GameManager.Instance.Enemies.Reset();
            this.gameoverPanel.Show();
            this.gameoverPanel.Repaint();
            AudioManager.Instance.StopIncomingMusic();
            AudioManager.Instance.StopAttackMusic();
            AudioManager.Instance.StopIntermissionMusic();   
            AudioManager.Instance.PlaySuccessMusic();

        }

        public void End()
        {
            this.gameoverPanel.Hide();
            AudioManager.Instance.StopSuccessMusic();
            
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