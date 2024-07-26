using UnityEngine;

public class ScoreHandler : MonoBehaviour
{
    private int _score;

    public void AddToScore(int amount)
    {
        _score += amount;
        Debug.Log(_score);
    }
}
