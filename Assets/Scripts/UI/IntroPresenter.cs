namespace HackedDesign.UI
{
    public class IntroPresenter : AbstractPresenter
    {

        public override void Repaint()
        {
            UnityEngine.Debug.Log("Repaint");
        }

        public void PlayClickEvent()
        {
            GameManager.Instance.SetPlaying();
        }
    }
}