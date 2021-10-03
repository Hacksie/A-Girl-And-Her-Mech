using UnityEngine;

namespace HackedDesign
{
    public class PauseState : IState
    {
        UI.AbstractPresenter pausePanel;
        public PauseState(UI.AbstractPresenter pausePanel)
        {
            this.pausePanel = pausePanel;
        }

        public bool Playing => false;

        public void Begin()
        {
            GameManager.Instance.CameraShake.Shake(0,0);
            this.pausePanel.Show();
        }

        public void End()
        {
            this.pausePanel.Hide();
        }

        public void FixedUpdate()
        {
        }

        public void Start()
        {
            GameManager.Instance.SetPlaying();   
        }

        public void Update()
        {
        }
    }
}