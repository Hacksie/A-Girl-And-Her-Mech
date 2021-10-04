using UnityEngine;

namespace HackedDesign.UI
{
    public class GameOverPresenter : AbstractPresenter
    {
        [SerializeField] private UnityEngine.UI.Text wavesText;

        public override void Repaint()
        {
            var survived = Mathf.Max(GameManager.Instance.GameData.wave - 1, 0);
            wavesText.text = survived + (survived != 1 ? " waves" : " wave");
        }

        public void QuitClickEvent()
        {

            GameManager.Instance.SetMainMenu();
        }
    }
}