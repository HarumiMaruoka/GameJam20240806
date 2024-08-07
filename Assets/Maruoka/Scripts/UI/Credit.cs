using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class Credit : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        gameObject.SetActive(false);
    }
}
