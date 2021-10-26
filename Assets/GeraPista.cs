using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeraPista : MonoBehaviour
{
    public GameObject pista;
    void Start()
    {
        Instantiate(pista, new Vector3(0, 0, 0), this.transform.rotation);
    }

}
