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
    float escalatempo;
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
            mask = value;
        }
    }
    bool cheat1 = false;
    bool cheat2 = false;
    float pastgrau = 0;
    float grau2 = 0;
    float grau1 = 0;

    void Start()
    {
        controle = GetComponent<CharacterController>();
        escalatempo = Time.timeScale;
    }

    void Update()
    {
        Movimento();
        Saude();
        Mascara();
        CheatCodes();
        Stop();
    }
    void Movimento()
    {
        Vector3 dir = transform.forward * speedFrente;
        if (controle.isGrounded)
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
            if(pastgrau != grau)
            {
                if(pastgrau < grau)
                {
                    grau1 = (grau - pastgrau) * 0.3f;
                    grau2 = (grau - pastgrau) * 0.6f;
                }
                else
                {
                    grau1 = (pastgrau - grau) * 0.3f;
                    grau2 = (pastgrau - grau) * 0.6f;
                }
            }
            transform.rotation = Quaternion.Euler(0, grau1, 0);
            transform.rotation = Quaternion.Euler(0, grau2, 0);
            transform.rotation = Quaternion.Euler(0, grau, 0);
            pastgrau = grau;
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
            if (cheat2 == false)
            {
                cheat2 = true;
            }
            else
            {
                cheat2 = false;
            }
        }
    }
    public void Stop()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if(Time.timeScale != 0)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = escalatempo;
            }
        }
    }
        
}
