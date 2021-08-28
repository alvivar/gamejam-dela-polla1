using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableDataWeaponKind", menuName = "Scriptable Objects/ScriptableDataWeaponKind", order = 1)]
public class ScriptableDataWeaponKind : ScriptableObject
{

    public bool isWeapon;
    public Texture weaponSprite;
    public float[] possibleDamage = {20,22,23};
    public string[] possiblesssDamage;
    public string[] asdsdsdsfsfsf = {"a", "b", "c"};
    public bool isAbility;

}
