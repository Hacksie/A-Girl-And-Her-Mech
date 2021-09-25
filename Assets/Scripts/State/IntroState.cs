

namespace HackedDesign
{
    public class IntroState : IState
    {
        private UI.AbstractPresenter panel;

        public IntroState(UI.IntroPresenter introPanel)
        {
            this.panel = introPanel;
        }

        public bool Playing => false;

        public void Begin()
        {
            UnityEngine.Debug.Log("Begin");
            this.panel.Show();
            this.panel.Repaint();
        }

        public void End()
        {
            this.panel.Hide();
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