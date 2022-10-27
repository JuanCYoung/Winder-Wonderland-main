using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plauch : MonoBehaviour
{
    public GameObject projectilePrefabs;
    public Transform lauchPoint;

    public float shootTime;
    public float shootCounter;
    // Start is called before the first frame update
    void Start()
    {
        shootCounter = shootTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1") && shootCounter <= 0)
        {
            Instantiate (projectilePrefabs, lauchPoint.position, Quaternion.identity);
            shootCounter = shootTime;
        }
        shootCounter -= Time.deltaTime;
    }
}
