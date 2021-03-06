using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RatinhoJogador : MonoBehaviour
{
    private CharacterController controle;
    public float speedFrente;
    public float speedLado;
    public float jumpHeight;
    float jumpVelocity;
    public float gravidade;
    public GameObject ratinho;
    RaycastHit hit;
    public int vida = 3;
    public int Vida
    {
        get
        {
            return vida;
        }
        set
        {
            vida = value;
        }
    }

    void Start()
    {
        controle = GetComponent<CharacterController>();
    }

    void Update()
    {
        Movimento();
        Saude();
    }
    void Movimento()
    {
        Vector3 dir = transform.forward * speedFrente;
        if (transform.position.y < 0.5f)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                jumpVelocity = jumpHeight;
            }
        }
        else
        {
            jumpVelocity -= gravidade;
        }
        dir.y = jumpVelocity;
        controle.Move(dir * Time.deltaTime);

        float h = Input.GetAxis("Horizontal");
        Vector3 lado = transform.right * speedLado * h;
        controle.Move(lado * Time.deltaTime);

    }
    void Saude()
    {
        if(Vida <= 0)
        {
            SceneManager.LoadScene("FimDeJogo");
        }
    } 
    void OnTriggerEnter(Collider outro)
    {
        if (outro.gameObject.CompareTag("Rotation"))
        {
            float grau = outro.gameObject.GetComponent<Colisor>().rotacao;
            transform.rotation = Quaternion.Euler(0, grau, 0);
        }
        if (outro.gameObject.CompareTag("Veneno"))
        {
            Vida--;
            Destroy(outro.gameObject);
        }
        if (outro.gameObject.CompareTag("Chegada"))
        {
            SceneManager.LoadScene("ParaBens");
        }
    }
        
}
