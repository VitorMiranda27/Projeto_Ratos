/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peca : MonoBehaviour
{
    public Transform conector;
    public GameObject[] listaColetaveis;

    private void OnEnable()
    {
        for(int i = 0; i < listaColetaveis.Length; i++)
        {
            listaColetaveis[i].SetActive(true);
        }
    }
    private void OnDisable()
    {
        GeraPista.geraPista.PoolPecas.Add(this);
    }
}*/