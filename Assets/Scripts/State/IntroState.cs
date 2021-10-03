

using UnityEngine;

namespace HackedDesign
{
    public class IntroState : IState
    {
        private UI.AbstractPresenter panel;
        private Camera menuCamera;
        private Camera mainCamera;

        public IntroState(UI.IntroPresenter introPanel, Camera menuCamera, Camera mainCamera)
        {
            this.panel = introPanel;
            this.menuCamera = menuCamera;
            this.mainCamera = mainCamera;
        }

        public bool Playing => false;

        public void Begin()
        {
            this.menuCamera.gameObject.SetActive(true);
            this.mainCamera.gameObject.SetActive(false);            
            this.panel.Show();
            this.panel.Repaint();
            AudioManager.Instance.PlayIntermissionMusic();
        }

        public void End()
        {
            //this.menuChar.SetActive(false);
            this.menuCamera.gameObject.SetActive(false);
            this.mainCamera.gameObject.SetActive(true);            
            this.panel.Hide();
            //AudioManager.Instance.StopIntroMusic();
        }

        public void FixedUpdate()
        {
            
        }

        public void Start()
        {
            
        }

        public void Update()
        {
            
        }
    }

}