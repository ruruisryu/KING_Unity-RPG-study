using System;
using UnityEngine;

public class InputManager
{
    public Action KeyAction = null;
    public Action<Define.MouseEvent> MouseAction = null;

    // 마우스 입력 상태를 판단하는 변수
    bool _pressed = false;

    public void OnUpdate()
    {
        // 키보드와 달리 마우스는 클릭하는 것 뿐만이 아니라 클릭했다가 떼는 것도 일종의 상태변화라고 볼 수 있기 때문에
        // 아래 코드로 막아버리면 상황에 따라서 마우스 입력이 씹히는 경우가 있으니 키보드 입력에만 영향을 줄 수 있게 코드를 옮겨 준
        // if (Input.anyKey == false)
        //     return;    

        if (Input.anyKey && KeyAction != null)
            KeyAction.Invoke();

        
        if (MouseAction != null)
        {
            if (Input.GetMouseButton(0))
            {
                MouseAction.Invoke(Define.MouseEvent.Press);
                _pressed = true;
            }
            else
            {
                if (_pressed)
                    MouseAction.Invoke(Define.MouseEvent.Click);
                _pressed = false;
            }
        }

    }
}

