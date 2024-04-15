using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player; 

    public void Update()
    {
        player = GameObject.Find("Player");
        transform.position = player.transform.position + new Vector3(0, 1, -10);
    }
}
