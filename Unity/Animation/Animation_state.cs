using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float _speed = 10.0f;

    Vector3 _destPos;

    // bool _moveToDes = false; 움직이냐 아니냐를 관리하던 bool변수 => state로 대체하므로 삭제

    void Start() 
    {
        Managers.Input.MouseAction -= OnMouseClicked;
        Managers.Input.MouseAction += OnMouseClicked;
    }

    float wait_run_ratio = 0;

    // enum으로 플레이어의 상태 정의
    public enum PlayerState
    {
        Die,
        Idle,
        Moving,
    }

    void UpdateDie()
    { }

    void UpdateIdle()
    {
        // Animation
        wait_run_ratio = Mathf.Lerp(wait_run_ratio, 0, 10.0f * Time.deltaTime);
        Animator anim = GetComponent<Animator>();
        anim.SetFloat("wait_run_ratio", wait_run_ratio);
        anim.Play("WAIT_RUN");
    }

    void UpdateMoving()
    {
				// 플레이어 이동과 관련된 코드
        Vector3 dir = _destPos - transform.position;
        if (dir.magnitude < 0.0001f)
        {
            _state = PlayerState.Idle;
        }
        else
        {
            float moveDist = Mathf.Clamp(_speed * Time.deltaTime, 0, dir.magnitude);

            transform.position += dir.normalized * moveDist;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 0.2f);
        }

        // Animation
        wait_run_ratio = Mathf.Lerp(wait_run_ratio, 1, 10.0f * Time.deltaTime);
        Animator anim = GetComponent<Animator>();
        anim.SetFloat("wait_run_ratio", wait_run_ratio);
        anim.Play("WAIT_RUN");
    }

    // _state 변수
    PlayerState _state = PlayerState.Idle;

    void Update()
    {
        // switch문으로 플레이어 상태에 따라 분기
        switch (_state)
        {
            case PlayerState.Die:
                UpdateDie();
                break;
            case PlayerState.Idle:
                UpdateIdle();
                break;
            case PlayerState.Moving:
                UpdateMoving();
                break;
        }
    }

    // OnMouseClicked() 같은 경우에는 옵저버 패턴으로 이벤트를 콜백받고 있기 때문에 Update~() 류의 함수 내에서 처리하지 못하므로 예외적으로 처리
    void OnMouseClicked(Define.MouseEvent evt)
    {
        // 플레이어가 죽은 채로 함수가 호출되었다면 그대로 함수 종료
        if (_state == PlayerState.Die)
            return;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(Camera.main.transform.position, ray.direction * 100.0f, Color.red, 1.0f);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100.0f, LayerMask.GetMask("Wall")))
        {
            _destPos = hit.point;
            // _moveToDes = true; 상태로 대체
            _state = PlayerState.Moving;
            
        }
    }
}
