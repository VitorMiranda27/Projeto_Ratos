using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RatinhoJogador : MonoBehaviour
{
    public CharacterController controle;
    public Animator anim;
    public GameObject escudo;
    public float speedFrente;
    public float speedLado;
    public float jumpHeight;
    float jumpVelocity;
    public float gravidade;
    public GameObject ratinho;
    RaycastHit hit;
    float escalatempo, tempo;
    private float posToqueIni, posToqueFin;
    public int vida = 3;
    public int Vida
    {

        get
        {
            return vida;
        }
        set
        {
            if (value > 3)
            {
                vida = 3;
            }
            else if (value < 0)
            {
                vida = 0;
            }
            else
            {
                vida = value;
            }
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
            if (value > 3)
            {
                mask = 3;
            }
            else if (value < 0)
            {
                mask = 0;
            }
            else
            {
                mask = value;
            }
        }
    }
    public float h = 0;
    public float H
    {
        get
        {
            return h;
        }
        set
        {
            if (value > 1)
            {
                h = 1;
            }
            else if (value < -1)
            {
                h = -1;
            }
            else
            {
               h = value;
            }
        }
    }
    bool cheat2 = false;
    bool queda = false;
    float pastgrau = 0;
    float grau2 = 0;
    float grau1 = 0;
    float telax = 0;

    void Start()
    {
        escalatempo = Time.timeScale;
        Resolution[] resolutions = Screen.resolutions;
        foreach (var res in resolutions)
        {
            telax = res.height;
        }
    }

    void Update()
    {
#if UNITY_EDITOR
        Movimento1();
        CheatCodes1();
#endif
#if UNITY_ANDROID
        Movimento2();
        CheatCodes2();
#endif
        Saude();
        Mascara();
        Stop();
    }
    void Movimento1()
    {
        Vector3 dir = transform.forward * speedFrente;
        if (controle.isGrounded)
        {
            anim.SetInteger("transition", 1);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                jumpVelocity = jumpHeight;
                anim.SetInteger("transition", 2);
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
    void Movimento2()
    {
        Vector3 dir = transform.forward * speedFrente;
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                posToqueIni = Input.GetTouch(0).position.y;
            }
            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                posToqueFin = Input.GetTouch(0).position.y;
                
                if (controle.isGrounded)
                {
                    anim.SetInteger("transition", 1);
                    if (posToqueFin - posToqueIni > 200)
                    {
                        anim.SetInteger("transition", 2);
                        jumpVelocity = jumpHeight;
                    }
                }
            }
        }
        else
        {
            jumpVelocity -= gravidade;
        }
        dir.y = jumpVelocity;
        controle.Move(dir * Time.deltaTime);

        if(Input.GetTouch(0).position.x < telax / 2.0f)
        {
            H -= 0.1f;
        }
        else if(Input.GetTouch(0).position.x >= telax / 2.0f)
        {
            H += 0.1f;
        }

        Vector3 lado = transform.right * speedLado * H;
        controle.Move(lado * Time.deltaTime);

    }
    void Saude()
    {
        if(Vida <= 0)
        {
            anim.SetInteger("transition", 3);
            speedFrente = 0;
            
            tempo += Time.deltaTime;

            if (tempo > 2) 
            {
                SceneManager.LoadScene("FimDeJogo"); 
            }

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
            Vida++;
            Destroy(outro.gameObject);
        }
        if (outro.gameObject.CompareTag("Mascara"))
        {
            Mask++;
            Destroy(outro.gameObject);
        }
    }
    void CheatCodes1()
    {
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
    void CheatCodes2()
    {
        if (Input.touchCount == 5)
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
