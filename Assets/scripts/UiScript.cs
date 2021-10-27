using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiScript : MonoBehaviour
{
    public Text txtVida;
    public RatinhoJogador jogador;
    void Start()
    {
        jogador = GameObject.Find("Jogador").GetComponent<RatinhoJogador>();
    }
    void Update()
    {
        VidaUI();
    }
    void VidaUI()
    {
        txtVida.text = "Vidas: " + jogador.Vida;
    }
}
