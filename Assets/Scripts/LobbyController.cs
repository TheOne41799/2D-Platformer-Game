using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LobbyController : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button quitButton;

    [SerializeField] private Image levelSelectionPopupMenu;

    [SerializeField] private Button level1Button;
    [SerializeField] private Button level2Button;
    [SerializeField] private Button level3Button;
    [SerializeField] private Button level4Button;

    //[SerializeField] private Button[] levelChangeButtons;


    private void Start()
    {
        playButton.gameObject.SetActive(true);
        quitButton.gameObject.SetActive(true);
        levelSelectionPopupMenu.gameObject.SetActive(false);

        playButton.onClick.AddListener(PlayGame);
        quitButton.onClick.AddListener(Quit);

        level1Button.onClick.AddListener(() => ChangeLevel(1));
        level2Button.onClick.AddListener(() => ChangeLevel(2));
        level3Button.onClick.AddListener(() => ChangeLevel(3));
        level4Button.onClick.AddListener(() => ChangeLevel(4));

        /*for (int i = 0; i < levelChangeButtons.Length; i++)
        {
            levelChangeButtons[i].onClick.AddListener(() => ChangeLevel(i));
        }*/
    }


    private void PlayGame()
    {
        playButton.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(false);
        levelSelectionPopupMenu.gameObject.SetActive(true);
    }


    private void ChangeLevel(int levelNumber)
    {
        SceneManager.LoadScene(levelNumber);
    }


    public void Quit()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
