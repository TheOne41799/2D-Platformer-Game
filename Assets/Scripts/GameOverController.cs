using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameOverController : MonoBehaviour
{
    [SerializeField] private Button restartButton;


    private void Awake()
    {
        restartButton.onClick.AddListener(ReloadLevel);
    }


    public void PlayerDeath()
    {
        gameObject.SetActive(true);
    }


    private void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}



