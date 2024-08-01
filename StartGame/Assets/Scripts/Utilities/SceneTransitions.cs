using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SceneTransitions : MonoBehaviour
{
    private LevelStatusHandler _levelStatus;

    private CanvasGroup _transitionGroup;
    private WaitForFixedUpdate _waitForFixed;

    [SerializeField] private float fadeSpeed;

    private Leaderboard _leaderboard;
    private TimesHandler _timesHandler;

    private UnityEvent _gameEnded;
    
    private void Start()
    {
        _gameEnded = new UnityEvent();
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
        if (nextScene >= SceneManager.sceneCountInBuildSettings)
        {
            _timesHandler = FindObjectOfType<TimesHandler>();
            _gameEnded.AddListener(_timesHandler.CalculateTotalTimes);
            _gameEnded.Invoke();
            SceneManager.LoadScene(0);
            StopAllCoroutines();
            yield break;
        }
        SceneManager.LoadScene(nextScene);
        StopAllCoroutines();
    }
    public IEnumerator FadeIntoSameScene()
    {
        _transitionGroup.alpha = 0f;
        while (_transitionGroup.alpha < 1f)
        {
            _transitionGroup.alpha = Mathf.Lerp(_transitionGroup.alpha, 1.1f, fadeSpeed * Time.fixedDeltaTime);
            yield return _waitForFixed;
        }

        var nextScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(nextScene);
        StopAllCoroutines();
    }
}
