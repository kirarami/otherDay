using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Animations;

public class hojaForRoom : MonoBehaviour
{
    public bool enter;
    [SerializeField, TextArea(4, 6)] public string textOBJ;
    public GameObject canv1;
    public Text tx;
    public bool eliminate;
    public bool activate;

    // Start is called before the first frame update
    void Start()
    {
        canv1.SetActive(false);
        activate = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(enter && FindObjectOfType<player>().GetComponent<player>().B222 == true && !activate)
        {
            FindObjectOfType<player>().GetComponent<player>().B222use = false;
            FindObjectOfType<player>().GetComponent<player>().B222 = false;
            canv1.SetActive(true);
            tx.text = textOBJ;
            Debug.Log("papel");
            activate = true;
            StartCoroutine(delEnemy());
        }


        if (eliminate){ Destroy(gameObject); canv1.SetActive(false); activate = false;}
    }
    private IEnumerator delEnemy()
    {
        yield return new WaitForSeconds(5f);
        eliminate = true;
        Debug.Log("papeldestroy");

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
