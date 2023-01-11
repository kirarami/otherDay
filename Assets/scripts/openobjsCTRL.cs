using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openobjsCTRL : MonoBehaviour
{
    public bool state;
    public bool enter;
    public Sprite spr1;
    public Sprite spr2;
    public string objID;
    public player a03;
    public bool isLlave;
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = spr2;
        enter = false;
        a03 = GameObject.FindGameObjectWithTag("player").GetComponent<player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (state == true)
        {
            //cambiar sprite
            this.gameObject.GetComponent<SpriteRenderer>().sprite = spr1;
        }
        if (enter == true && state == false && FindObjectOfType<player>().GetComponent<player>().B222 == true)
        {
            state = true;
            if (isLlave == false)
            {
                sendObj(objID);
                a03.showItem();
                FindObjectOfType<player>().GetComponent<player>().B222 = false;
            }
            else
            {
                sendLlave(objID);
                FindObjectOfType<player>().GetComponent<player>().B222 = false;
            }
        }
    }

    public void sendObj(string obj)
    {
        Debug.Log("objeto obtenido(objeto): "+ obj);
        a03.AddObjs(obj);
    }
    public void sendLlave(string obj)
    {
        Debug.Log("objeto obtenido(llave): " + obj);
        a03.Addllave(obj);
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
