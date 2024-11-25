using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private AudioSource soundLvL;
    [SerializeField] private AudioSource soundWin;
    [SerializeField] private AudioSource soundLoose;
    [SerializeField] private GameObject WinPanel;
    [SerializeField] private GameObject WinText;
    [SerializeField] private GameObject LooseText;
    [SerializeField] private Button playButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private Slider progressSlider;
    int progressAmount;

    private void Awake()
    {
        soundLvL = FindAnyObjectByType<AudioSource>();
        playButton.onClick.AddListener(GoToGamePlay);
        exitButton.onClick.AddListener(OnExitButtonClicked);
    }
    void Start()
    {
        progressAmount = 0;
        progressSlider.value = 0;
        Gem.OnGemCollect += IncreaseProgressAmount;
    }
    private void OnDestroy()
    {
        playButton.onClick.RemoveAllListeners();
        exitButton.onClick.RemoveAllListeners();
        

    }

    void IncreaseProgressAmount(int amount)
    {
        progressAmount += amount;
        progressSlider.value = progressAmount;

        if (progressAmount >= 100) 
        {
            Win();
        }
    }
    void Win()
    {
        soundLvL.Stop();
        soundWin.Play();
        Time.timeScale = 0;
        WinPanel.SetActive(true);
        WinText.SetActive(true);

    }
    void Loose()
    {
        soundLvL.Stop();
        soundLoose.Play();
        Time.timeScale = 0;
        WinPanel.SetActive(true);
        LooseText.SetActive(true);

    }

    void Update()
    {
        
    }

    private void GoToGamePlay()
    {

        SceneManager.LoadScene("GamePlay");
    }
    private void OnExitButtonClicked()
    {
        if (UnityEditor.EditorApplication.isPlaying)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
        else
        {
            Application.Quit();
        }
    }
}
