using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject Shop;
    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void OpenShop() { Shop.SetActive(true); }
    public void CloseShop() { Shop.SetActive(false); }
}
