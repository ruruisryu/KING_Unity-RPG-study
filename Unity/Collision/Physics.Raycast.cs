using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCollision : MonoBehaviour
{
   void Start()
    { }

    void Update()
    {
        Vector3 look = transform.TransformDirection(Vector3.forward);

        // Debug를 이용해 Ray 쏘기
        Debug.DrawRay(transform.position + Vector3.up, look * 10, Color.red);
        
        // Physics를 이용해 Ray 쏘기
        RaycastHit hit;
        if (Physics.Raycast(transform.position + Vector3.up, look, out hit, 10))
        {
            Debug.Log($"Raycast! {hit.collider.gameObject.name} ");
        }
    }
}
