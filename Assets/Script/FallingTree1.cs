using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingTree1 : MonoBehaviour
{
    private Rigidbody2D treeRb;
    public float dropforce = 5;

    void Start()
    {
        treeRb = GetComponent<Rigidbody2D>();
        treeRb.AddForce(Vector2.left * dropforce, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
