using UnityEngine;

public class CurseTriggerZone : MonoBehaviour
{
    [Header("�� ������ �� ��? (��: 1�� = 1)")]
    public int floorLevel;

    [Header("������ �� ����� ����")]
    public CurseData descendCurse;

    [Header("�ö� �� ����� ����")]
    public CurseData ascendCurse;

    [HideInInspector] public bool hasTriggeredDescend = false;
    [HideInInspector] public bool hasTriggeredAscend = false;
}
