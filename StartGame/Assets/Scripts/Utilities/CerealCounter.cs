using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class CerealCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text counterText;

    [SerializeField] private RectTransform handle, hiddenPos, shownPos;

    [SerializeField] private float showSpeed, hideSpeed, displayTime;

    private WaitForFixedUpdate _waitForFixedUpdate;

    private ScoreHandler _scoreHandler;

    private void Start()
    {
        Invoke(nameof(FindScoreHandler), 0.01f);
        Invoke(nameof(StartHide), displayTime);
    }

    private void FindScoreHandler()
    {
        _scoreHandler = FindObjectOfType<ScoreHandler>();
        _scoreHandler.AssignCounter(this);
        _scoreHandler.RefreshScore();
    }
    
    public void UpdateCounterText(int value)
    {
        counterText.text = value.ToString();
        StartCoroutine(LerpIntoView());
    }

    private IEnumerator LerpIntoView()
    {
        CancelInvoke(nameof(StartHide));
        while (handle.position.y > shownPos.position.y + 0.05f)
        {
            handle.position = Vector3.Lerp(handle.position, shownPos.position, showSpeed * Time.fixedDeltaTime);
            yield return _waitForFixedUpdate;
        }
        Invoke(nameof(StartHide), displayTime);
        StopAllCoroutines();
    }

    private void StartHide()
    {
        StartCoroutine(LerpOutOfView());
    }

    private IEnumerator LerpOutOfView()
    {
        while (handle.position.y < hiddenPos.position.y - 0.05f)
        {
            handle.position = Vector3.Lerp(handle.position, hiddenPos.position, hideSpeed * Time.fixedDeltaTime);
            yield return _waitForFixedUpdate;
        }
        StopAllCoroutines();
    }
}
