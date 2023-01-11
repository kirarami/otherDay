using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    public Vector3 movimiento;
    public float velocidad;
    private new Animator animation;
    public float states1;
    public GameObject boton1;
    public bool interectiveAllGame;
    public string IDlocal;
    public int DAY;
    public bool addOBJsIS;
    public int salasIDs;
    public int peligroP;
    //private new Rigidbody2D rigibody;

    public bool left = false;
    public  bool right = false;
    bool up = false;
    bool down = false;
    public bool B111 = false;
    public bool B111use = true;
    public bool B222 = false;
    public bool B222use = true;
    bool move = false;
    public bool onT = false;
    public bool rec1 = false;
    public bool rec2 = false;

    public int apoy;

    public bool MS1 = false;

    //obejetos 
    public string[] objs;
    public string llave;
    public Image[] objsIMG;
    public Sprite[] objsSPR;

    // Start is called before the first frame update
    void Start()
    {
        peligroP = 0;
        boton1.SetActive(false);
        //rigibody = GetComponent<Rigidbody2D>();
        animation = GetComponent<Animator>(); 
        states1 = 0;
        apoy = 1;
        llave = "noone";
        salasIDs = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(interectiveAllGame == true)
        {
            if (DAY == 7)
            {

                if (addOBJsIS == true) { GameObject.FindGameObjectWithTag("controlD").GetComponent<controlDAY1>().MSinves = true;
                }
                else
                {
                    GameObject.FindGameObjectWithTag("controlD").GetComponent<controlDAY1>().otherID = IDlocal;
                    GameObject.FindGameObjectWithTag("controlD").GetComponent<controlDAY1>().iniciT = true;
                }
            }
        }


        if (rec1 == true)
        {
            Debug.Log("carga de B111 en inicio");
            float timer = 1;
            timer--;
            Debug.Log("timer en :" + timer);
            if (timer <= 0)
            {
                rec1 = false;
                B111 = false;
                Debug.Log("carga de B111 en proceso");
            }
        }

        if (rec2 == true)
        {
            Debug.Log("carga de B222 en inicio");
            StartCoroutine(USEB222());
           // float timer1 = 3;
           // timer1--;
          //  timer1--;
          //  timer1--;
          //  Debug.Log("timer en :" + timer1);
          //  if (timer1 <= 0)
          //  {
          //      rec2 = false;
          //      B222 = false;
           //     Debug.Log("carga de B222 en proceso");
          //  }
        }

        //(FindObjectOfType<Dialoge>().GetComponent<Dialoge>().didDialogueStart == false)
        if (move == false && onT == false)
        {
            movimiento = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
            movimiento = movimiento.normalized;
            if (apoy == 1)
            {
                animation.SetFloat("estate1", states1);
            }
            else
            {
                animation.SetFloat("estate1", apoy);
            }
            //transform.position += movimiento * velocidad * Time.deltaTime;
            //rigibody.MovePosition(transform.position += movimiento * velocidad * Time.deltaTime);


            if (left == true)
            {
                movimiento = new Vector3(-velocidad, Input.GetAxisRaw("Vertical"), 0);
                movimiento = movimiento.normalized;
                transform.position += movimiento * velocidad * Time.deltaTime;

                transform.localScale = new Vector3(-8, 8, 1);
                states1 = 1;


            }

            if (right == true)
            {
                movimiento = new Vector3(+velocidad, Input.GetAxisRaw("Vertical"), 0);
                movimiento = movimiento.normalized;
                transform.position += movimiento * velocidad * Time.deltaTime;

                transform.localScale = new Vector3(8, 8, 1);
                states1 = 1;
            }

            if (up == true)
            {
                movimiento = new Vector3(Input.GetAxisRaw("Horizontal"), +velocidad, 0);
                movimiento = movimiento.normalized;
                transform.position += movimiento * velocidad * Time.deltaTime;
            }

            if (down == true)
            {
                movimiento = new Vector3(Input.GetAxisRaw("Horizontal"), -velocidad, 0);
                movimiento = movimiento.normalized;
                transform.position += movimiento * velocidad * Time.deltaTime;
            }


        }


    }
    public void CmovL()
    {
            left = true;
            apoy = 1;
    }
    public void UPmovL()
    {
            left = false;
            states1 = 0;

    }
    public void CmovR()
    {
            right = true;
            apoy = 1;
    }
    public void UPmovR()
    {
        right = false;
        states1 = 0;
 
    }
    public void CmovU()
    {
        up = true;
    }
    public void UPmovU()
    {
        up = false;
        states1 = 0;
    }
    public void CmovD()
    {
        down = true;
    }
    public void UPmovD()
    {
        down = false;
        states1 = 0;
    }
    public void B111movU()
    {
        B111 = false;
        B111use = true;
    }
    public void B111movD()
    {
        // if (rec1 == false) 
        // { 
        //  B111 = true;
        // rec1 = true;
        //     Debug.Log("B111");
        // }
        if (B111use == true)
        {
            B111 = true;
        }
        else
        {
            B111 = false;
        }
    }
    public void B222movU()
    {
        //if (rec2 == false)
        // {
        B222 = false;
        B222use = true;
        //     rec2 = true;
        //    Debug.Log("B222");
        // }
    }
    public void B222movD()
    {
        //if (rec2 == false)
        // {
        if (B222use == true)
        {
            B222 = true;
        }
        else
        {
            B222 = false;
        }
       //     rec2 = true;
        //    Debug.Log("B222");
       // }
    }

    //seccion de objetos en el juego y llaves
    public bool FindObjs(string obj)
    {
        bool a1 = false;
        for (int i = 0; i < objs.Length; i++)
        {
            if(objs[i] == obj)
            {
                a1 = true;
                break;
            }
        }
        return a1;
    }

    public void AddObjs(string obj)
    {
        for (int i = 0; i < objs.Length; i++)
        {
            if (objs[i] == "")
            {
                objs[i] = obj;
                addOBJsIS = true;
                interectiveAllGame = true;
                break;
            }
            else
            {
                Debug.Log("todos los sitios estan llenos");
            }
        }
    }

    public void showItem()
    {
        for (int i = 0; i < objs.Length; i++)
        {
            if (objs[i] != "")
            {
                string ident01 = detecItem(i);
                int int01 = numberItem(ident01);

                //objsIMG[i].gameObject.GetComponent<SpriteRenderer>().sprite = objsSPR[int01];
                objsIMG[i].sprite = objsSPR[int01];
                //objsIMG[i].SetActive(true);
            }
            else
            {
                objsIMG[i].sprite = objsSPR[0];
                Debug.Log("este slot no tiene nada:" + i);
            }
        }
    }
    
    //no usables fuera de este script 
    private int numberItem(string b)
    {
        int number = 0;
        //for (int i = 0; i < objs.Length; i++)
        // {
        //     if (objs[i] == b)
        //     {
        //          number = i;
        //          break;
        //     }
        // }
        switch (b)
        {
            case "noone":
                number = 0;
                break;
            case "cuchillo01":
                number = 1;
                break;

            case "hoja01":
                number = 2;
                break;

            case "camara01":
                number = 3;
                break;

        }
        return number;
    }
    private string detecItem(int a)
    {
        string ident1 = "";
        for (int i = 0; i < objs.Length; i++)
        {
            if (i == a)
            {
                ident1 = objs[i];
                break;
            }

        }
        return ident1;
    }

    public void Addllave(string llaveN)
    {
        llave = llaveN;
    }
    private IEnumerator USEB222()
    {
        rec2 = false;
        B222 = false;
        Debug.Log("carga de B222 en proceso");
        yield return new WaitForSeconds(1);

    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        //move = collision.gameObject.GetComponent<Dialoge>().didDialogueStart;
    }

    private void FixedUpdate()
    {
        //rigibody.MovePosition(transform.position += movimiento * velocidad * Time.fixedDeltaTime);
    }
}


