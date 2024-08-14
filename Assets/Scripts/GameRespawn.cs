using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRespawn : MonoBehaviour
{

    public float treshold;

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
            StartCoroutine(Timer());
            FirstPersonController player = other.GetComponent<FirstPersonController>();
            player.transform.position = new Vector3(609.6321f, 1, 107.0098f);
        
    }
    
    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(5);
    }
}
