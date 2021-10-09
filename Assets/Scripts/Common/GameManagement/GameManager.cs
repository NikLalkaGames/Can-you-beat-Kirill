using Items.CoinManagement;
using UnityEngine;

namespace Common.GameManagement
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; } = null;

        [SerializeField] private SceneLoader sceneLoader;

        [SerializeField] private CoinManager coinManager;


        [SerializeField] private bool testMode;
        
        
        #region InGame variables
        
        public Vector2 MousePosition { get; private set; }

        private Camera _camera;

        #endregion

        private void Awake() 
        {
            // Application.targetFrameRate = 60;
            
            Debug.Log("GameManager Awake");
            if (Instance == null) Instance = this;
            DontDestroyOnLoad(gameObject);
            
            _camera = Camera.main;
        }

        private void Start()
        {
            if (testMode) return;
            
            StartCoroutine(SceneLoader.Instance.LoadScene("MainMenu", 0.5f));
        }

        public void RefreshGamingStats()
        {
            CoinManager.Instance.CoinValue = 0;
        }

        private void RefreshPlayerData()
        {

        }

        private void Update()
        {
            MousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
        }
    }
}