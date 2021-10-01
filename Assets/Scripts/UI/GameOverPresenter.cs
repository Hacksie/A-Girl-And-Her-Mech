namespace HackedDesign.UI
{
    public class GameOverPresenter : AbstractPresenter
    {

        public override void Repaint()
        {

        }

        public void QuitClickEvent()
        {
            GameManager.Instance.SetMainMenu();
        }
    }
}