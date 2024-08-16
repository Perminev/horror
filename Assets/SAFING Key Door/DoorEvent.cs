using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorEvent : MonoBehaviour
{
    [SerializeField] Animator DoorAnimator;
    [SerializeField] bool Closed;
    
    public void TryOpen()
    {
        if(!Closed)
        {
            if(DoorAnimator.GetBool("open") == false)
            {
                DoorAnimator.SetBool("open", true);
            }
            else
            {
                DoorAnimator.SetBool("open", false);
            }
        }
    }
    public void Unlock()
    {
        Closed = false;
    }
}