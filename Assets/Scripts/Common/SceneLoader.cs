using System;
using Common.Containers;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Common
{
    public static class SceneLoader
    {
        public static void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
            SceneManager.sceneLoaded += OnSceneLoad;
        }

        private static void OnSceneLoad(Scene loadedScene, LoadSceneMode mode)
        {
            Debug.Log("Scene Loaded: " + loadedScene.name);
            
            SceneManager.SetActiveScene(loadedScene);
            Debug.Log("Active scene: " + SceneManager.GetActiveScene().name);

            SceneManager.sceneLoaded -= OnSceneLoad;
            Debug.Log("OnSceneLoad actions has called successfully");
        }
    }
}