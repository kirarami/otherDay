using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;
using TMPro;

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

    public bool windowsobj;
    public int stateO;
    public int windowsobj_selec;
    public int windowsobj_selec1;
    public bool useobj;
    public bool deleteobj;
    public GameObject windowsO;
    public Image obj1w;
    public Image obj2w;
    public Image obj3w;
    public Image useO;
    public Image del0;
    public TMP_Text descrip;
    public string descrip1;


    //private new Rigidbody2D rigibody;

    public bool left = false;
    public bool right = false;
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

    private float yO;
    private float upv0;

    private bool frame1;

    public bool objeto01;
    private GameObject ob;
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

        windowsobj_selec = 0;
        stateO = 0;
        upv0 = obj1w.transform.position.y + 30;
        yO = obj1w.transform.position.y;
        windowsO.SetActive(true);
        frame1 = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (frame1 == true) {
            windowsobj_selec = 0;
            stateO = 0;
            upv0 = obj1w.transform.position.y + 30;
            yO = obj1w.transform.position.y;
            windowsO.SetActive(false);
            frame1 = false;
        }
        if (windowsobj == true)
        {
            onT = true;
            windowsO.SetActive(true);
            if (stateO == 0)
            {
                if (right == true)
                {
                    if (windowsobj_selec < 2)
                    {
                        windowsobj_selec++;
                    }
                    else
                    {
                        windowsobj_selec = 0;
                    }
                    right = false;
                }
                if (left == true)
                {
                    if (windowsobj_selec > 0)
                    {
                        windowsobj_selec--;
                    }
                    else
                    {
                        windowsobj_selec = 2;
                    }
                    left = false;
                }
                if (B222 == true)
                {
                    B222 = false;
                    stateO = 1;
                }
                switch (windowsobj_selec)
                {
                    case 0:

                        obj1w.transform.position = new Vector3(obj1w.transform.position.x, upv0, 0);
                        obj2w.transform.position = new Vector3(obj2w.transform.position.x, yO, 0);
                        obj3w.transform.position = new Vector3(obj3w.transform.position.x, yO, 0);
                        break;

                    case 1:

                        obj1w.transform.position = new Vector3(obj1w.transform.position.x, yO, 0);
                        obj2w.transform.position = new Vector3(obj2w.transform.position.x, upv0, 0);
                        obj3w.transform.position = new Vector3(obj3w.transform.position.x, yO, 0);
                        break;

                    case 2:

                        obj1w.transform.position = new Vector3(obj1w.transform.position.x, yO, 0);
                        obj2w.transform.position = new Vector3(obj2w.transform.position.x, yO, 0);
                        obj3w.transform.position = new Vector3(obj3w.transform.position.x, upv0, 0);
                        break;
                }
            }
            if (stateO == 1)
            {
                if (right == true)
                {
                    if (windowsobj_selec1 < 1)
                    {
                        windowsobj_selec1++;
                    }
                    else
                    {
                        windowsobj_selec1 = 0;
                    }
                    right = false;
                }
                if (left == true)
                {
                    if (windowsobj_selec1 > 0)
                    {
                        windowsobj_selec1--;
                    }
                    else
                    {
                        windowsobj_selec1 = 1;
                    }
                    left = false;
                }
                if (B222 == true)
                {
                    B222 = false;
                    if (windowsobj_selec1 == 0)
                    {
                        useOBJSEN(windowsobj_selec);

                    }
                    else
                    {
                        delOBJSEN(windowsobj_selec);
                    }
                    stateO = 2;
                }
                switch (windowsobj_selec1)
                {
                    case 0:
                        useO.transform.position = new Vector3(useO.transform.position.x, upv0, 0);
                        del0.transform.position = new Vector3(del0.transform.position.x, yO, 0);
                        break;
                    case 1:
                        useO.transform.position = new Vector3(useO.transform.position.x, yO, 0);
                        del0.transform.position = new Vector3(del0.transform.position.x, upv0, 0);
                        break;
                }
            }
            obj1w.sprite = chooseSpri(0);
            obj2w.sprite = chooseSpri(1);
            obj3w.sprite = chooseSpri(2);
            descrip1 = descripCHoo(windowsobj_selec);

            descrip.text = descrip1;
        }

        if (interectiveAllGame == true)
        {
           // if (DAY == 7)
           // {

                //if (addOBJsIS == true)
               // {
                  //  GameObject.FindGameObjectWithTag("controlD").GetComponent<controlDAY1>().MSinves = true;
               // }
              //  else
               // {
                    GameObject.FindGameObjectWithTag("controlD").GetComponent<controlDAY1>().otherID = IDlocal;
                    GameObject.FindGameObjectWithTag("controlD").GetComponent<controlDAY1>().iniciT = true;
                    IDlocal = "";
                    interectiveAllGame = false;
                    //GameObject.FindGameObjectWithTag("controlD").GetComponent<controlDAY1>().del = false;
               // }
       //     }
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
    public void useOBJSEN(int i)
    {
        string IDlocal1 = "nada fuera de lo comun en mis ojos";
        if (objs[i] == "cuchillo01") { IDlocal1 = "cuchillo fue usado"; }
        if (objs[i] == "camara01") { IDlocal1 = "camara fue usada pero no paso nada mas (las fotos se guardaron en la camara)"; }
        if (objs[i] == "hoja01") { IDlocal1 = "no es necesario decirte que no leas esto"; }
        if (objs[i] == "bolso01") { IDlocal1 = "no pasa nada"; }
        if (objs[i] == "hacha01") {
            if (objeto01 == false)
            {
                IDlocal1 = "puedes romper cosas como madera con esto";
            }
            else
            {
                IDlocal1 = "destruiste esto";
                Debug.Log("destruir comienzo");
                Destroy(ob);
                
            }
        }
        interectiveAllGame = true;
        IDlocal = IDlocal1;
        windowsO.SetActive(false);
        windowsobj = false;
        //IDlocal = "";
        objeto01 = false;
    }

    public void delOBJSEN(int i)
    {
        if (objs[i] == "cuchillo01") { objs[i] = ""; objsIMG[i].sprite = objsSPR[0]; }
        if (objs[i] == "hoja01") { objs[i] = ""; objsIMG[i].sprite = objsSPR[0]; }
        if (objs[i] == "camara01" && DAY == 7) {
            GameObject.FindGameObjectWithTag("controlD").GetComponent<controlDAY1>().otherID = "no puedes eliminar este objeto por ahora";
            GameObject.FindGameObjectWithTag("controlD").GetComponent<controlDAY1>().iniciT = true;
        }
        if (objs[i] == "bolso01") { objs[i] = ""; objsIMG[i].sprite = objsSPR[0]; }
        if (objs[i] == "hacha01" && DAY == 7)
        {
            GameObject.FindGameObjectWithTag("controlD").GetComponent<controlDAY1>().otherID = "no puedes eliminar este objeto por ahora";
            GameObject.FindGameObjectWithTag("controlD").GetComponent<controlDAY1>().iniciT = true;
        }
        windowsO.SetActive(false);
        windowsobj = false;
        onT = false;
    }

    public string descripCHoo(int i)
    {
        string des = "??????";
        if (objs[i] == "cuchillo01") { des = "un chuchillo.... raro encontrarlo por aqui verdad ¿que pretendes?"; }
        if (objs[i] == "camara01") { des = "grabar y tomar fotos es fantastico ¿verdad?"; }
        if (objs[i] == "hoja01") { des = "una hoja de papel aparentemente normal"; }
        if (objs[i] == "bolso01") { des = "objeto que sirve para guardar cosas"; }
        if (objs[i] == "hacha01") { des = "objeto que se usa para romper cosas como madera y metal"; }
        return des;
    }

    public Sprite chooseSpri(int i)
    {
        int i1 = 0;
        if (objs[i] != "noone")
        {
            switch (i)
            {
                case 0:
                    if (objs[0] == "cuchillo01") { i1 = 1; }
                    if (objs[0] == "hoja01") { i1 = 2; }
                    if (objs[0] == "camara01") { i1 = 3; }
                    if (objs[0] == "bolso01") { i1 = 4; }
                    if (objs[0] == "hacha01") { i1 = 5; }
                    break;
                case 1:
                    if (objs[1] == "cuchillo01") { i1 = 1; }
                    if (objs[1] == "hoja01") { i1 = 2; }
                    if (objs[1] == "camara01") { i1 = 3; }
                    if (objs[1] == "bolso01") { i1 = 4; }
                    if (objs[1] == "hacha01") { i1 = 5; }
                    break;
                case 2:
                    if (objs[2] == "cuchillo01") { i1 = 1; }
                    if (objs[2] == "hoja01") { i1 = 2; }
                    if (objs[2] == "camara01") { i1 = 3; }
                    if (objs[2] == "bolso01") { i1 = 4; }
                    if (objs[2] == "hacha01") { i1 = 5; }
                    break;

            }
        }
        return objsSPR[i1];
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
            if (objs[i] == obj)
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
                //interectiveAllGame = true;
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
            case "bolso01":
                number = 4;
                break;
            case "hacha01":
                number = 5;
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

    /*
    public bool windowsobj;
    public int stateO;
    public int windowsobj_selec;
    public int windowsobj_selec1;
    public bool useobj;
    public bool deleteobj;
    public Image obj1w;
    public Image obj2w;
    public Image obj3w;
    public Image useO;
    public Image del0;
    public Text descrip;
    */
    public void openwindoObj()
    {
        if(windowsobj == false)
        {
            windowsobj = true;
        }
        else
        {
            windowsO.SetActive(false);
            windowsobj = false;
            onT = false;
        }
        stateO = 0;
        windowsobj_selec = 0;
        windowsobj_selec1 = 0;

    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        //move = collision.gameObject.GetComponent<Dialoge>().didDialogueStart;
    }

    private void FixedUpdate()
    {
        //rigibody.MovePosition(transform.position += movimiento * velocidad * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("madDoorT"))
        {
            objeto01 = false;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("madDoorT"))
        {
            objeto01 = true;
            ob = other.gameObject;
        }
       // if (actionOb == true && other.CompareTag("madDoorT"))
        //{
        //    Destroy(other);
       //     Debug.Log("destruir otro objeto");
      //  }
    }
   
}


