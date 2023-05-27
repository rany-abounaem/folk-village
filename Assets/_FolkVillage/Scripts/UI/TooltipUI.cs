using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TooltipUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _tooltipText;

    public void UpdateTooltip(string text)
    {
        _tooltipText.text = text;
    }
}
