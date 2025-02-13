using UnityEngine;
using TMPro;
using System;
using UnityEngine.Rendering;

public class CharacterMove : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody rb;

    //private GameObject titleText;
    //private GameObject goalText;
    //private GameObject descriptionText;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical) * speed;
        rb.linearVelocity = new Vector3(movement.x, rb.linearVelocity.y, movement.z);
    }
}
