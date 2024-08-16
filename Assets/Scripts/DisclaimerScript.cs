using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Disclaimer : MonoBehaviour
{
    void Start()
    {
        Invoke("Transition", 11);
    }

    private void Transition()
    {
        SceneManager.LoadScene("Scenes/Menu");
    }
}