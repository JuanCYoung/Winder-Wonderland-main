using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeHealth : MonoBehaviour
{
    public float health;
    public float maxHealth = 3f;

    public GameObject treeDrop;

    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int amount)
    {
        health -=amount;
        if(health <= 0)
        {
            Destroy(gameObject);
            TreeDrop();
        }
    }

    private void TreeDrop()
    {
        Instantiate(treeDrop,transform.position + new Vector3(2, 0,0),Quaternion.identity);
    }
}
