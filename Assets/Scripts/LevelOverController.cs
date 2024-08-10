using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelOverController : MonoBehaviour
{
    [SerializeField] private LevelOverPopupController levelOverPopupController;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerController>())
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            LevelManager.Instance.MarkLevelCompleteAndUnlockNextLevel(currentSceneIndex);

            levelOverPopupController.LevelCompleted();
        }
    }
}
