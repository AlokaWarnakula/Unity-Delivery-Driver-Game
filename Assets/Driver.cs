using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steeringSpeed = 150.0f;
    [SerializeField] float moveSpeed = 10.0f;

    [SerializeField] float slowSpeed = 5.0f;
    [SerializeField] float boostSpeed = 30.0f;


    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steeringSpeed * Time.deltaTime;
        float moveSpeedAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount); // rotate object
        transform.Translate(0, moveSpeedAmount, 0); // Moving forward
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Boost"))
        {
            moveSpeed = boostSpeed;
            Debug.Log("You are boosting man");
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        moveSpeed = slowSpeed;
    }

}
