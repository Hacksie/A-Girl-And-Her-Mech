namespace HackedDesign.UI
{
    public class IntroPresenter : AbstractPresenter
    {

        public override void Repaint()
        {

        }

        public void PlayClickEvent()
        {
            GameManager.Instance.SetPlaying();
        }
    }
}