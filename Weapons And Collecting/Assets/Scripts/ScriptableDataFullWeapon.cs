using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableDataFullWeapon", menuName = "Scriptable Objects/ScriptableDataFullWeapon", order = 1)]
public class ScriptableDataFullWeapon : ScriptableObject
{

    public string weaponName;
    public List<ScriptableDataWeaponKind> kinds = new List<ScriptableDataWeaponKind>();

}
