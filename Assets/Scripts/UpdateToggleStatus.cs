using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateToggleStatus : MonoBehaviour
{
    [SerializeField] private Toggle toggle;
    [SerializeField] private Accesability toggleValue;

    private void OnEnable() => toggle.isOn = toggleValue.value;
}
