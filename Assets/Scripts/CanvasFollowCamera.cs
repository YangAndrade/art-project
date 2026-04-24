using UnityEngine;

public class CanvasFollowCamera : MonoBehaviour
{
    [Header("Distância do painel à frente da câmera")]
    public float distancia = 2f;
    public float alturaOffset = 0f;

    private Transform camTransform;

    void Start()
    {
        var centerEye = GameObject.Find("CenterEyeAnchor");
        if (centerEye != null)
            camTransform = centerEye.transform;
        else
            camTransform = Camera.main.transform;
    }

    void OnEnable()
    {
        if (camTransform == null) return;

        transform.position = camTransform.position
                           + camTransform.forward * distancia
                           + Vector3.up * alturaOffset;

        transform.LookAt(camTransform);
        transform.Rotate(0, 180, 0);
    }
}