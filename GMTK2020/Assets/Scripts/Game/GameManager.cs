using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private int[] sceneIdxs;

    private int currentLevel = -1;

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

    public void LevelComplete()
    {
        if (currentLevel < sceneIdxs.Length - 1)
        {
            LoadLevel(currentLevel + 1);
        }
    }

    void LoadLevel(int LevelToLoad)
    {
        currentLevel = LevelToLoad;
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(sceneIdxs[LevelToLoad], LoadSceneMode.Single);
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