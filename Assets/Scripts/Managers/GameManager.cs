using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
  #region Singleton Pattern
  private static GameManager instance;

  public static GameManager Instance
  {
    get
    {
      if (instance is null)
      {
        GameObject go = new GameObject("GameManager");
        go.AddComponent<GameManager>();
      }
      return instance;
    }
  }
  #endregion

  public enum GameState { PREGAME, RUNING, PAUSED }

  public GameObject[] systemPrefabs;
  private List<GameObject> instanceSystemPrefabs;
  private float experience = 0f;
  private int playerLevel = 1;
  private bool isLoadingLevel = false;
  private List<AsyncOperation> loadOperations;
  private string currentLevelName = string.Empty;
  private GameState currentGameState = GameState.PREGAME;

  public GameState CurrentGameState
  {
    get { return currentGameState; }
    private set { currentGameState = value; }
  }
  public Events.EventGameState OnGameStateChanged;


  [SerializeField] private Character[] characters = null;
  [HideInInspector] public bool isPlayerDead = false;
  [HideInInspector] public int waveNumber = 0;

  private void Awake()
  {
    instance = this;
  }

  private void Start()
  {
    DontDestroyOnLoad(gameObject);
    instanceSystemPrefabs = new List<GameObject>();
    loadOperations = new List<AsyncOperation>();
    InstanciateSystemPrefabs();
    UIManager.Instance.OnMainMenuFadeComplete.AddListener(HandleMainMenuFadeComplete);
  }

  private void Update()
  {
    if (currentGameState == GameState.PREGAME) return;
    if (Input.GetKeyDown(KeyCode.Escape)) TogglePause();
  }

  void HandleMainMenuFadeComplete(bool arg0)
  {
    if (!arg0)
    {
      Debug.Log(currentLevelName);
      UnLoadLevel(currentLevelName);
    }
  }

  public void LoadLevel(string levelName)
  {
    if (isLoadingLevel) return;
    isLoadingLevel = true;
    AsyncOperation ao = SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Additive);
    if (ao == null)
    {
      Debug.LogError("[GameManager] Unable to Load level" + levelName);
      return;
    }
    ao.completed += OnLoadOperationCompleted;
    loadOperations.Add(ao);
    currentLevelName = levelName;
  }

  private void OnLoadOperationCompleted(AsyncOperation ao)
  {
    if (loadOperations.Contains(ao))
    {
      loadOperations.Remove(ao);
      if (loadOperations.Count == 0)
      {
        UpdateState(GameState.RUNING);
      }
    }
    isLoadingLevel = false;
    Debug.Log("Load Completed");
  }

  public void UnLoadLevel(string levelName)
  {
    AsyncOperation ao = SceneManager.UnloadSceneAsync(levelName);
    if (ao == null)
    {
      Debug.LogError("[GameManager] Unable to UnLoad level" + levelName);
      return;
    }
    ao.completed += OnUnLoadOperationCompleted;
  }

  private void OnUnLoadOperationCompleted(AsyncOperation obj)
  {
    Debug.Log("UnLoad Completed");
  }

  void InstanciateSystemPrefabs()
  {
    GameObject prefabInstance;
    for (int i = 0; i < systemPrefabs.Length; i++)
    {
      prefabInstance = Instantiate(systemPrefabs[i]);
      instanceSystemPrefabs.Add(prefabInstance);
    }
  }

  void UpdateState(GameState state)
  {
    GameState previousGameState = currentGameState;
    currentGameState = state;
    switch (currentGameState)
    {
      case GameState.PREGAME:
        Time.timeScale = 1.0f;
        break;
      case GameState.RUNING:
        Time.timeScale = 1.0f;
        break;
      case GameState.PAUSED:
        Time.timeScale = 0.0f;
        break;
      default:
        break;
    }
    OnGameStateChanged.Invoke(currentGameState, previousGameState);
  }


  public void StartGame()
  {
    LoadLevel("Main");
  }

  public void TogglePause()
  {
    UpdateState(currentGameState == GameState.RUNING ? GameState.PAUSED : GameState.RUNING);
  }

  public void RestartGame()
  {
    UpdateState(GameState.PREGAME);
  }

  public void QuitGame()
  {
    Application.Quit();
  }

  public void AddExperience(float newExperience)
  {
    experience += newExperience;
    StatsTextProvider.TriggerOnHasExperienceChange(experience.ToString());
    LevelUp();
  }

  public void LevelUp()
  {
    if (characters is null) return;

    for (int i = 0; i < characters.Length; i++)
    {
      if (characters[i].playerLevel is null) continue;

      PlayerLevel playerLevelConfig = characters[i].playerLevel;
      if (playerLevel < playerLevelConfig.levelNumber && experience >= playerLevelConfig.experienceToLevelUp)
      {
        playerLevel += 1;
        InputProvider.TriggerOnHasLevelUp(characters[i]);
        return;
      }
    }
  }

  public void AddWaveNumber()
  {
    waveNumber++;
    StatsTextProvider.TriggerOnHasWaveChange(waveNumber.ToString());
  }

  public void StartNextWaveCounter(float startCounterTime)
  {
    StatsTextProvider.TriggerOnHasStartCounterChange(startCounterTime);
  }
}