using UnityEngine;

public class TestCollision : MonoBehaviour
{
		void Start()
    { }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);            

            Debug.DrawRay(Camera.main.transform.position, ray.direction * 100.0f, Color.red, 1.0f);

            // layerMask는 int32를 사용한다
            // n번 layer를 켜주고 싶다 => n번째 비트를 켜준다 (비트연산자 사용)
            int mask = (1 << 8); // 1을 킨 다음 왼쪽으로 8번 비트쉬프트

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100.0f, mask ))
            {
                Debug.Log($"Raycast camera @ {hit.collider.gameObject.name}");
            }
        }
    }
}
