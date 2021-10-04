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
        [SerializeField] private UnityEngine.UI.Text speedText;
        [SerializeField] private UnityEngine.UI.Text heatsinkText;
        [SerializeField] private UnityEngine.UI.Text scrapText;
        [SerializeField] private List<UnityEngine.UI.Image> weaponPanels;
        [SerializeField] private UnityEngine.UI.Text laAmmoText;
        [SerializeField] private UnityEngine.UI.Text rsAmmoText;
        [SerializeField] private UnityEngine.UI.Text lsAmmoText;
        [SerializeField] private GameObject radarPanel;
        [SerializeField] private List<UnityEngine.UI.Image> weaponSprites;
        [SerializeField] private UnityEngine.UI.Image healthBarFill;
        [SerializeField] private UnityEngine.UI.Image heatBarFill;
        [SerializeField] private Color healthOk;
        [SerializeField] private Color healthWarn;
        [SerializeField] private Color healthDanger;

        [SerializeField] private Color selected;
        [SerializeField] private Color unselected;


        public override void Repaint()
        {
            var data = GameManager.Instance.GameData;
            var settings = GameManager.Instance.GameSettings;
            baseHealthbar.value = data.baseHealth;

            healthBar.value = data.armour;
            heatBar.value = data.heat;
            coolantBar.value = data.coolant;

            heatText.color = data.heat > 100 ? Color.red : Color.white;

            if(data.armour <= settings.healthDangerAmount)
            {
                healthBarFill.color = healthDanger;
            }
            else if(data.armour <= settings.healthWarnAmount)
            {
                healthBarFill.color = healthWarn;
            }
            else
            {
                healthBarFill.color = healthOk;
            }

            if(data.heat >= settings.heatDangerAmount)
            {
                heatBarFill.color = healthDanger;
            }
            else if(data.heat >= settings.heatWarnAmount)
            {
                heatBarFill.color = healthWarn;
            }
            else
            {
                heatBarFill.color = healthOk;
            }

            healthText.text = data.armour.ToString("N0");
            heatText.text = data.heat.ToString("N0");
            coolantText.text = data.coolant.ToString("N0");
            speedText.text = data.bonusWalkSpeed.ToString("N0");
            heatsinkText.text = data.bonusHeatSink.ToString("N0");

            scrapText.text = data.scrap.ToString("N0") + "kg";

            for (int i = 0; i < weaponPanels.Count; i++)
            {
                weaponPanels[i].color = GameManager.Instance.Player.Weapons.selectedWeapon == (WeaponPosition)i ? selected : unselected;
                var s = GameManager.Instance.Player.Weapons.GetWeapon((WeaponPosition)i).sprite;
                if (s != null)
                {
                    weaponSprites[i].gameObject.SetActive(true);
                    weaponSprites[i].sprite = s;
                }
                else
                {
                    weaponSprites[i].gameObject.SetActive(false);
                }
            }

            radarPanel.SetActive(data.radarWorking);
         }
    }
}