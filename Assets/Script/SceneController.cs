using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController instance;

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

    public void NextLevel()
    {
        int next = SceneManager.GetActiveScene().buildIndex + 1;
        // After the last level, return to the main menu instead of loading a scene that does not exist.
        SceneManager.LoadSceneAsync(next < SceneManager.sceneCountInBuildSettings ? next : 0);
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);
    }
}
