using UnityEngine;

public class LevelAnchor : MonoBehaviour
{
    private Vector3 _originalPosition;
    
    private void Start()
    {
        _originalPosition = transform.position;
    }

    private void Update()
    {
        transform.position = new Vector3(0, _originalPosition.y, 0);
    }
}
