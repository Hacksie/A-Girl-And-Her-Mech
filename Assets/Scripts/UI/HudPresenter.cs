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
        [SerializeField] private List<UnityEngine.UI.Image> weaponSprites;

        [SerializeField] private Color selected;
        [SerializeField] private Color unselected;

        [SerializeField] private List<UnityEngine.UI.Image> enemyRadarSprites;

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
                var s = GameManager.Instance.Weapons.GetWeapon(i).sprite;
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
            // if (data.radarWorking)
            // {
            //     UpdateRadar();
            // }
        }

        // private void UpdateRadar()
        // {

        //     var enemies = GameManager.Instance.Enemies.currentEnemies;
        //     for (int i = 0; i < enemyRadarSprites.Count; i++)
        //     {
        //         if (i < enemies.Count)
        //         {
        //             enemyRadarSprites[i].gameObject.SetActive(true);
        //             //enemyRadarSprites[i].transform.localPosition = new Vector2(enemies[i].transform.position.x / 5, enemies[i].transform.position.z / 5);
        //             enemyRadarSprites[i].rectTransform.localPosition = new Vector2(enemies[i].transform.position.x / 5, enemies[i].transform.position.z / 5);
        //         }
        //         else
        //         {
        //             enemyRadarSprites[i].gameObject.SetActive(false);
        //         }
        //     }
        // }
    }
}