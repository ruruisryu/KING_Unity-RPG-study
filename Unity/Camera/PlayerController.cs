using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float _speed = 10.0f;

    // 클릭하여 움직일 목적지 좌표
    Vector3 _destPos;

    // _desTPos로 이동할지 말지 정하는 변수
    bool _moveToDes = false;

    void Start() 
    {
        Managers.Input.KeyAction -= OnKeyboard;
        Managers.Input.KeyAction += OnKeyboard;
        // 마우스 이벤트 구독
        Managers.Input.MouseAction -= OnMouseClicked;
        Managers.Input.MouseAction += OnMouseClicked;
    }

    void Update()
    {
        if (_moveToDes)
        {
            Vector3 dir = _destPos - transform.position;
            // 목적지에 도착했을 경우
            if (dir.magnitude < 0.0001f)
            {
                _moveToDes = false;
            }
            // 목적지에 아직 도착하지 않았을 경우
            else
            {
                // 1프레임 당 이동거리는 최솟값으로 0, 최댓값으로 dir값(남은 거리)을 갖는다
                float moveDist = Mathf.Clamp(_speed*Time.deltaTime, 0, dir.magnitude);

                transform.position += dir.normalized * moveDist;
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 0.2f);
            }
        }
    }

    void OnKeyboard()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward), 0.2f);
            transform.position += Vector3.forward * Time.deltaTime * _speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.back), 0.2f);
            transform.position += Vector3.back * Time.deltaTime * _speed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.left), 0.2f);
            transform.position += Vector3.left * Time.deltaTime * _speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.right), 0.2f);
            transform.position += Vector3.right * Time.deltaTime * _speed;
        }

        // 키보드는 클릭한 곳으로 이동하는 방식이 아니므로 _moveToDest를 false로 바꿔준다
        _moveToDes = false;
    }

    // 마우스는 Action에 마우스 이벤트를 넣었으므로 OnMouseClicked함수에도 마우스 이벤트를 넘겨줘야한다
    void OnMouseClicked(Define.MouseEvent evt)
    {
        // 마우스 이벤트가 클릭이 아니라면 실행 X
        if (evt != Define.MouseEvent.Click)
            return;

        // Raycasting 코드
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(Camera.main.transform.position, ray.direction * 100.0f, Color.red, 1.0f);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100.0f, LayerMask.GetMask("Wall")))
        {
            _destPos = hit.point;
            _moveToDes = true;
        }
    }
}
