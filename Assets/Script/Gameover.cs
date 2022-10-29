using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gameover : MonoBehaviour
{
    public Text points;
    public void Setup(int score)
    {
        gameObject.SetActive(true);
        points.text = "Poin Acquired: " + score.ToString();
    }

    public void Respawn()
    {
        SceneManager.LoadScene("SampleScene 1");
    }

    public void GoMenu()
    {
        SceneManager.LoadScene("Main Menu 1");
    }
}
