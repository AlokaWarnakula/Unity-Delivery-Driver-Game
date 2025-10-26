using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    void Start()
    {
        GameObject thingsToFollow = GameObject.FindGameObjectWithTag("Player");

    }
    [SerializeField] GameObject thingsToFollow;

    void LateUpdate()
    {
        transform.position = thingsToFollow.transform.position + new Vector3(0,0,-30);
        
    }
}
