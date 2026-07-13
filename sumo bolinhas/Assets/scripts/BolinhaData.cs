using UnityEngine;

[CreateAssetMenu(fileName = "BolinhaData", menuName = "Bolinhas/Bolinha")]
public class BolinhaData : ScriptableObject
{
    public string nome;

    public GameObject prefab;
    public Sprite sprite;

    public Material material;          
public Material materialAlternativo; 

    public float tamanho = 1f;
    public float velocidade = 5f;
    public float forcaEmpurrao = 10f;
}