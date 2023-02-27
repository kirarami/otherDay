using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorCTRL1 : MonoBehaviour
{
    public bool state;
    public bool enter;
    public Sprite spr1;
    public Sprite spr2;
    public player a02;
    public string llaveOpen;
    public controlSCTPPL a10;
    public int IDDoor;
    public bool quitDoor;
    //public string IDDoorAllGame;
    //lugar donde llevara
    public int locate;
    public int inici0;
    public bool hacept0;
    public bool needLlave;
    public bool cerradoD;

    // Start is called before the first frame update
    void Start()
    {
        a02 = GameObject.FindGameObjectWithTag("player").GetComponent<player>();
        a10 = GameObject.FindGameObjectWithTag("CTRLsalas").GetComponent<controlSCTPPL>();
        inici0 = 0;
        cerradoD = false;
        //hacept0 = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (quitDoor == true)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = spr2;
            if (enter == true && FindObjectOfType<player>().GetComponent<player>().B222 == true)
            {
                //cambiar que te lleve a otra sala con un mensaje final dependiendo de como ocurrio esto y en que caso(hacer un objeto indestructible)
                Debug.Log("juego terminado");
                Application.Quit();
            }
        }
        else
        {
            if (state == false)
            {
                //cambiar sprite
                //cerrado
                this.gameObject.GetComponent<SpriteRenderer>().sprite = spr1;
            }
            else
            {
                //abierto
                this.gameObject.GetComponent<SpriteRenderer>().sprite = spr2;

            }

            if (enter == true && state == false && FindObjectOfType<player>().GetComponent<player>().B222 == true && hacept0 == false && needLlave == true)
            {
                //en donde esta llaves hay que crear una variable para ponerla ahi y que se escoja desde afuera
                if (!cerradoD)
                {
                    if (a02.llave == llaveOpen)
                    {
                        Debug.Log("puerta principal abierta");
                        a02.llave = "noone";
                        state = true;
                        StartCoroutine(USEhacep0());
                        needLlave = false;
                        FindObjectOfType<player>().GetComponent<player>().B222use = false;
                    }
                    else
                    {
                        FindObjectOfType<player>().GetComponent<player>().interectiveAllGame = true;
                        FindObjectOfType<player>().GetComponent<player>().IDlocal = "closeDoor";
                        FindObjectOfType<player>().GetComponent<player>().B222use = false;
                    }
                }
                else
                {
                    FindObjectOfType<player>().GetComponent<player>().interectiveAllGame = true;
                    FindObjectOfType<player>().GetComponent<player>().IDlocal = "busca algo para romper la madera";
                    FindObjectOfType<player>().GetComponent<player>().B222use = false;
                }

            } 

            if (enter == true && state == true && FindObjectOfType<player>().GetComponent<player>().B222 == true && hacept0 == true && needLlave == false)
            {
                if (cerradoD == false)
                {
                    Debug.Log("Rsalas en proceso");
                    //poner el locate! que es a donde quieres ir  y el id de la puerta donde saldras
                    a10.Rsalas(locate, IDDoor);
                    inici0 = 0;
                    enter = false;
                    //FindObjectOfType<player>().GetComponent<player>().B222 = false;
                }
                else
                {
                    FindObjectOfType<player>().GetComponent<player>().interectiveAllGame = true;
                    FindObjectOfType<player>().GetComponent<player>().IDlocal = "busca algo para romper la madera";
                    FindObjectOfType<player>().GetComponent<player>().B222use = false;
                }
            }
            //else if (enter == true && state == true && FindObjectOfType<player>().GetComponent<player>().B222 == true && hacept0 == true && needLlave == false)
        }
    }
    private IEnumerator USEhacep0()
    {
        Debug.Log("procesando USEhacep0");
        yield return new WaitForSecondsRealtime(1f);
        hacept0 = true;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("madDoorT"))
        {
            cerradoD = true;
        }

        if (collision.gameObject.CompareTag("player"))
        {
            enter = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            enter = false;
        }

        if (collision.gameObject.CompareTag("madDoorT"))
        {
            cerradoD = false;
        }
    }
}
