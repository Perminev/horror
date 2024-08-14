using System;
using UnityEngine;
using System.Threading;
using TMPro;

public class LeftGrabManager : MonoBehaviour
{
    public float interactDistance = 3.0f; // Дистанция взаимодействия
    public GameObject keyPoint;
    public LayerMask maskey;
    private Camera camera;
    [SerializeField] public Animator anim;
    [SerializeField] TMP_Text Key_hint;
    public bool isKey;
    

    // Start is called before the first frame update
    private void Start()
    {
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, interactDistance, maskey))
        {
            // Проверяем, попали ли в key
            Key key = hit.collider.GetComponent<Key>();
            if (key != null && !key.keygrabActive)
            {
                Key_hint.text = "Press [E] to pickup key";
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Key_hint.text = "";
                    anim.Play("Picking Up");
                    key.transform.parent = keyPoint.transform;
                    key.transform.localPosition = Vector3.zero;
                    key.transform.localEulerAngles = Vector3.zero;
                    key.keygrabActive = true;
                    isKey = true;
                    Debug.Log("GrabKey");
                }
            }
        }

    }
}
