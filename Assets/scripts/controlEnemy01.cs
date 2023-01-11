using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlEnemy01 : MonoBehaviour
{
    public bool enemyStart;
    public GameObject enemy;
    public string lades;
    public bool crear;
    public bool mandar;
    // Start is called before the first frame update
    void Start()
    {
        mandar = true;
        //StartCoroutine(crearE());
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyStart == true)
        {
           if(mandar == true)
            {
                crearEvil();
            }
        }

    }
    public void crearEvil()
    {
        float x = Random.Range(0, 100);
        if (x > 50)
        {
            lades = "derecha";
            Vector3 vec = new Vector3(FindObjectOfType<player>().GetComponent<player>().transform.position.x + 32, transform.position.y, 0);
            Instantiate(enemy, vec, transform.rotation);
            enemy01 v1 = GameObject.FindGameObjectWithTag("enemy").GetComponent<enemy01>();
            v1.lade = lades;
        }
        else
        {
            lades = "izquierda";
            Vector3 vec = new Vector3(FindObjectOfType<player>().GetComponent<player>().transform.position.x - 32, transform.position.y, 0);
            Instantiate(enemy, vec, transform.rotation);
            enemy01 v1 = GameObject.FindGameObjectWithTag("enemy").GetComponent<enemy01>();
            v1.lade = lades;
        }
        mandar = false;
    }
    public void StartCooru()
    {
        StartCoroutine(crearE());
    }
    private IEnumerator crearE()
    {
        yield return new WaitForSeconds(5f);
        mandar = true;
    }
}
