using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load : MonoBehaviour
{
    public int iLevelToLoad;
    public string sLevelLoad;

    public bool UseIntegerToLoadLevel;
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;

        if (collisionGameObject.name == "Player")
        {
            StartCoroutine(waitscene());
            Scene();
        }
    }

    private void Scene()
    {
        if (UseIntegerToLoadLevel)
        {
            SceneManager.LoadScene(iLevelToLoad);
        }
        else
        {
            SceneManager.LoadScene(sLevelLoad);
        }
    }

    IEnumerator waitscene()
    {
        yield return new WaitForSeconds(3f);
    }
}
