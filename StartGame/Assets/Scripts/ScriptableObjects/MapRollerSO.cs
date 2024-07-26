using UnityEngine;

[CreateAssetMenu(menuName = "GameStats/MapRoller", fileName = "Map Roller Stats")]
public class MapRollerSO : ScriptableObject
{
    [field: SerializeField] public float RotationSpeed { get; private set; }
    [field: SerializeField] public float ReturnSpeed  { get; private set; }
}
