

using UnityEngine;

namespace HackedDesign
{
    public class MainMenuState : IState
    {
        private UI.AbstractPresenter menuPanel;
        private Camera menuCamera;
        private Camera mainCamera;
        private GameObject menuChar;

        public MainMenuState(UI.AbstractPresenter menuPanel, Camera menuCamera, Camera mainCamera, GameObject menuChar)
        {
            this.menuPanel = menuPanel;
            this.menuCamera = menuCamera;
            this.mainCamera = mainCamera;
            this.menuChar = menuChar;
        }

        public bool Playing => false;

        public void Begin()
        {
            this.menuChar.SetActive(true);
            this.menuCamera.gameObject.SetActive(true);
            this.mainCamera.gameObject.SetActive(false);
            this.menuPanel.Show();
            
        }

        public void End()
        {
            this.menuChar.SetActive(false);
            this.menuCamera.gameObject.SetActive(false);
            this.mainCamera.gameObject.SetActive(true);
            this.menuPanel.Hide();
        }

        public void FixedUpdate()
        {
            
        }

        public void Start()
        {
            
        }

        public void Update()
        {
            this.menuPanel.Repaint();
            
        }
    }

}