namespace HackedDesign.UI
{
    public class PausePresenter : AbstractPresenter
    {

        public override void Repaint()
        {

        }

        public void ResumeClickEvent()
        {
            GameManager.Instance.SetPlaying();
        }

        public void QuitClickEvent()
        {
            
            GameManager.Instance.SetMainMenu();
        }
    }
}