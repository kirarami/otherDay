using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cupboardACTION : MonoBehaviour
{
    public bool state;
    public bool enter;
    public Sprite spr1;
    public Sprite spr2;
    public player a02;
    //public string llaveOpen;
    //public controlSCTPPL a10;
    //public int IDDoor;
    //lugar donde llevara
    //public int locate;
    //public int inici0;
    public bool dentro;
    //public bool needLlave;
    // Start is called before the first frame update
    void Start()
    {
        dentro = false;
        a02 = GameObject.FindGameObjectWithTag("player").GetComponent<player>();
        //a10 = GameObject.FindGameObjectWithTag("CTRLsalas").GetComponent<controlSCTPPL>();
    }

    // Update is called once per frame
    void Update()
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

        if (enter == true && state == true && FindObjectOfType<player>().GetComponent<player>().B222 == true && dentro == false)
        {
            //en donde esta llaves hay que crear una variable para ponerla ahi y que se escoja desde afuera
            if (dentro == false)
            {
                Debug.Log("oculto");
                state = false;
                a02.gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1,0);
                FindObjectOfType<player>().GetComponent<player>().B222use = false;
                FindObjectOfType<player>().GetComponent<player>().B222 = false;
                FindObjectOfType<player>().GetComponent<player>().onT = true;
                dentro = true;
            }

        }
        if (enter == true && state == false && FindObjectOfType<player>().GetComponent<player>().B222 == true && dentro == true)
        {
            Debug.Log("no oculto");
            state = true;
            a02.gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
            FindObjectOfType<player>().GetComponent<player>().B222use = false;
            FindObjectOfType<player>().GetComponent<player>().B222 = false;
            FindObjectOfType<player>().GetComponent<player>().onT = false;
            dentro =  false;
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
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

    }
}
