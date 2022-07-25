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

            LayerMask mask = LayerMask.GetMask("Monster");

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100.0f, mask ))
            {
                Debug.Log($"Raycast camera @ {hit.collider.gameObject.name}");
            }
        }
    }
}
