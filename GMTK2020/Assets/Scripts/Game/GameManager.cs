using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private LevelData[] levelData;

    [Header("Debug")]
    [SerializeField] private int DEBUG_LevelToOpen = 0;

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
#if UNITY_EDITOR
        LoadLevel(DEBUG_LevelToOpen);
#else
        LoadLevel(0);
#endif
    }

    void LoadLevel(int LevelToLoad)
    {
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(levelData[LevelToLoad].SceneIdx, LoadSceneMode.Single);
        loadOperation.completed += OnLevelLoadComplete;
    }

    void OnLevelLoadComplete(AsyncOperation loadOperation)
    {
        InitializeLevel();
    }

    void InitializeLevel()
    {
        LevelManager currentLevelManager = LevelManager.Get();
        if (currentLevelManager)
        {
            currentLevelManager.InitializeLevel();
        }
    }
}