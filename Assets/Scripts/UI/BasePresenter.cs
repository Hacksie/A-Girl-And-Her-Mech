using UnityEngine;

namespace HackedDesign.UI
{
    public class BasePresenter : AbstractPresenter
    {
        [SerializeField] private UnityEngine.UI.Slider healthbar;

        public override void Repaint()
        {
            healthbar.value = GameManager.Instance.GameData.baseHealth;
        }
    }
}