

using UnityEngine;

namespace HackedDesign
{
    public class MainMenuState : IState
    {
        private UI.AbstractPresenter menuPanel;
        private Camera menuCamera;
        private Camera mainCamera;

        public MainMenuState(UI.AbstractPresenter menuPanel, Camera menuCamera, Camera mainCamera)
        {
            this.menuPanel = menuPanel;
            this.menuCamera = menuCamera;
            this.mainCamera = mainCamera;
        }

        public bool Playing => false;

        public void Begin()
        {
            GameManager.Instance.Reset();
            this.menuCamera.gameObject.SetActive(true);
            this.mainCamera.gameObject.SetActive(false);
            this.menuPanel.Show();
            AudioManager.Instance.PlayMenuMusic();
            
        }

        public void End()
        {
            this.menuCamera.gameObject.SetActive(false);
            this.mainCamera.gameObject.SetActive(true);
            this.menuPanel.Hide();
            AudioManager.Instance.StopMenuMusic();
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