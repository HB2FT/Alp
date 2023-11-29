using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(UnityEngine.UI.Button))]
[AddComponentMenu("UI/MButton",11)]
public class Button : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public ButtonOverlay overlay;
    

    void Start()
    {
        overlay.gameObject.SetActive(false);
    }

    void Update()
    {
        

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        overlay.gameObject.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        overlay.gameObject.SetActive(false);
    }
}
