using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float moveSpeed = 2f;
    Rigidbody2D rb;
    Transform myTransform;
    Vector2 moveDirection;
    public Transform target;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myTransform = GetComponent<Transform>();
        target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            moveDirection = direction;
            // float angle = Mathf.Atan2(direction.y,direction.x)*Mathf.Rad2Deg;
            //rb.rotation = angle
        }

        
}
    private void FixedUpdate()
    {
        if (target)
        {
            rb.linearVelocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed;
        }
    }
}
