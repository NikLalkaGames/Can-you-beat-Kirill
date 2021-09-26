using Items.CoinManagement;
using UnityEngine;

namespace Common
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; } = null;

        [SerializeField] private SceneLoader sceneLoader;

        [SerializeField] private CoinManager coinManager;


        [SerializeField] private bool testMode;

        private void Awake() 
        {
            Debug.Log("GameManager Awake");
            if (Instance == null) Instance = this;
            Application.targetFrameRate = 60;
            DontDestroyOnLoad(gameObject);
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
    }
}