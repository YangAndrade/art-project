using UnityEngine;
using UnityEngine.InputSystem;

public class PaintingClick : MonoBehaviour
{
    [SerializeField] private GalleryUI galleryUI;
    [SerializeField] private Transform rightHandAnchor;
    private Camera cam;

    void Start() => cam = Camera.main;

    void Update()
    {
        bool trigger = OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger)
                    || OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger)
                    || Mouse.current.leftButton.wasPressedThisFrame;

        if (trigger)
        {
            Ray ray = cam != null
                ? cam.ScreenPointToRay(Mouse.current.position.ReadValue())
                : new Ray(rightHandAnchor.position, rightHandAnchor.forward);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Painting p = hit.collider.GetComponent<Painting>();
                if (p != null)
                    galleryUI.MostrarInfo(p);
            }
        }
    }
}