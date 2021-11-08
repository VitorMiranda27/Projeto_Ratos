/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeraPista : MonoBehaviour
{
    public int tamanho;
    public Peca[] partes;
    private Peca ultimaCriada;
    public List<Peca> PoolPecas;
    public int tamanhoPool;
    static public GeraPista geraPista;
    
    private void pistaInicial()
    {
        ultimaCriada = Instantiate(partes[0], this.transform);
        int i;
        for (i = 0; i < tamanho; i++)
        {
            MontaPista();
        }
    }

    public void MontaPista()
    {
        int indiceSorteado;
        Peca reaproveitada;
        if (PoolPecas.Count < tamanhoPool)
        {
            ultimaCriada = Instantiate(partes[Random.Range(0, partes.Length)],
                    ultimaCriada.conector.position,
                    ultimaCriada.conector.rotation,
                    this.transform);
        }
        else
        {
            indiceSorteado = Random.Range(0, PoolPecas.Count);
            reaproveitada = PoolPecas[indiceSorteado];
            reaproveitada.gameObject.SetActive(true);
            reaproveitada.transform.position = ultimaCriada.conector.position;
            ultimaCriada = reaproveitada;
            Debug.Log(reaproveitada.gameObject.name);
            PoolPecas.RemoveAt(indiceSorteado);
     
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        pistaInicial();
        geraPista = this;
    }

   
}*/
