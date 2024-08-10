using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private static LevelManager instance;
    public static LevelManager Instance
    {
        get
        {
            return instance;
        }
    }

    readonly private int levelZero = 0;
    readonly private int levelOne = 1;
    readonly private int totalNumberOfLevels = 4;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    private void Start()
    {
        //PlayerPrefs.DeleteAll();

        if(GetLevelStatus(levelOne) == LevelStatus.LOCKED)
        {
            SetLevelStatus(levelOne, LevelStatus.UNLOCKED);
        }
    }


    public LevelStatus GetLevelStatus(int level)
    {
        LevelStatus levelStatus = (LevelStatus) PlayerPrefs.GetInt(level.ToString(), 0);
        return levelStatus;
    }


    public void SetLevelStatus(int level, LevelStatus levelStatus)
    {
        PlayerPrefs.SetInt(level.ToString(), (int) levelStatus);
        Debug.Log("Level: " + level + " Status: " + levelStatus);
    }


    public void MarkLevelCompleteAndUnlockNextLevel(int level)
    {
        SetLevelStatus(level, LevelStatus.COMPLETED);

        if(level < totalNumberOfLevels)
        {
            if (GetLevelStatus(level + 1) == LevelStatus.LOCKED)
            {
                SetLevelStatus(level + 1, LevelStatus.UNLOCKED);
            }
        }
        else
        {
            Debug.Log("All levels have been finished");
        }

        SceneManager.LoadScene(levelZero);
    }
}



