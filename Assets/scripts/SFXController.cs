using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SFXController : MonoBehaviour
{
    GameObject paiValor;
    public Slider sliderSFX;
    ScriptValue filhoValor;
    public AudioSource AudioSFX;
    public AudioClip sfx_pulo, sfx_dano, sfx_comendo, sfx_escudoativo, sfx_clique;

    void Start()
    {
        paiValor = GameObject.FindWithTag("ValorS");
        filhoValor = paiValor.GetComponent<ScriptValue>();
        AudioSFX.volume = filhoValor.VolumeSFX;

    }
    public void SliderSFX()
    {
        filhoValor.VolumeSFX = sliderSFX.value;
        AudioSFX.volume = sliderSFX.value;

    }
    public void SoundPulo()
    {
        AudioSFX.PlayOneShot(sfx_pulo, 1.0f);
    }
    public void SoundDano()
    {
        AudioSFX.PlayOneShot(sfx_dano, 1.0f);
    }
    public void SoundComendo()
    {
        AudioSFX.PlayOneShot(sfx_comendo, 1.0f);
    }
    public void SoundEscudoAtivo()
    {
        AudioSFX.PlayOneShot(sfx_escudoativo, 1.0f);
    }
    public void SoundClique()
    {
        AudioSFX.PlayOneShot(sfx_clique, 1.0f);
    }
}
