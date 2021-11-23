using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BotoesCenas : MonoBehaviour
{
    public GameObject Tela1;
    public GameObject Tela2;
    public void CarregaCena(string nomeCena)
    {
        SceneManager.LoadScene(nomeCena);
    }
    public void Sair()
    {
        Application.Quit();
    }
    public void TrocarDeTela1()
    {
        Tela1.SetActive(true);
        Tela2.SetActive(false);
    }
    public void TrocarDeTela2()
    {
        Tela1.SetActive(false);
        Tela2.SetActive(true);
    }
}
