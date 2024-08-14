using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour, IInteractable
{
    public Light m_Light;
    public bool isOn;

    void Start()
    {
        m_Light.enabled = isOn;
    }

    public string GetDescription()
    {
        if (isOn) return "Press [E] to <color=red>close</color> the door.";
        // return "Press [E] to turn <color=green>on</color> the light.";
        return "";
    }

    public void Interact()
    {
        isOn = !isOn;
        m_Light.enabled = isOn;
    }
}
