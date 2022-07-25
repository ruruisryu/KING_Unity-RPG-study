using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCollision : MonoBehaviour
{
    void Start()
    { }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
						/*
						Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
            Vector3 dir = mousePos - Camera.main.transform.position;
            dir = dir.normalized; */ 
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
           
						// Debug.DrawRay(Camera.main.transform.position, dir * 100.0f, Color.red, 1.0f);
						// dir => ray.direction
            Debug.DrawRay(Camera.main.transform.position, ray.direction * 100.0f, Color.red, 1.0f);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                Debug.Log($"Raycast camera @ {hit.collider.gameObject.name}");
            }
        }
    }
}
