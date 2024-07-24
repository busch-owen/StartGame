using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] string scene; //scene name
    [SerializeField] GameObject mainMenuUI;
    [SerializeField] GameObject creditsUI;
    [SerializeField] GameObject memeUI;

    public void StartGame()
    {
        SceneManager.LoadScene(scene);
    }

    public void LoadMemeMenuUI()
    {
        mainMenuUI.SetActive(false);
        memeUI.SetActive(true);
    }

    public void LoadCreditsMenuUI()
    {
        mainMenuUI.SetActive(false);
        creditsUI.SetActive(true);
    }

    public void LoadMainMenuUI()
    {
        creditsUI.SetActive(false);
        mainMenuUI.SetActive(true);
    }
}