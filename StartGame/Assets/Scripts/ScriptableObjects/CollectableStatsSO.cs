using UnityEngine;

[CreateAssetMenu(menuName = "GameStats/CollectableStats", fileName = "Collectable Stats")]
public class CollectableStatsSO : ScriptableObject
{
    [field: SerializeField] public int PointValue { get; private set; }
}
