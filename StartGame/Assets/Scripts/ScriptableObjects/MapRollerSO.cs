using TMPro;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "GameStats/MapRoller", fileName = "Map Roller Stats")]
public class MapRollerSO : ScriptableObject
{
    [field: SerializeField] public float RotationSpeed { get; private set; }
    [field: SerializeField] public float ReturnSpeed  { get; private set; }

    private Slider sensSldier;
    
    public void ChangeSensitivity()
    {
        sensSldier = FindObjectOfType<Slider>();
        TMP_Text sensText = sensSldier.GetComponentInChildren<TMP_Text>();
        RotationSpeed = sensSldier.value;
        sensText.text = $"Sensitivity: {RotationSpeed}";
    }
}
