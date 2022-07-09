using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float _speed = 10.0f;

    void Start() 
    {
        // 혹시라도 내가 다른 곳에서 이미 구독신청을 하고 있었다면 일단 끊은 뒤 다시 날 추가해주렴~
        // 다른 곳에서 구독신청을 하고 있었는데 한 번 더 신청한다면, KeyAction에OnKeyboard가 2번 chaining된 상태이기 때문에 2번씩 호출된다.
        // 이를 방지하기 위해 이미 구독신청을 해놨었다면 끊고 다시 즉 현상유지를 시키기 위해서 코드를 작성한것!
        Managers.Input.KeyAction -= OnKeyboard;
        // InputManager야, KeyAction이 호출되면(아무키가 눌리면) OnKeyboard를 이어서 실행해주렴~
        Managers.Input.KeyAction += OnKeyboard;
    }

    void Update()
    {
        
    }

    void OnKeyboard()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward), 0.2f);
            //transform.Translate(Vector3.forward * Time.deltaTime * _speed);
            transform.position += Vector3.forward * Time.deltaTime * _speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.back), 0.2f);
            //transform.Translate(Vector3.back * Time.deltaTime * _speed);
            transform.position += Vector3.back * Time.deltaTime * _speed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.left), 0.2f);
            //transform.Translate(Vector3.left * Time.deltaTime * _speed);
            transform.position += Vector3.left * Time.deltaTime * _speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.right), 0.2f);
            //transform.Translate(Vector3.right * Time.deltaTime * _speed);
            transform.position += Vector3.right * Time.deltaTime * _speed;
        }
    }
}
