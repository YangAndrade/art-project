using UnityEngine;

public class SimulatorInput : MonoBehaviour
{
    private Camera cam;
    private GalleryUI galleryUI;

    void Start()
    {
        cam = Camera.main;
        galleryUI = FindFirstObjectByType<GalleryUI>();
    }

    void Update()
    {
        bool triggerPressed = OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) ||
                              OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger);

        if (triggerPressed)
        {
            if (galleryUI.PainelAberto())
            {
                galleryUI.Fechar();
                return;
            }

            Ray ray = new Ray(cam.transform.position, cam.transform.forward);

            if (Physics.Raycast(ray, out RaycastHit hit, 10f))
            {
                var painting = hit.collider.GetComponent<PaintingInteractable>();
                if (painting != null)
                    painting.Selecionar();
            }
        }
    }
}