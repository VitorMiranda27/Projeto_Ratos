using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BotoesCenas : MonoBehaviour
{
    public void MenuButao()
    {
        SceneManager.LoadScene("Menu");
    }
    public void JogarFase1()
    {
        SceneManager.LoadScene("Fase1");
    }

    public void JogarFase2()
    {
        SceneManager.LoadScene("Fase2");
    }
    public void Sair()
    {
        Application.Quit();
    }
}
