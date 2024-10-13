using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalValue;
    private float verticalValue;
    private Transform orientation;
    Vector2 moveDirection;
    //private PrinceanWorld princeanWorldScript;

    //[SerializeField] private GameObject planet;

    [SerializeField] private float moveSpeed = 1;
    Rigidbody2D rb;
    void Start()
    {
        //princeanWorldScript = planet.GetComponent<PrinceanWorld>();
        rb = GetComponent<Rigidbody2D>();
        orientation = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalValue = Input.GetAxisRaw("Horizontal");
        verticalValue = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        moveDirection = orientation.right.normalized * horizontalValue;
        rb.AddForce(moveDirection * moveSpeed);
    }
}
