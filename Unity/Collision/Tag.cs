using UnityEngine;
using System.Collections;

public class Example : MonoBehaviour 
{
    public GameObject respawnPrefab;
    public GameObject respawn;

    void Start() 
		{
        if (respawn == null)
            respawn = GameObject.FindWithTag("Respawn");

        Instantiate(respawnPrefab, respawn.transform.position, respawn.transform.rotation) as GameObject;
    }
}
