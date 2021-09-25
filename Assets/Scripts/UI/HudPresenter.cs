using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace HackedDesign.UI
{
    public class HudPresenter : AbstractPresenter
    {
        [SerializeField] private UnityEngine.UI.Slider baseHealthbar;
        [SerializeField] private UnityEngine.UI.Slider healthBar;
        [SerializeField] private UnityEngine.UI.Slider heatBar;
        [SerializeField] private UnityEngine.UI.Slider coolantBar;
        [SerializeField] private UnityEngine.UI.Text healthText;
        [SerializeField] private UnityEngine.UI.Text heatText;
        [SerializeField] private UnityEngine.UI.Text coolantText;
        [SerializeField] private List<UnityEngine.UI.Image> weaponPanels;
        [SerializeField] private GameObject radarPanel;

        [SerializeField] private Color selected;
        [SerializeField] private Color unselected;

        public override void Repaint()
        {
            baseHealthbar.value = GameManager.Instance.GameData.baseHealth;

            healthBar.value = GameManager.Instance.GameData.armour;
            heatBar.value = GameManager.Instance.GameData.heat;
            coolantBar.value = GameManager.Instance.GameData.coolant;

            healthText.text = GameManager.Instance.GameData.armour.ToString("N0");
            heatText.text = GameManager.Instance.GameData.heat.ToString("N0");
            coolantText.text = GameManager.Instance.GameData.coolant.ToString("N0");

            for (int i = 0; i < weaponPanels.Count; i++)
            {
                weaponPanels[i].color = GameManager.Instance.GameData.selectedWeapon == i ? selected : unselected;
            }

            radarPanel.SetActive(GameManager.Instance.GameData.radarWorking);
        }
    }
}