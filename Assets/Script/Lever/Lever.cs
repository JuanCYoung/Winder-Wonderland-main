using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Lever : MonoBehaviour
{
    public bool isInRange;
    public KeyCode interactKey;
    public UnityEvent interactionAction;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isInRange){
            if(Input.GetKeyDown(interactKey))
            {
                interactionAction.Invoke();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")){
            isInRange = true;
            Debug.Log("PLayer in range");
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")){
            isInRange = false;
            Debug.Log("PLayer outside range");
        }
    }
}
