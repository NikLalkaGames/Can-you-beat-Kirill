using Common;
using UnityEngine;

namespace UI
{
    public class PauseMenu : MonoBehaviour
    {
        private bool _gameIsPaused;

        [SerializeField] private GameObject _pauseMenu;

        [SerializeField] private Transform _viewTransform;

        private Vector3 _viewPos;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (_gameIsPaused) Resume();
                else Pause();
            }
        }

        public void Resume()
        {
            _viewTransform.position = _viewPos;
            _pauseMenu.SetActive(false);
            Time.timeScale = 1f;
            _gameIsPaused = false;
        }

        private void Pause()
        {
            _viewPos = _viewTransform.position;
            _viewTransform.position = new Vector3(_viewPos.x, _viewPos.y, 0);
            _pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            _gameIsPaused = true;
        }

        public void ReturnToMenu()
        {
            _gameIsPaused = false;
            Time.timeScale = 1f;
            SceneLoader.LoadScene("EntryScene");
        }

        public void Exit()
        {
            Application.Quit();
        }

    }
}