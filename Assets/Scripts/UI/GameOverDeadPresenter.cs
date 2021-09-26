namespace HackedDesign.UI
{
    public class GameOverDeadPresenter : AbstractPresenter
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