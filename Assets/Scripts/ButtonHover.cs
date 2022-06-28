using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class ButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public TextMeshProUGUI buttonText;
    private Color32 original = new Color32(254, 249, 229, 255);
    private Color32 darken = new Color32(254, 249, 229, 125);

    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonText.color = darken;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonText.color = original;
    }


}