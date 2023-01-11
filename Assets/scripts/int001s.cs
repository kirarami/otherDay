using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class int001s : MonoBehaviour
{
    public bool entro;
    public GameObject imagen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    //este escrip hay que cambiarlo por uno que te de un cuchillo y cierre la puerta para la siguiente vez (depues de la beta)
    void Update()
    {
        if(entro == true )
        {
            if(FindObjectOfType<player>().GetComponent<player>().B222 == true || FindObjectOfType<player>().GetComponent<player>().B111 == true){
                imagen.SetActive(true);
            }
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            entro = true;
            
        }

    }
}
