using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ArmorType
{
    Cloth,
    Leather,
    Chainmail,
    Plate,
    Heavy
}

[CreateAssetMenu(menuName = "Equipment/Armor")]
public class ArmorData : ScriptableObject
{
    public string armorName;             // 이름 (예: "철갑옷")
    public ArmorType type;               // 방어구 종류 (열거형)
    public float defense;                // 방어력
    public Sprite icon;                  // UI용 아이콘
}