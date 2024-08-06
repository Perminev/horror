// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using TMPro;
//
// public class KeyInter : MonoBehaviour
// {
//     public Camera mainCam;
//     public float interactionDistance = 10f;
//
//     public GameObject interactionUI;
//     public TextMeshProUGUI interactionText;
//     public bool isKey;
//
//
//     void Update()
//     {
//         InteractionRay();
//         if (Input.GetKeyDown(KeyCode.A))
//         {
//             isKey = true;
//         }
//     }
//
//     void InteractionRay()
//     {
//         Ray ray = mainCam.ViewportPointToRay(Vector3.one / 2f);
//         RaycastHit hit;
//
//         bool hitSomething = false;
//
//         if (Physics.Raycast(ray, out hit, interactionDistance))
//         {
//             IInteractable interactable = hit.collider.GetComponent<IInteractable>();
//
//             if (interactable != null)
//             {
//                 hitSomething = true;
//                 interactionText.text = interactable.GetDescription();
//
//                 if (Input.GetKeyDown(KeyCode.E) && isKey)
//                 {
//                     interactable.Interact();
//                 }
//             }
//         }
//
//         interactionUI.SetActive(hitSomething);
//     }
// }
