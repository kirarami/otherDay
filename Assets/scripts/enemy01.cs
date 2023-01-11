using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class enemy01 : MonoBehaviour
{
    public int estate;
    public new Animator animation;
    public bool encontrado;
    public bool casado;
    public string lade;
    public bool destruir;

    // Start is called before the first frame update
    void Start()
    {
        encontrado = false;
        animation = GetComponent<Animator>();
        estate = 0;
        casado = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (casado == true) { estate = 4; }
        if(destruir == true)
        {
            FindObjectOfType<player>().GetComponent<player>().peligroP = 0;
            Destroy(gameObject);
        }
        if (encontrado && estate == 0){
            float xplayer = FindObjectOfType<player>().GetComponent<player>().transform.position.x;
            Debug.Log(xplayer);
            if (gameObject.transform.position.x >= xplayer)
            {
                gameObject.transform.position += new Vector3(-1, 0, 0) * Time.deltaTime;
            }
            if (gameObject.transform.position.x <= xplayer)
            {
                gameObject.transform.position += new Vector3(+1, 0, 0) * Time.deltaTime;
            }
            if(lade == "izquierda" && gameObject.transform.position.x >= xplayer)
            {
                estate = 1;
            }
            if (lade == "derecha" && gameObject.transform.position.x <= xplayer)
            {
                estate = 1;
            }
        }
        switch (estate)
        {
            case 0:
                animation.SetFloat("estateEvilanim01", 0);
                if(lade == "derecha")
                {
                    gameObject.transform.position += new Vector3(-6, 0, 0)* Time.deltaTime;
                }
                else
                {
                    gameObject.transform.position += new Vector3(+6, 0, 0) * Time.deltaTime;
                }
                FindObjectOfType<player>().GetComponent<player>().peligroP = 1;
                break;
            case 1:
                animation.SetFloat("estateEvilanim01", 1);
                break;
            case 2:
                animation.SetFloat("estateEvilanim01", 2);
                FindObjectOfType<player>().GetComponent<player>().peligroP = 2;
                if (FindObjectOfType<player>().GetComponent<player>().left == true || FindObjectOfType<player>().GetComponent<player>().right == true)
                {
                    casado = true;
                }
                StartCoroutine(delEnemy());
                break;
            case 3:
                if (casado == false)
                {
                    animation.SetFloat("estateEvilanim01", 3);
                }
                break;
            case 4:
                animation.SetFloat("estateEvilanim01", 4);
                FindObjectOfType<player>().GetComponent<player>().onT = true;
                break;

        }
    }


    public void buscarTrue()
    {
        estate = 2;
    }
    public void delEnemyComp()
    {
        FindObjectOfType<controlEnemy01>().GetComponent<controlEnemy01>().StartCooru();
        Debug.Log("destruyendo y iniciando cuenta de 10 segundos");
        destruir = true;
    }
    private IEnumerator delEnemy()
    {
        yield return new WaitForSeconds(5f);
        if(casado == false)
        {
            estate = 3;
        }
    }

    public void gamequit()
    {
        Application.Quit();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            //FindObjectOfType<player>().GetComponent<player>().boton1.SetActive(true);
            encontrado = true;
        }

    }
    
}
