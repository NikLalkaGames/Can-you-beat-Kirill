using Common;
using UnityEngine;

namespace UI
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private string _playButtonScene;

        [SerializeField] private string _settingsButtonScene;

        [SerializeField] private string _creditsButtonScene;

        public void OnPlayButtonClicked()
        {
            SceneLoader.LoadScene(_playButtonScene);
        }

        public void OnSettingsButtonClicked()
        {
            Debug.Log("Settings button clicked");
        }

        public void OnCreditsButtonClicked()
        {
            Debug.Log("Credits button clicked");
        }

        public void OnExitButtonClicked()
        {
            Application.Quit();
        }
    }
}