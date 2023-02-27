using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activateMOster2 : MonoBehaviour
{
    public bool llaveOBJ;
    public bool entro;
    public GameObject block01;
    public GameObject enemy;
    public GameObject enemyI;
    public bool activateMS;
    public bool mensaje01;
    public bool destroyME;
    public int face;


    // Start is called before the first frame update
    void Start()
    {
        block01.SetActive(false);
        face = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (entro)
        {
            if (FindObjectOfType<player>().GetComponent<player>().llave == "noone") { block01.SetActive(true); Destroy(enemy); face = 1; }
            if (FindObjectOfType<player>().GetComponent<player>().llave != "noone" && face == 1) { block01.SetActive(false); createE(); FindObjectOfType<player>().GetComponent<player>().onT = true; face = 2; }
            if (face == 2) { destroyME = true; Destroy(gameObject); }
        }
    }

    public void createE()
    {
        Vector3 vec = new Vector3(233.53f,-2.30f, 0);
        Instantiate(enemyI, vec, transform.rotation);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            Debug.Log("dentro");
            entro = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            //FindObjectOfType<player>().GetComponent<player>().boton1.SetActive(false);
            entro = false;
            Debug.Log("fuera");
        }

    }
}
