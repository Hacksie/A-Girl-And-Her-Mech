using System.Collections.Generic;
using UnityEngine;

namespace HackedDesign
{
    public class ShopState : IState
    {
        private UI.AbstractPresenter hudPanel;
        private UI.AbstractPresenter shopPanel;
        private Camera mainCamera;
        private List<Camera> shopCameras;

        public ShopState(Camera mainCamera, List<Camera> shopCameras, UI.AbstractPresenter hudPanel, UI.AbstractPresenter shopPanel)
        {
            this.hudPanel = hudPanel;
            this.shopPanel = shopPanel;
            this.mainCamera = mainCamera;
            this.shopCameras = shopCameras;
        }

        public bool Playing => false;

        public void Begin()
        {
            Time.timeScale = 0;
            this.hudPanel.Show();
            this.shopPanel.Show();
            //shopCamera.gameObject.SetActive(true);
            mainCamera.gameObject.SetActive(false);
            GameManager.Instance.GameData.heat = 0;
            GameManager.Instance.GameData.coolant = GameManager.Instance.GameSettings.maxCoolant;
            
        }

        public void End()
        {
            Time.timeScale = 1;
            this.shopPanel.Hide();
            this.hudPanel.Hide();
            mainCamera.gameObject.SetActive(true);
            shopCameras.ForEach((camera) => camera.gameObject.SetActive(false));
            GameManager.Instance.Player.Weapons.ClearTempWeapons();
        }

        public void FixedUpdate()
        {
        }

        public void Start()
        {
        }

        public void Update()
        {
            UpdateCameras();
            this.shopPanel.Repaint();
            this.hudPanel.Repaint();
        }

        private void UpdateCameras()
        {
            for(int i=0;i<shopCameras.Count;i++)
            {
                shopCameras[i].gameObject.SetActive((WeaponPosition)i == GameManager.Instance.Player.Weapons.selectedWeapon);
            }
        }
    }
}