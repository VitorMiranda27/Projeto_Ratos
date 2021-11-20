using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BotoesCenas : MonoBehaviour
{
    public void CarregaCena(string nomeCena)
    {
        SceneManager.LoadScene(nomeCena);
    }
    public void Sair()
    {
        Application.Quit();
    }
}
