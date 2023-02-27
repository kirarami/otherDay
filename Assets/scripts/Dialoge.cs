using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Animations;
using UnityEngine.Rendering.Universal;

public class Dialoge : MonoBehaviour
{
    public GameObject player1;

    [SerializeField] private GameObject aset1;
    // [SerializeField] private GameObject aset2;
    [SerializeField] private GameObject dialogeP;
    [SerializeField] private TMP_Text dialogueT;
    [SerializeField, TextArea(4, 6)] private string[] dialogueL;
    [SerializeField, TextArea(4, 6)] private string[] dialogueL1;
    private bool isPlayerInRange;
    public bool didDialogueStart;
    private int lineIndex;
    private float sec1 = 0.05f;
    private int secplus;
    private bool intere = true;
    private Animator animation01;

    //textos multiples

    //si es que harbra o no una mission o un texto depues de algo
    public bool TM1;
    //si se completo la mission o algo apra un texto depues 
    public bool MSForTMComplet;

    //luego pondremos un texto para cuando se realize una mission y es todo 

    //opcionales

    actions01T a1;
    public bool selec1;
    public bool selec2;
    public string selecAC1;
    public int action01;
    //objs apoyo
    public GameObject objApo01;
    public GameObject objApo02;
    public GameObject objApo03;

    // Start is called before the first frame update
    void Start()
    {
        //player1 = player.Ga .GetComponent<player>().B111;
        secplus = lineIndex + 1;
        a1 = GameObject.FindGameObjectWithTag("AC1").GetComponent<actions01T>();
        action01 = 0;
        animation01 = GetComponent<Animator>();

        objApo01.SetActive(false);
        MSForTMComplet = false;
        lineIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        secplus = lineIndex + 1;
        if (isPlayerInRange && intere == true)
        {
            if (!didDialogueStart && FindObjectOfType<player>().GetComponent<player>().B111 == true)
            {
                StartDialogue();
                FindObjectOfType<player>().GetComponent<player>().B111 = false;
            }
            else if (dialogueT.text == dialogueL[lineIndex] && FindObjectOfType<player>().GetComponent<player>().B111 == true)
            {
                if (lineIndex < dialogueL.Length)
                {
                    secplus = lineIndex + 1;
                    if (secplus < dialogueL.Length)
                    {
                        nextDLine();
                        FindObjectOfType<player>().GetComponent<player>().B111 = false;
                        Debug.Log(secplus);
                    }
                    else if (secplus > dialogueL.Length)
                    {
                        Debug.Log("entrada1: +1");
                        didDialogueStart = false;
                        dialogeP.SetActive(false);
                        //aset2.SetActive(false);
                        intere = false;
                        if (selec1 == true) { selec2 = true; }
                        FindObjectOfType<player>().GetComponent<player>().onT = false;
                    }
                    else
                    {
                        Debug.Log("entrada1: +1");
                        didDialogueStart = false;
                        dialogeP.SetActive(false);
                        // aset2.SetActive(false);
                        intere = false;
                        if (selec1 == true) { selec2 = true; }
                        FindObjectOfType<player>().GetComponent<player>().onT = false;
                    }

                }
                else if (lineIndex > dialogueL.Length)
                {
                    Debug.Log("entrada1: +1");
                    didDialogueStart = false;
                    dialogeP.SetActive(false);
                    // aset2.SetActive(false);
                    intere = false;
                    if (selec1 == true) { selec2 = true; }
                    FindObjectOfType<player>().GetComponent<player>().onT = false;

                }

            }
        }


        if (isPlayerInRange && intere == true && TM1 == true && MSForTMComplet == true)
        {
            if (!didDialogueStart && FindObjectOfType<player>().GetComponent<player>().B111 == true)
            {
                StartDialogue();
                FindObjectOfType<player>().GetComponent<player>().B111 = false;
            }
            else if (dialogueT.text == dialogueL1[lineIndex] && FindObjectOfType<player>().GetComponent<player>().B111 == true)
            {
                if (lineIndex < dialogueL1.Length)
                {
                    secplus = lineIndex + 1;
                    if (secplus < dialogueL1.Length)
                    {
                        nextDLine();
                        FindObjectOfType<player>().GetComponent<player>().B111 = false;
                        Debug.Log(secplus);
                    }
                    else if (secplus > dialogueL1.Length)
                    {
                        Debug.Log("entrada1: +1");
                        didDialogueStart = false;
                        dialogeP.SetActive(false);
                        //aset2.SetActive(false);
                        intere = false;
                        if (selec1 == true) { selec2 = true; }
                        lineIndex = 0;
                        FindObjectOfType<player>().GetComponent<player>().onT = false;
                    }
                    else
                    {
                        Debug.Log("entrada1: +1");
                        didDialogueStart = false;
                        dialogeP.SetActive(false);
                        // aset2.SetActive(false);
                        intere = false;
                        if (selec1 == true) { selec2 = true; }
                        lineIndex = 0;
                        FindObjectOfType<player>().GetComponent<player>().onT = false;
                    }

                }
                else if (lineIndex > dialogueL1.Length)
                {
                    Debug.Log("entrada1: +1");
                    didDialogueStart = false;
                    dialogeP.SetActive(false);
                    // aset2.SetActive(false);
                    intere = false;
                    if (selec1 == true) { selec2 = true; }
                    lineIndex = 0;
                    FindObjectOfType<player>().GetComponent<player>().onT = false;

                }

            }
        }

        //opcion para acciones depues del texto
        if (selec2) { a1.Lib_actionsUni0("anim_Sprite_choose1"); }
        if (action01 != 0) { actionsN01(action01); }
    }

