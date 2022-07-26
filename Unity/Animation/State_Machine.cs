void UpdateIdle()
    {
        // Animation
        Animator anim = GetComponent<Animator>();
        // 현재 게임 상태에 대한 정보를 파라미터에 넘겨준다
        anim.SetFloat("speed", 0);
    }

    void UpdateMoving()
    {
				// 이동과 관련된 코드
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
        Animator anim = GetComponent<Animator>();
        // 현재 게임 상태에 대한 정보를 파라미터에 넘겨준다
        anim.SetFloat("speed", _speed);
    }
