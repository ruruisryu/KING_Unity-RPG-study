using UnityEngine;

public class CameraController : MonoBehaviour
{
    // 아래 3개의 변수는 유니티 인터페이스에서 조작할 수 있도록 열어둔다

    // 카메라의 모드
    [SerializeField]
    Define.CameraMode _mode = Define.CameraMode.QuarterView;

    // 플레이어와의 position 델타 값
    [SerializeField]
    Vector3 _delta;

    // 플레이어 오브젝트는 유니티 인터페이스에서 드래그드롭으로 가져옴
    [SerializeField]
    GameObject _player; 

    void Start()
    { }

    void LateUpdate()
    {
        if (_mode == Define.CameraMode.QuarterView)
        {
            // 카메라의 position은 플레이어의 position에 델타값을 더한 값
            transform.position = _player.transform.position + _delta;

            transform.LookAt(_player.transform);
        }
    }
		
		// 외부에서 쿼터뷰를 세팅할 수 있도록 하는 함수
    public void SetQuarterView(Vector3 delta)
    {
        _mode = Define.CameraMode.QuarterView;
        _delta = delta;
    }
}
