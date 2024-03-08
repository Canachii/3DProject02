using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public static int Score { get; set; }
    public static int Deaths { get; set; }
    public int Items { get; set; }

    public int requireCoins = 0;
    public Text itemText;
    public Text deathsText;
    public Text stageText;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        requireCoins = GameObject.FindGameObjectsWithTag("Item").Length;
        UpdateUI();
    }

    public void UpdateUI()
    {
        stageText.text = $"Stage: {SceneManager.GetActiveScene().buildIndex + 1} / {SceneManager.sceneCountInBuildSettings}";
        deathsText.text = $"Deaths: {Deaths}";
        itemText.text = $"Item: {Items} / {requireCoins}";
    }
}