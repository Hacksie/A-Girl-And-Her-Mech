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
        [SerializeField] private UnityEngine.UI.Button quitButton;

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

        private void DisableQuitButton()
        {
            quitButton.interactable = Application.platform != RuntimePlatform.WebGLPlayer;
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
            PlayerPreferences.Instance.masterVolume = sliderValue;
            PlayerPreferences.Instance.Save();
            AudioManager.Instance.SetMasterVolume(sliderValue);
        }

        public void OnSFXChangedEvent(float sliderValue)
        {
            PlayerPreferences.Instance.sfxVolume = sliderValue;
            PlayerPreferences.Instance.Save();
            AudioManager.Instance.SetSFXVolume(sliderValue);
        }        

        public void OnMusicChangedEvent(float sliderValue)
        {
            PlayerPreferences.Instance.musicVolume = sliderValue;
            PlayerPreferences.Instance.Save();
            AudioManager.Instance.SetMusicVolume(sliderValue);
        } 

        public void OnInfiniteWaveChangedEvent(bool value) 
        {
            PlayerPreferences.Instance.infiniteWaves = value;
            PlayerPreferences.Instance.Save();
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