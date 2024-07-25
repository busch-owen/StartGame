using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] string scene; //scene name
    [SerializeField] GameObject mainMenuUI;
    [SerializeField] GameObject creditsUI;
    [SerializeField] GameObject memeUI;
    [SerializeField] GameObject dialogBox;

    private int _counter;

    private void Awake()
    {
        _counter = 0;
    }

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

    public void ClickCounter()
    {
        _counter += 1;
        Debug.Log("Counter:" + _counter);

        if (_counter == 10)
        {
            dialogBox.SetActive(true);
            
        }
        else if (_counter == 11)
        {
            dialogBox.SetActive(false);
        }
        else if (_counter == 20)
        {
            LoadCreditsMenuUI();
        }
    }
}