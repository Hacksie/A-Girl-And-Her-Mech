using UnityEngine;

namespace HackedDesign
{
    public class DeadState : IState
    {
        UI.AbstractPresenter deadPanel;
        public DeadState(UI.AbstractPresenter deadPanel)
        {
            this.deadPanel = deadPanel;
        }

        public bool Playing => false;

        public void Begin()
        {
            GameManager.Instance.CameraShake.Shake(0,0);
            AudioManager.Instance.StopIncomingMusic();
            AudioManager.Instance.StopAttackMusic();
            AudioManager.Instance.StopIntermissionMusic();           
            AudioManager.Instance.PlayDeadMusic(); 
            GameManager.Instance.Enemies.Reset();
            this.deadPanel.Show();
            this.deadPanel.Repaint();
        }

        public void End()
        {
            this.deadPanel.Hide();
            AudioManager.Instance.StopDeadMusic();
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