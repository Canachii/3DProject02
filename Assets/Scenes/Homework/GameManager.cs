using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public static int Score { get; set; }
    public static int Deaths { get; set; }
    public int ItemCount { get; set; }
    public GameObject[] Items { get; set; }

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip stageClearSound;
    public AudioClip gameOverSound;
    public AudioClip itemCollectedSound;

    [Header("UI")]
    public GameObject[] stages;
    public int requireCoins = 0;
    public Text itemText;
    public Text deathsText;
    public Text stageText;
    public Text scoreText;
    public GameObject HUD;
    public GameObject result;

    private int _currentStage = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        Items = GameObject.FindGameObjectsWithTag("Item");
        audioSource = GetComponent<AudioSource>();
        UpdateUI();
    }

    public void StageClear()
    {
        Debug.Log("Stage Clear!");
        if (stageClearSound) audioSource.PlayOneShot(stageClearSound);
        Score += 10000;
        _currentStage++;
        if (_currentStage >= stages.Length)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            HUD.SetActive(false);
            result.SetActive(true);
            if (PlayerPrefs.GetInt("Score", 0) < Score)
                PlayerPrefs.SetInt("Score", Score);
        }
        else
        {
            for (var i = 0; i < stages.Length; i++)
            {
                stages[i].SetActive(i == _currentStage);
            }
            Items = GameObject.FindGameObjectsWithTag("Item");
            ItemCount = 0;
        }
        UpdateUI();
    }

    public void GameOver()
    {
        Debug.Log("Game Over!");
        if (gameOverSound) audioSource.PlayOneShot(gameOverSound);
        ItemCount = 0;
        foreach (var v in Items)
        {
            v.SetActive(true);
        }
        Deaths++;
        Score -= 10;
    }

    public void UpdateUI()
    {
        stageText.text = $"Stage: {_currentStage + 1} / {stages.Length}";
        deathsText.text = $"Deaths: {Deaths}";
        
        requireCoins = Items.Length;
        itemText.text = $"Item: {ItemCount} / {requireCoins}";
        
        scoreText.text = $"HighScore: {PlayerPrefs.GetInt("Score", 0)}\nScore: {Score}";
    }
    
    public void SetVolume(float value)
    {
        audioSource.volume = value;
    }
}