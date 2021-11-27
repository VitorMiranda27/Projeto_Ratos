using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControler : MonoBehaviour
{
    public GameObject paiValor;
    ScriptValue valores;

    void Start()
    {
        if(paiValor == null)
        {
            paiValor = GameObject.FindWithTag("Player");
        }
        valores = paiValor.GetComponent<ScriptValue>();
    }

    void Update()
    {
        
    }
}
