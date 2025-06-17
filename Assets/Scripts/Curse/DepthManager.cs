using System.Collections.Generic;
using UnityEngine;

public class DepthManager : MonoBehaviour
{
    [Header("플레이어 위치 추적")]
    public Transform playerTransform;

    [Header("저주 적용 대상")]
    public CurseManager curseManager;

    [Header("등록된 CurseTriggerZone 리스트")]
    public List<CurseTriggerZone> curseZones = new List<CurseTriggerZone>();

    private int currentFloor = 0;

    void Update()
    {
        if (playerTransform == null || curseManager == null)
            return;

        foreach (var zone in curseZones)
        {
            // 플레이어가 트리거보다 낮은 층으로 내려간 경우
            if (playerTransform.position.y <= zone.transform.position.y && zone.floorLevel > currentFloor)
            {
                if (!zone.hasTriggeredDescend && zone.descendCurse != null)
                {
                    curseManager.ApplyCurse(zone.descendCurse);
                    zone.hasTriggeredDescend = true;
                    currentFloor = zone.floorLevel;
                    Debug.Log($"⬇️ 내려감 → {zone.descendCurse.curseName} 적용됨 (Floor {zone.floorLevel})");
                }
            }

            // 플레이어가 위로 올라간 경우 (역저주)
            if (playerTransform.position.y > zone.transform.position.y && zone.floorLevel == currentFloor)
            {
                if (!zone.hasTriggeredAscend && zone.ascendCurse != null)
                {
                    curseManager.ApplyCurse(zone.ascendCurse);
                    zone.hasTriggeredAscend = true;
                    currentFloor = zone.floorLevel - 1;
                    Debug.Log($"⬆️ 올라감 → {zone.ascendCurse.curseName} 적용됨 (Floor {zone.floorLevel})");
                }
            }
        }
    }
}
