using UnityEngine;
using TMPro;

public class GalleryUI : MonoBehaviour
{
    [SerializeField] private GameObject painel;
    [SerializeField] private TextMeshProUGUI txtTitulo;
    [SerializeField] private TextMeshProUGUI txtArtista;
    [SerializeField] private TextMeshProUGUI txtDescricao;

    void Start()
    {
        painel.SetActive(false);
    }

    public bool PainelAberto() => painel.activeSelf;

    public void MostrarInfo(Painting p)
    {
        txtTitulo.text = p.titulo;
        txtArtista.text = p.artista;
        txtDescricao.text = p.descricao;
        painel.SetActive(true);
    }

    public void Fechar()
    {
        painel.SetActive(false);
    }
}