using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// Extension 클래스를 만들 때는 static을 붙여주고, MonoBehaviour를 뺴주어야한다
public static class Extension
{
    // this를 추가해준다
    public static void AddUIEvent(this GameObject go, Action<PointerEventData> action, Define.UIEvent type = Define.UIEvent.Click)
    {
        UI_Base.AddUIEvent(go, action, type);
    }
}
