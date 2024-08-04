using System;
using UnityEngine;
using System.Threading;
using TMPro;

public class GrabManager : MonoBehaviour
{
    public float interactDistance = 3.0f; // Дистанция взаимодействия
    public GameObject lightPoint;
    public LayerMask mask;
    private Camera camera;
    [SerializeField] public Animator anim;
    [SerializeField] TMP_Text Flashlight_hint;

    private void Start()
    {
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        // Стреляем рейкастом из камеры

        RaycastHit hit;
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, interactDistance, mask))
        {
            // Проверяем, попали ли в фонарик
            FlashlightToggle flashlight = hit.collider.GetComponent<FlashlightToggle>();
            if (flashlight != null && !flashlight.grabActive)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Flashlight_hint.text = "";
                    anim.Play("Picking Up");
                    flashlight.transform.parent = lightPoint.transform;
                    flashlight.transform.localPosition = Vector3.zero;
                    flashlight.transform.localEulerAngles = Vector3.zero;
                    flashlight.grabActive = true;
                    Debug.Log("GrabLight");
                }
            }
        }
    }
}