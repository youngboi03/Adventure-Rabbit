using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishPoint : MonoBehaviour
{
    private bool finished;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (finished || !collision.CompareTag("Player"))
            return;

        finished = true;
        UnlockNewLevel();
        SceneController.instance.NextLevel();
    }

    void UnlockNewLevel()
    {
        int buildIndex = SceneManager.GetActiveScene().buildIndex;

        // A stray semicolon used to make this block run every time, so replaying a level kept unlocking more levels.
        if (buildIndex >= PlayerPrefs.GetInt("ReachedIndex"))
        {
            PlayerPrefs.SetInt("ReachedIndex", buildIndex + 1);
            // Build index N is level N, so finishing it unlocks level N + 1.
            PlayerPrefs.SetInt("UnlockedLevel1", Mathf.Max(PlayerPrefs.GetInt("UnlockedLevel1", 1), buildIndex + 1));
            PlayerPrefs.Save();
        }
    }
}
