using System;
using Common.Containers;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

namespace UI
{
    public class PauseMenu : MonoBehaviour
    {
        private bool _gameIsPaused;

        [SerializeField] private GameObject _pauseMenu;

        [SerializeField] private GameObject _enemyToDisable;

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
            _pauseMenu.SetActive(false);
            Time.timeScale = 1f;
            _enemyToDisable.SetActive(true);
            _gameIsPaused = false;
        }

        private void Pause()
        {
            _pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            _enemyToDisable.SetActive(false);
            _gameIsPaused = true;
        }
        
    }
}