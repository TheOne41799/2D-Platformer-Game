using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelOverController : MonoBehaviour
{
    [SerializeField] private LevelOverPopupController levelOverPopupController;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerController>())
        {
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            playerController.DestroyPlayerOnLevelFinish();

            SoundManager.Instance.Play(Sounds.LEVEL_COMPLETE);

            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            LevelManager.Instance.MarkLevelCompleteAndUnlockNextLevel(currentSceneIndex);

            levelOverPopupController.LevelCompleted();
        }
    }
}
