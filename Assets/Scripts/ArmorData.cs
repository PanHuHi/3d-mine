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
    public string armorName;             // �̸� (��: "ö����")
    public ArmorType type;               // �� ���� (������)
    public float defense;                // ����
    public Sprite icon;                  // UI�� ������
}