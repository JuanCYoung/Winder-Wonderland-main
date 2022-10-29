using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem : MonoBehaviour
{   
    private Rigidbody2D treeRb;
    public float dropforce = 5;

    void Start()
    {
        treeRb = GetComponent<Rigidbody2D>();
        treeRb.AddForce(Vector2.down * dropforce, ForceMode2D.Impulse);
        treeRb.gravityScale = 1;        
    }

    public void ItsFalling(){
        treeRb = GetComponent<Rigidbody2D>();
        treeRb.AddForce(Vector2.down * dropforce, ForceMode2D.Impulse);
        treeRb.gravityScale = 1;  
    }

    private void Update() {
        
    }

    
}
