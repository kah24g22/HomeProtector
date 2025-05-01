using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    public GameObject menu;

    public void Continue()
    {
        Time.timeScale = 1f;
        menu.SetActive(false);
    }

    public void Exit()
    {
        SceneManager.LoadScene("Title");
    }
}
