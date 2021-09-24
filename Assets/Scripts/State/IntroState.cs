

namespace HackedDesign
{
    public class IntroState : IState
    {
        private UI.AbstractPresenter panel;

        public IntroState(UI.AbstractPresenter introPanel)
        {
            this.panel = introPanel;
        }

        public bool Playing => false;

        public void Begin()
        {
            this.panel.Show();
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