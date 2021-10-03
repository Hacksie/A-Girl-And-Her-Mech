using UnityEngine;
using UnityEngine.Audio;

namespace HackedDesign.UI
{
    public class MainMenuPresenter : AbstractPresenter
    {
        public GameObject optionsPanel;
        public GameObject creditsPanel;
        [SerializeField] private UnityEngine.UI.Slider masterSlider;
        [SerializeField] private UnityEngine.UI.Slider sfxSlider;
        [SerializeField] private UnityEngine.UI.Slider musicSlider;

        public override void Repaint()
        {
            switch (GameManager.Instance.GameData.menuState)
            {
                case MenuState.Play:
                    optionsPanel.SetActive(false);
                    creditsPanel.SetActive(false);
                    break;
                case MenuState.Options:
                    optionsPanel.SetActive(true);
                    creditsPanel.SetActive(false);
                    break;
                case MenuState.Credits:
                    optionsPanel.SetActive(false);
                    creditsPanel.SetActive(true);
                    break;
                case MenuState.Quit:
                    optionsPanel.SetActive(false);
                    creditsPanel.SetActive(false);
                    break;
            }
        }

        public void PlayClickEvent()
        {
            GameManager.Instance.SetIntro();
        }

        public void OptionsClickEvent()
        {
            GameManager.Instance.GameData.menuState = MenuState.Options;

        }

        public void CreditsClickEvent()
        {
            GameManager.Instance.GameData.menuState = MenuState.Credits;
        }

        public void QuitClickEvent()
        {
            GameManager.Instance.Quit();
        }

        public void OnMasterChangedEvent(float sliderValue)
        {
            AudioManager.Instance.SetMasterVolume(sliderValue);
        }

        public void OnSFXChangedEvent(float sliderValue)
        {
            AudioManager.Instance.SetSFXVolume(sliderValue);
        }        

        public void OnMusicChangedEvent(float sliderValue)
        {
            AudioManager.Instance.SetMusicVolume(sliderValue);
        }        

    }

    public enum MenuState
    {
        Play,
        Options,
        Credits,
        Quit
    }
}