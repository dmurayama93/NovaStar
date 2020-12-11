using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapons_Display_UI : MonoBehaviour
{
    [SerializeField]
    private Text _weaponLevelText;

    private void Start()
    {
        _weaponLevelText.text = "LEVEL 1: FIREBALL";
    }

    public void UpdateWeaponLevel(string level)
    {
        _weaponLevelText.text = level;
    }
}
