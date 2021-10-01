

using UnityEngine;

namespace HackedDesign
{
    public class IntroState : IState
    {
        private UI.AbstractPresenter panel;
        private Camera menuCamera;
        private Camera mainCamera;
        private GameObject menuChar;        

        public IntroState(UI.IntroPresenter introPanel, Camera menuCamera, Camera mainCamera, GameObject menuChar)
        {
            this.panel = introPanel;
            this.menuCamera = menuCamera;
            this.mainCamera = mainCamera;
            this.menuChar = menuChar;            
        }

        public bool Playing => false;

        public void Begin()
        {
            UnityEngine.Debug.Log("Begin");
            this.menuChar.SetActive(true);
            this.menuCamera.gameObject.SetActive(true);
            this.mainCamera.gameObject.SetActive(false);            
            this.panel.Show();
            this.panel.Repaint();
        }

        public void End()
        {
            this.menuChar.SetActive(false);
            this.menuCamera.gameObject.SetActive(false);
            this.mainCamera.gameObject.SetActive(true);            
            this.panel.Hide();
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