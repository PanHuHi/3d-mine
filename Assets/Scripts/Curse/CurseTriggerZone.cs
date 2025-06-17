using UnityEngine;

public class CurseTriggerZone : MonoBehaviour
{
    [Header("이 구역은 몇 층? (예: 1층 = 1)")]
    public int floorLevel;

    [Header("내려갈 때 적용될 저주")]
    public CurseData descendCurse;

    [Header("올라갈 때 적용될 저주")]
    public CurseData ascendCurse;

    [HideInInspector] public bool hasTriggeredDescend = false;
    [HideInInspector] public bool hasTriggeredAscend = false;
}
