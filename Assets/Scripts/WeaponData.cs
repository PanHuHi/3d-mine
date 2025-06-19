using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType
{
    Sword,
    Spear,
    Bow,
    Hammer,
    Dagger
}


[CreateAssetMenu(menuName = "Equipment/Weapon")]
public class WeaponData : ScriptableObject
{
    public string weaponName;             // �̸� (��: "ö��")
    public WeaponType type;              // ���� ���� (������)
    public float attackPower;            // ���ݷ�
    public Sprite icon;                  // UI�� ������
}
