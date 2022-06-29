using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class ButtonHover2 : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image buttonText;
    private Color32 original = new Color32(0, 0, 0, 255);
    private Color32 darken = new Color32(0, 0, 0, 125);

    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonText.color = darken;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonText.color = original;
    }
}
