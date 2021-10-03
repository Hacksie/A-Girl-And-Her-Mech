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
            GameManager.Instance.Enemies.Reset();
            this.deadPanel.Show();
        }

        public void End()
        {
            this.deadPanel.Hide();
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