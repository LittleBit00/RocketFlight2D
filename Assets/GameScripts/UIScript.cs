using UnityEngine;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{
    private bool paused;

    [SerializeField] private GameObject MenuButton;
    [SerializeField] private GameObject BlackoutPanel;

    private void Start()
    {
        Time.timeScale = 1;
        paused = false;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
    public void Pause()
    {
        if (!paused)
        {
            Time.timeScale = 0;
            BlackoutPanel.SetActive(true);
            MenuButton.SetActive(true);
            paused = true;
        }
        else
        {
            Time.timeScale = 1;
            BlackoutPanel.SetActive(false);
            MenuButton.SetActive(false);
            paused = false;
        }        
    }
}
