using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelSystem : MonoBehaviour
{   
    private Rigidbody2D treeRb;
    public float dropforce = 5;

    public bool dropNo ;
    public UnityEvent interactionAction;
    
    public void ItsFalling(){
        treeRb = GetComponent<Rigidbody2D>();
        treeRb.AddForce(Vector2.down * dropforce, ForceMode2D.Impulse);
        treeRb.gravityScale = 1;  
    }

    public void makeTrue(){
        dropNo = true;
    }

    private void Update() {
        if(dropNo){
            ItsFalling();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Penahan"))
        {
            treeRb.bodyType = RigidbodyType2D.Static;
        }
    }

    
}
