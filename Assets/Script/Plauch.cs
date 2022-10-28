using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class Plauch : MonoBehaviour
{
    public GameObject projectilePrefabs;
    public Transform lauchPoint;
    Animator anim;

    public float shootTime;
    public float shootCounter;
    // Start is called before the first frame update
    void Start()
    {
        shootCounter = shootTime;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1") && shootCounter <= 0)
        {
            anim.SetBool("tembak", true);
            StartCoroutine(WaitShoot());
            shootCounter = shootTime;
        }
        shootCounter -= Time.deltaTime;

        if (Input.GetButtonUp("Fire1"))
        {
            anim.SetBool("tembak", false);
        }
    }

    IEnumerator WaitShoot()
    {
        // menuggu sebenter baru menembak
        yield return new WaitForSeconds(0.2f);
        Instantiate(projectilePrefabs, lauchPoint.position, lauchPoint.rotation);
    }
}
