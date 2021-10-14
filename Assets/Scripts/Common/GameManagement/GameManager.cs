using UnityEngine;

namespace Common.GameManagement
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; } = null;

        [SerializeField] private SceneLoader sceneLoader;

        [SerializeField] private bool testMode;

        private void Awake() 
        {
            // Application.targetFrameRate = 60;
            
            Debug.Log("GameManager Awake");
            if (Instance == null) Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        private void Start()
        {
            if (testMode) return;
            
            StartCoroutine(SceneLoader.Instance.LoadScene("MainMenu", 0.5f));
        }
    }
}