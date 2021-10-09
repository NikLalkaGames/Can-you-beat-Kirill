using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Common.GameManagement
{
    public class SceneLoader : MonoBehaviour
    {
        public static SceneLoader Instance { get; private set; } = null;

        [SerializeField] private float delayDuration;

        private Coroutine _loadingRoutine;

        private void Awake()
        {
            Debug.Log("SceneLoader Awake");
            if (Instance == null) Instance = this;
        }

        public void CoroutineLoading(string sceneName)
        {
            _loadingRoutine ??= StartCoroutine(LoadScene(sceneName, delayDuration));

            _loadingRoutine = null;
        }

        public IEnumerator LoadScene(string sceneName, float delayDuration)
        {
            yield return new WaitForSeconds(delayDuration);
            SceneManager.sceneLoaded += OnSceneLoad;    // subscribe to event on scene load
            SceneManager.LoadScene(sceneName);
        }

        public void LoadScene(string sceneName)
        {
            SceneManager.sceneLoaded += OnSceneLoad;    // subscribe to event on scene load
            SceneManager.LoadScene(sceneName);
        }

        private void OnSceneLoad(Scene loadedScene, LoadSceneMode mode)
        {
            Debug.Log("Scene Loaded: " + loadedScene.name);
            SetActivePlayableScene(loadedScene);
            GameManager.Instance.RefreshGamingStats();
        
            SceneManager.sceneLoaded -= OnSceneLoad;
            Debug.Log("OnSceneLoad actions has called successfully");
        }

        private void SetActivePlayableScene(Scene current)
        {
            SceneManager.SetActiveScene(current);
            Debug.Log("Active scene: " + SceneManager.GetActiveScene().name);
        }
    }
}