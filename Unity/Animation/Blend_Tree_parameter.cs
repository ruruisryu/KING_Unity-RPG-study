// SetFloat에 입력할 wait_run_ratio 값에 lerp를 주기 위해 별도의 float형 변수 생성
    float wait_run_ratio = 0;

    void Update()
    {
        if (_moveToDes)
        {
            Vector3 dir = _destPos - transform.position;
            if (dir.magnitude < 0.0001f)
            {
                _moveToDes = false;
            }
            else
            {
                float moveDist = Mathf.Clamp(_speed * Time.deltaTime, 0, dir.magnitude);

                transform.position += dir.normalized * moveDist;
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 0.2f);
            }
        }

        if (_moveToDes)
        {
            // wait_run_ratio 변수에 Lerp 주기
            // 움직이고 있을 때는 RUN 즉 1의 비율이 높아져야한다
            wait_run_ratio = Mathf.Lerp(wait_run_ratio, 1, 10.0f * Time.deltaTime);

            Animator anim = GetComponent<Animator>();
            // anim.SetFloat : Set계열 함수를 이용해 파라미터의 값을 조절한다. 파라미터 이름과 블렌딩 값을 넣어준다
            anim.SetFloat("wait_run_ratio", wait_run_ratio);
            // WAIT과 RUN이 아닌 WAIT_RUN 사용
            anim.Play("WAIT_RUN");
        }
        else
        {
            // 멈출 때는 WAIT 즉 0의 비율이 높아져야한다
            wait_run_ratio = Mathf.Lerp(wait_run_ratio, 0, 10.0f * Time.deltaTime);
            Animator anim = GetComponent<Animator>();
            anim.SetFloat("wait_run_ratio", wait_run_ratio);
            anim.Play("WAIT_RUN");
        }
    }
