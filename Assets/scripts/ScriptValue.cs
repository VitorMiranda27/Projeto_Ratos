using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptValue : MonoBehaviour
{
    public static ScriptValue instancia;
    public float volMusica = 0.5f;
    public float volSFX = 0.5f;
    void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
    public float VolumeMusica
    {

        get
        {
            return volMusica;
        }
        set
        {
            if (value > 1)
            {
                volMusica = 1;
            }
            else if (value < 0)
            {
                volMusica = 0;
            }
            else
            {
                volMusica = value;
            }
        }
    }
    public float VolumeSFX
    {
        get
        {
            return volSFX;
        }
        set
        {
            if (value > 1)
            {
                volSFX = 1;
            }
            else if (value < 0)
            {
                volSFX = 0;
            }
            else
            {
                volSFX = value;
            }
        }
    }
}
