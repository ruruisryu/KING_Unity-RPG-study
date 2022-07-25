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

        RaycastHit[] hits;
        hits = Physics.RaycastAll(transform.position+Vector3.up, look, 10);

        foreach (RaycastHit hit in hits)
        {
            Debug.Log($"RaycastAll {hit.collider.gameObject.name}");
        }
    }
}
