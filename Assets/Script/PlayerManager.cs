using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public static bool isGameOver;
    public GameObject gameOverScreen;
    public static Vector2 lastCheckPointPos = new Vector2(-3, 8);

    private static PlayerManager current;

    private void Awake()
    {
        current = this;
        isGameOver = false;

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
            player.transform.position = lastCheckPointPos;
    }

    private void OnDestroy()
    {
        if (current == this)
            current = null;
    }

    // Event-driven instead of polling isGameOver in Update every frame.
    public static void GameOver()
    {
        isGameOver = true;
        if (current != null && current.gameOverScreen != null)
            current.gameOverScreen.SetActive(true);
    }

    public void ReplayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
