using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Avalanche : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float forwardMovementSpeed = 3.0f;
    public Rigidbody2D rb;
    Vector2 movement;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
    }    
    void FixedUpdate()
    {
      rb.MovePosition(rb.position +  new Vector2(forwardMovementSpeed * Time.fixedDeltaTime, movement.y * moveSpeed * Time.fixedDeltaTime));
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Terrain")
        {
            Destroy(other.gameObject);
        }
    }
}
