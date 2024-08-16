using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PegiManager : MonoBehaviour
{
    void Start()
    {
        Invoke("Transition", 8);
    }

    private void Transition()
    {
        SceneManager.LoadScene("Disclaimer");
    }
}