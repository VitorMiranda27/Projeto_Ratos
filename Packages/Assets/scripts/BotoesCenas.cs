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
    public void JogarBotao()
    {
        SceneManager.LoadScene("Fase1");
    }
}
