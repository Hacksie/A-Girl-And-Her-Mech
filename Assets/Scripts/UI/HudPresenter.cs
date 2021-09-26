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
        [SerializeField] private UnityEngine.UI.Text scrapText;
        [SerializeField] private List<UnityEngine.UI.Image> weaponPanels;
        [SerializeField] private UnityEngine.UI.Text laAmmoText;
        [SerializeField] private UnityEngine.UI.Text rsAmmoText;
        [SerializeField] private UnityEngine.UI.Text lsAmmoText;
        [SerializeField] private GameObject radarPanel;

        [SerializeField] private Color selected;
        [SerializeField] private Color unselected;

        public override void Repaint()
        {
            var data = GameManager.Instance.GameData; 
            baseHealthbar.value = data.baseHealth;

            healthBar.value = data.armour;
            heatBar.value = data.heat;
            coolantBar.value = data.coolant;

            healthText.text = data.armour.ToString("N0");
            heatText.text = data.heat.ToString("N0");
            coolantText.text = data.coolant.ToString("N0");

            scrapText.text = data.scrap.ToString("N0") + "kg";

            for (int i = 0; i < weaponPanels.Count; i++)
            {
                weaponPanels[i].color = data.selectedWeapon == i ? selected : unselected;
            }

            radarPanel.SetActive(data.radarWorking);
        }
    }
}