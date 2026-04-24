using UnityEngine;

[RequireComponent(typeof(Painting))]
public class PaintingInteractable : MonoBehaviour
{
    private GalleryUI galleryUI;
    private Painting painting;

    void Start()
    {
        painting = GetComponent<Painting>();
        galleryUI = FindFirstObjectByType<GalleryUI>();
    }

    public void Selecionar()
    {
        galleryUI?.MostrarInfo(painting);
    }
}