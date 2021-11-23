using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RatinhoJogador : MonoBehaviour
{
    private CharacterController controle;
    public GameObject escudo;
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
    public int mask = 0;
    public int Mask
    {
        get
        {
            return mask;
        }
        set
        {
            Mask = value;
        }
    }
    bool cheat1 = false;
    bool cheat2 = false;

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
    void Mascara()
    {
        if(Mask > 0)
        {
            escudo.SetActive(true);
        }
        else
        {
            escudo.SetActive(false);
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
            if(Mask == 1)
            {
                Mask--;
            }
            else if(cheat2 == false)
            {
                Vida--;
            }
            Destroy(outro.gameObject);
        }
        if (outro.gameObject.CompareTag("Chegada"))
        {
            SceneManager.LoadScene("ParaBens");
        }
        if (outro.gameObject.CompareTag("Death"))
        {
            Vida-=3;
            Destroy(outro.gameObject);
        }
        if (outro.gameObject.CompareTag("Queijo"))
        {
            if (Vida < 3)
            {
                Vida++;
            }
            Destroy(outro.gameObject);
        }
        if (outro.gameObject.CompareTag("Mascara"))
        {
            if (Mask < 1)
            {
                Mask++;
            }
            Destroy(outro.gameObject);
        }
    }
    void CheatCodes()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            if(cheat1 == false)
            {
                cheat1 = true;
            }
            else
            {
                cheat1 = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            if (cheat1 == false)
            {
                cheat1 = true;
            }
            else
            {
                cheat1 = false;
            }
        }
    }
        
}
