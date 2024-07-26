using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitions : MonoBehaviour
{
    private LevelStatusHandler _levelStatus;

    private CanvasGroup _transitionGroup;
    private WaitForFixedUpdate _waitForFixed;

    [SerializeField] private string nextSceneName;

    [SerializeField] private float fadeSpeed;
    
    void Start()
    {
        _levelStatus = FindObjectOfType<LevelStatusHandler>();
        _transitionGroup = GetComponent<CanvasGroup>();
        _waitForFixed = new WaitForFixedUpdate();

        
        StartCoroutine(FadeOutTransition());
    }

    public IEnumerator FadeOutTransition()
    {
        _transitionGroup.alpha = 1;
        while (_transitionGroup.alpha > 0f)
        {
            _transitionGroup.alpha = Mathf.Lerp(_transitionGroup.alpha, -0.1f, fadeSpeed * Time.fixedDeltaTime);
            yield return _waitForFixed;
        }
        StopAllCoroutines();
    }

    public IEnumerator FadeIntoNewScene()
    {
        _transitionGroup.alpha = 0f;
        while (_transitionGroup.alpha < 1f)
        {
            _transitionGroup.alpha = Mathf.Lerp(_transitionGroup.alpha, 1.1f, fadeSpeed * Time.fixedDeltaTime);
            yield return _waitForFixed;
        }

        var nextScene = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextScene >= SceneManager.sceneCountInBuildSettings - 1)
        {
            Debug.LogWarning("There are no more scenes in the build index after current scene");
            StopAllCoroutines();
            yield return null;
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        StopAllCoroutines();
    }
}
