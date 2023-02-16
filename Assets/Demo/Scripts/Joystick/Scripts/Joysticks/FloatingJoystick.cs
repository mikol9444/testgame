using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using System;

public class FloatingJoystick : Joystick
{
    [System.Serializable]
    public class JoystickEvent : UnityEvent<Vector2> { }
    public Action<Vector2> onJoystick;
    public Action<bool> pointerDown;
    public JoystickEvent onDirectionChanged;
    protected override void Start()
    {
        base.Start();
        background.gameObject.SetActive(false);
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        background.anchoredPosition = ScreenPointToAnchoredPosition(eventData.position);
        background.gameObject.SetActive(true);
        base.OnPointerDown(eventData);
        onJoystick?.Invoke(Direction);
        pointerDown?.Invoke(true);
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        background.gameObject.SetActive(false);
        base.OnPointerUp(eventData);
        onJoystick?.Invoke(Direction);
        pointerDown?.Invoke(false);
    }
    public override void OnDrag(PointerEventData eventData)
    {
        base.OnDrag(eventData);
        onJoystick?.Invoke(Direction);
    }
}