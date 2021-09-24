

namespace HackedDesign
{
    public class PlayingState : IState
    {
        PlayerController player;
        UI.AbstractPresenter basePanel;
        public PlayingState(PlayerController player, UI.AbstractPresenter basePanel)
        {
            this.player = player;
            this.basePanel = basePanel;
        }

        public bool Playing => true;

        public void Begin()
        {
            this.basePanel.Show();
        }

        public void End()
        {
            this.basePanel.Hide();
            
        }

        public void Update()
        {
            this.basePanel.Repaint();
            this.player.UpdateBehaviour();
        }        

        public void FixedUpdate()
        {
            this.player.FixedUpdateBehaviour();
            
        }

        public void Start()
        {
            
        }


    }

}