    private void actionsN01(int a)
    {
        switch (a)
        {
            case 1:
                animation01.SetFloat("ani1_01", a);
                StartCoroutine(activate1(5.9f, objApo01));
                FindObjectOfType<player>().GetComponent<player>().onT = true;

                GameObject i;
                GameObject[] i1;
                i = GameObject.FindGameObjectWithTag("uniLight01");
                i1 = GameObject.FindGameObjectsWithTag("Light01");
                if (i){ i.GetComponent<Light2D>().intensity = 1; }

                for(int h = 0;h < i1.Length; h++)
                {
                   i1[h].SetActive(false);
                }
                break;
        }
    }
    public void StartDialogue()
    {
        Debug.Log("entrada1: +");
        didDialogueStart = true;
        dialogeP.SetActive(true);
        aset1.SetActive(false);
        //aset2.SetActive(true);
        lineIndex = 0;
        FindObjectOfType<player>().GetComponent<player>().B111 = false;
        FindObjectOfType<player>().GetComponent<player>().states1 = 0;
        FindObjectOfType<player>().GetComponent<player>().onT = true;
        StartCoroutine(showLine());
    }

    private void nextDLine()
    {
       if(MSForTMComplet == false)
        {
            if (lineIndex < dialogueL.Length)
            {
                lineIndex++;
                if (lineIndex < dialogueL.Length)
                {
                    StartCoroutine(showLine());
                }
                else if (lineIndex > dialogueL.Length)
                {
                    didDialogueStart = false;
                    dialogeP.SetActive(false);
                    // aset2.SetActive(false);
                }
            }
            else
            {
                didDialogueStart = false;
                dialogeP.SetActive(false);
                //  aset2.SetActive(false);
            }
        }
        else
        {
            if (lineIndex < dialogueL1.Length)
            {
                lineIndex++;
                if (lineIndex < dialogueL1.Length)
                {
                    StartCoroutine(showLine());
                }
                else if (lineIndex > dialogueL1.Length)
                {
                    didDialogueStart = false;
                    dialogeP.SetActive(false);
                    // aset2.SetActive(false);
                }
            }
            else
            {
                didDialogueStart = false;
                dialogeP.SetActive(false);
                //  aset2.SetActive(false);
            }

        }
    }
    private IEnumerator showLine()
    {
        if (MSForTMComplet == false)
        {
            dialogueT.text = string.Empty;

            foreach (char ch in dialogueL[lineIndex])
            {
                dialogueT.text += ch;
                yield return new WaitForSeconds(sec1);
            }
        }
        if (MSForTMComplet == true)
        {
            dialogueT.text = string.Empty;

            foreach (char ch in dialogueL1[lineIndex])
            {
                dialogueT.text += ch;
                yield return new WaitForSeconds(sec1);
            }
        }
    }

    IEnumerator activate1(float tiempo, GameObject g)
    {
        yield return new WaitForSecondsRealtime(tiempo);
        g.SetActive(true);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            FindObjectOfType<player>().GetComponent<player>().boton1.SetActive(true);
            isPlayerInRange = true;
            aset1.SetActive(true);
            Debug.Log("dentro");
            //collision.gameObject.GetComponent<player>().onT = true;
            if (player1.GetComponent<player>().MS1 == true)
            {
                MSForTMComplet = true;
                lineIndex = 0;
            }
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            FindObjectOfType<player>().GetComponent<player>().boton1.SetActive(false);
            Debug.Log("entrada1: +1");
            isPlayerInRange = false;
            aset1.SetActive(false);
            Debug.Log("fuera");
            intere = true;
        }

    }

    //acciones mediante animacion
    public void animationACTION0()
    {
        objApo02.SetActive(true);
    }

}
