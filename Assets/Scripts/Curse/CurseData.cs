using UnityEngine;

[CreateAssetMenu(fileName = "NewCurse", menuName = "Curse/CurseData")]
public class CurseData : ScriptableObject
{
    public CurseType curseType;
    public string curseName;
    public float duration = 10f;
    public float power = 10f;
}
