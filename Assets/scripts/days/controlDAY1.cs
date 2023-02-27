using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class controlDAY1 : MonoBehaviour
{
    public GameObject imageT;
    public TMP_Text textT;
    public TMP_Text textSala01;
    public string[] stringSalas01;
    private bool iniciTSala;
    cameraCTRL01 camara; 
    private string stringT;
    public bool iniciT;
    public string otherID;
    public bool del;
    public bool MSinves;
    public bool MScomp;
    public GameObject player1;
    public int line;
    public bool xd;
    public int contador;

    public bool gameFIN7;
    public GameObject fin7;

    //other
    public bool iniciEnemy01;
    public GameObject pared01;

    controlEnemy01 enemyScr01;


    // Start is called before the first frame update
    void Start()
    {
        //enemyScr01 = GameObject.FindGameObjectWithTag("enemy").GetComponent<controlEnemy01>();
        imageT.SetActive(false);

        otherID = "";
        del = false;
        
        //camara = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<cameraCTRL01>();
        line = 0;
        xd = true;
        contador = -1;
        pared01.SetActive(false);
        fin7.SetActive(false);
        gameFIN7 = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(FindObjectOfType<player>().GetComponent<player>().salasIDs == 2)
        {
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<cameraCTRL01>().maximo = new Vector2(217,0); //normal es 4 (regresarlo luego de hacer cambios)
            iniciTSala = true;
            if(iniciTSala == true)
            {
                if (player1.transform.position.x >= 4 && contador  == -1)
                {
                    //textSala01.text = stringSalas01[line];
                    if (xd)
                    {
                        StartCoroutine(showtextSala());
                        StartCoroutine(delTxtSala());
                        pared01.SetActive(false);
                        contador++;
                        xd = false;
                    }
                }

                if (player1.transform.position.x >= 30  && contador == 0)
                {
                    //textSala01.text = stringSalas01[line];
                    if (xd)
                    {
                        StartCoroutine(showtextSala());
                        StartCoroutine(delTxtSala());
                        pared01.SetActive(false);
                        contador++;
                        xd = false;
                    }
                }

                if (player1.transform.position.x >= 60 && contador == 1)
                {
                    //textSala01.text = stringSalas01[line];
                    if (xd)
                    {
                        StartCoroutine(showtextSala());
                        StartCoroutine(delTxtSala());
                        pared01.SetActive(false);
                        contador++;
                        xd = false;
                    }
                }

                if (player1.transform.position.x >= 90 && contador == 2)
                {
                    //textSala01.text = stringSalas01[line];
                    if (xd)
                    {
                        StartCoroutine(showtextSala());
                        StartCoroutine(delTxtSala());
                        pared01.SetActive(false);
                        contador++;
                        xd = false;
                    }
                }

                if (player1.transform.position.x >= 110 && contador == 3)
                {
                    //textSala01.text = stringSalas01[line];
                    if (xd)
                    {
                        StartCoroutine(showtextSala());
                        StartCoroutine(delTxtSala());
                        pared01.SetActive(false);
                        contador++;
                        xd = false;
                    }
                }

                if (player1.transform.position.x >= 117 && contador == 4)
                {
                    //textSala01.text = stringSalas01[line];
                    if (xd)
                    {
                        pared01.SetActive(true);
                        iniciEnemy01 = true;
                        GameObject.FindGameObjectWithTag("controlEne").GetComponent<controlEnemy01>().enemyStart = true;
                        Debug.Log("enemigo 01 iniciado");
                        contador++;
                        xd = false;
                    }
                }

            }
        }
        else if(FindObjectOfType<player>().GetComponent<player>().salasIDs == 1)
        {
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<cameraCTRL01>().maximo = new Vector2(4,0);
            iniciTSala = false;
        }
        else 
        {
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<cameraCTRL01>().maximo = new Vector2(4, 0);
            iniciTSala = false;
        }
        if (MSinves == true)
        {
            //Debug.Log("iniciando: MScomplete");
            MScomplete();
            MSinves = false;
        }

        if (iniciT == true)
        {
            otherIDGame(otherID);
            textForGame();
            FindObjectOfType<player>().GetComponent<player>().B222 = false;
            FindObjectOfType<player>().GetComponent<player>().onT = true;
            if (del == false)
           {
                StartCoroutine(showLine());
           }
           else
           {
                 Debug.Log("ERROR");
           }
            StartCoroutine(dels());
        }

        if (gameFIN7 == true)
        {
            fin7.SetActive(true);
        }

    }

    public void MScomplete()
    {
        for (int i = 0; i < FindObjectOfType<player>().GetComponent<player>().objs.Length; i++)
        {
            if (FindObjectOfType<player>().GetComponent<player>().objs[i] == "camara01")
            {
                //FindObjectOfType<player>().GetComponent<player>().interectiveAllGame = false;
                FindObjectOfType<player>().GetComponent<player>().MS1 = true;
                MSinves = false;
                break;
            }
            else
            {
              ///  Debug.Log("objeto encontrado: mision completa");
                MSinves = false;
            }
        }
        //Debug.Log("MS completado");
    }
    public void otherIDGame(string otherIDs)
    {
        switch (otherIDs)
        {
            case "closeDoor":
                stringT = "necesitas una llave";
                break;
            default:
                stringT = otherIDs;
                break;
        }
    }
    public void textForGame()
    {
        imageT.SetActive(true);
        //textT.text = stringT;

    }

    private IEnumerator showLine()
    {
            textT.text = string.Empty;
            foreach (char ch in stringT)
            {
                del = true;
                textT.text += ch;
                yield return new WaitForSeconds(0.01f);
            }

    }
    private IEnumerator showtextSala()
    {
        textSala01.text = string.Empty;

        foreach (char ch in stringSalas01[line])
        {
            textSala01.text += ch;
            yield return new WaitForSeconds(0.1f);
        }

    }
    private IEnumerator delTxtSala()
    {
            yield return new WaitForSeconds(8f);
            textSala01.text = string.Empty;
            line++;
            xd = true;

    }
    private IEnumerator dels()
    {
        yield return new WaitForSecondsRealtime(4f);
        Debug.Log("dels(activado)");
        FindObjectOfType<player>().GetComponent<player>().B222 = false;
        FindObjectOfType<player>().GetComponent<player>().onT = false;
        //FindObjectOfType<player>().GetComponent<player>().IDlocal = "";
        //FindObjectOfType<player>().GetComponent<player>().interectiveAllGame = false;
        otherID = "";
        //stringT = "";
        imageT.SetActive(false);
        iniciT = false;
        del = false;
    }





}
