using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CounterHandler : MonoBehaviour
{
    [SerializeField] private TMP_Text counterText;

    [SerializeField] private string[] counterDetails;

    [SerializeField] private float timeBetweenDetails;

    private WaitForSeconds _waitForDetails;

    private PlayerInputController _inputController;

    private void Awake()
    {
        _waitForDetails = new WaitForSeconds(timeBetweenDetails);
        _inputController = FindObjectOfType<PlayerInputController>();
    }

    public IEnumerator CountdownSequence()
    {
        _inputController.DisableInput();
        foreach (var detail in counterDetails)
        {
            counterText.text = detail;
            Debug.Log("Counting");
            yield return _waitForDetails;
        }

        counterText.text = "";
        _inputController.EnableInput();
    }
}
