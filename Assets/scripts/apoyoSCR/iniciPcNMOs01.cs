using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Animations;
using TMPro;

public class iniciPcNMOs01 : MonoBehaviour
{
    public bool precentationInici01;
    public bool enter;
    [SerializeField, TextArea(4, 6)] public string textOBJ;
    public GameObject canv1;
    public TMP_Text tx;
    public string txst;
    public bool eliminate;
    public bool inc;
    public GameObject boto01;
    //public Animator animationcan;
    // Start is called before the first frame update
    void Start()
    {
        precentationInici01 = false;
        inc = false;
        canv1.SetActive(false);
       // animationcan = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //modificar codigo el dia domingo pk ahora ando cansado y lele todo unu
        if (enter && !precentationInici01)
        {

            switch(inc) 
            {
                case false:
                    FindObjectOfType<player>().GetComponent<player>().onT = true;
                    canv1.SetActive(true);
                    boto01.SetActive(false);
                    break;
                case true:
                    boto01.SetActive(true);
                 Debug.Log("demostracion iniciada");
                StartCoroutine(showLine());
                //StartCoroutine(delEnemy());
                    precentationInici01 = true;
                    break;
            }
        }
       // FindObjectOfType<player>().GetComponent<player>().B222 == true


        if (eliminate) { Destroy(gameObject); canv1.SetActive(false); precentationInici01 = false; }
    }
    private IEnumerator delEnemy()
    {
        yield return new WaitForSeconds(5f);
        eliminate = true;
        Debug.Log("papeldestroy");

    }
    private IEnumerator showLine()
    {
            tx.text = string.Empty;

        foreach (char ch in textOBJ)
        {
            tx.text += ch;
            yield return new WaitForSeconds(0.08f);
            }
        }

        /*
        public void iniciMO()
        {
            padre.inc = true;
            canv1.GetComponent<Animator>().
        }
        */
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
