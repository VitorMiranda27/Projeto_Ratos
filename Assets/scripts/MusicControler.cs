using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicControler : MonoBehaviour
{
    GameObject paiValor;
    public Slider sliderMusica;
    ScriptValue filhoValor;
    public AudioSource volmusica;

    void Start()
    {
        paiValor = GameObject.FindWithTag("ValorS");
        filhoValor = paiValor.GetComponent<ScriptValue>();
        volmusica.volume = filhoValor.VolumeMusica;
    }
    public void SliderMusica()
    {
        filhoValor.VolumeMusica = sliderMusica.value;
        volmusica.volume = sliderMusica.value;
    }
}
