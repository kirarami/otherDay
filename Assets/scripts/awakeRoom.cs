using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class awakeRoom : MonoBehaviour
{

    public int mode;
    public GameObject g1;
    public GameObject g2;
    public int upidl;
    // bloque1
    public float choI001;
    public GameObject P1;
    public Text text1;
    public string[] tips;
    public int tipCount;
    public bool playGame;
    public GameObject canvas1;

    //blqoue 2
    [SerializeField, TextArea(4, 6)] public string[] textOBJ;
    public TMP_Text tx;
    public bool eliminate;
    public int idl;
    public bool precentationInici01;

    //public GameObject[] findT;
    //public GameObject obj1;
    // Start is called before the first frame update
    void Start()
    {
        choI001 = Random.Range(500f, 1000f);
        generateT();
        playGame = false;
        canvas1.SetActive(false);
        precentationInici01 = false;
        g2.SetActive(false);
        upidl = idl + 1;
        //findT = GameObject.FindGameObjectsWithTag("NPC1");
    }

    // Update is called once per frame
    void Update()
    {
        choI001--;
        if (choI001 <= 0)
        {
            if (mode == 0)
            {
                Debug.Log("entro");
                canvas1.SetActive(true);
                // obj1.SetActive(true);
                Destroy(P1);
                playGame = true;
            }
            else
            {
                Debug.Log("iniciando el modo secundario");
                g1.SetActive(false);
                g2.SetActive(true);
                if (precentationInici01 == false)
                {
                    StartCoroutine(starttext());
                    precentationInici01 = true;
                    transform.position = new Vector3(transform.position.x, 1000, transform.position.z); 
                }
            }
            
        }
        if (upidl > textOBJ.Length)
        {
            Debug.Log("textos terminados");
            canvas1.SetActive(true);
            Destroy(P1);
        }


    }
    private IEnumerator starttext()
    {
        tx.text = string.Empty;

        foreach (char ch in textOBJ[idl])
        {
            tx.text += ch;
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void nexT()
    {
        upidl = idl + 1;
        if (tx.text == textOBJ[idl])
        {
            if (upidl < textOBJ.Length)
            {
                idl += 1;
                StartCoroutine(starttext());
            }
            else
            {
                Debug.Log("textos terminados");
                canvas1.SetActive(true);
                Destroy(P1);
            }
        }

    }
    public void generateT()
    {
        tipCount = Random.Range(0, tips.Length);
        text1.text = tips[tipCount];
    }
}
