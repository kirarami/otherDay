using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Animations;
using TMPro;

public class precenTXT01 : MonoBehaviour
{
    [SerializeField, TextArea(4, 6)] public string[] textOBJ;
    public TMP_Text tx;
    public bool eliminate;
    public int idl;
    public bool precentationInici01;

    public GameObject g1;

    public GameObject carga;
    // Start is called before the first frame update
    void Start()
    {
        carga = GameObject.FindGameObjectWithTag("carga");
        idl = 0;
        precentationInici01 = false;
        eliminate = false;
        g1.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        carga = GameObject.FindGameObjectWithTag("carga");
        if (!carga && precentationInici01 == false)
        {
            StartCoroutine(starttext());
            precentationInici01 = true;
            g1.SetActive(true);
        }
        if (eliminate){ Destroy(gameObject);}
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
        if (tx.text == textOBJ[idl])
        {
            if (idl <= textOBJ.Length)
            {
                idl += 1;
                StartCoroutine(starttext());
            }
            else
            {
                Debug.Log("textos terminados");
                eliminate = true;
            }
        }
     
    }
}
