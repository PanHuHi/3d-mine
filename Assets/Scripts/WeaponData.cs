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
    public string weaponName;             // 이름 (예: "철검")
    public WeaponType type;              // 무기 종류 (열거형)
    public float attackPower;            // 공격력
    public Sprite icon;                  // UI용 아이콘
}
