using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMenu : MonoBehaviour
{
    public Button[] buttons;
    public GameObject levelButtons;

    private void Awake()
    {
        ButtonstoArray();
        // Clamp so a corrupted or oversized save value can no longer throw IndexOutOfRangeException.
        int unlockedLevel1 = Mathf.Clamp(PlayerPrefs.GetInt("UnlockedLevel1", 1), 1, buttons.Length);
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = i < unlockedLevel1;
        }
    }

    public void OpenLevel(int levelId)
    {
        SceneManager.LoadScene("lv" + levelId);
    }

    void ButtonstoArray()
    {
        Transform parent = levelButtons.transform;
        int childCount = parent.childCount;
        buttons = new Button[childCount];
        for (int i = 0; i < childCount; i++)
        {
            buttons[i] = parent.GetChild(i).GetComponent<Button>();
        }
    }
}
