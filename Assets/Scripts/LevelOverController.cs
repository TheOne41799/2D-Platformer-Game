using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelOverController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerController>())
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            LevelManager.Instance.MarkLevelCompleteAndUnlockNextLevel(currentSceneIndex);
        }
    }
}
