using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LevelOverPopupController : MonoBehaviour
{
    [SerializeField] private Button restartButton;
    [SerializeField] private Button lobbyButton;


    private void Awake()
    {
        restartButton.onClick.AddListener(ReloadLevel);
        lobbyButton.onClick.AddListener(GotoLobbySceneMenu);        
    }


    public void LevelCompleted()
    {
        gameObject.SetActive(true);
    }


    private void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        LevelManager.Instance.ReloadLevel(currentSceneIndex);
    }


    private void GotoLobbySceneMenu()
    {
        LevelManager.Instance.LoadLobbyScene();
    }
}
