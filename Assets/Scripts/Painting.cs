using UnityEngine;

public class Painting : MonoBehaviour
{
    [Header("Informações do Quadro")]
    public string titulo;
    public string artista;

    [TextArea(3, 6)]
    public string descricao;
}