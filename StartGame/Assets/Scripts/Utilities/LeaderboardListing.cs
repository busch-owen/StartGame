using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LeaderboardListing : MonoBehaviour
{
    [field: SerializeField] public TMP_Text TierText { get; private set; }
    [field: SerializeField] public TMP_Text NameText { get; private set; }
    [field: SerializeField] public TMP_Text TimeText { get; private set; }
}
