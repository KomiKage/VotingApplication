using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class JoystickMovement : MonoBehaviour,IDragHandler,IPointerDownHandler,IPointerUpHandler
{
    public RectTransform Background;

    public RectTransform Handle;
    [Range(0, 2f)] public float HandleLimit = 1f;
    public static Vector2 input = Vector2.zero;
    Vector2 JoyPosition = Vector2.zero;

    public float Vertical { get { return input.y; } }
    public float Horizontal { get { return input.x; } }

public void OnPointerDown(PointerEventData eventdata)
    {
        Background.gameObject.SetActive(true);
        OnDrag(eventdata);
        JoyPosition = eventdata.position;
        Background.position = eventdata.position;
        Handle.anchoredPosition = Vector2.zero;
    }
    public void OnDrag(PointerEventData eventdata)
    {
        Vector2 joyDirection = eventdata.position - JoyPosition;
        input = (joyDirection.magnitude > Background.sizeDelta.x / 2f) ? joyDirection.normalized:
        joyDirection / (Background.sizeDelta.x / 2f);


        Handle.anchoredPosition = (input * Background.sizeDelta.x / 2f) * HandleLimit;

    }
    public void OnPointerUp(PointerEventData eventdata)
    {
        Background.gameObject.SetActive(false); 
        input = Vector2.zero;
        Handle.anchoredPosition = Vector2.zero;
    }

}
