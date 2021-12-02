using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coletavel : MonoBehaviour
{
    public GameObject objeto;
    public int speed;
    void Start()
    {
        InvokeRepeating("Rodaroda", 2.0f, 0.3f);
    }

    void Rodaroda()
    {
        objeto.transform.Rotate(0, 0, speed);
    }
}
