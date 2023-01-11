using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlSCTPPL : MonoBehaviour
{
    public GameObject[] salas;
    public GameObject[] doors;
    //public int IDs;
    public GameObject player1;
    public player player1S;
    // Start is called before the first frame update
    void Start()
    {
       // doors = GameObject.FindGameObjectsWithTag("Doors");
        player1 = GameObject.FindGameObjectWithTag("player");
        player1S = player1.GetComponent<player>();
        //doors[1].GetComponent<>
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Rsalas(int IDs1, int IDs2)
    {
        for (int i = 0; i < salas.Length; i++)
        {
            if (i != IDs1)
            {
                salas[i].SetActive(false);
                Debug.Log("i bloqueo a: " + salas[i].name);
            }
            else
            {
                salas[i].SetActive(true);
                FindObjectOfType<player>().GetComponent<player>().salasIDs = i;
                Debug.Log("i activo a: " + salas[i].name);
            }
        }
        for (int i = 0; i < doors.Length; i++)
        {
            //doors[i].FindGameObjectsWithTag("Doors").GetComponent<DoorCTRL1>();
            if (doors[i].GetComponent<DoorCTRL1>().IDDoor == IDs2)
               {
               Debug.Log("restableciendo posicion de player");
                     Debug.Log("x de door : " + doors[i].transform.position.x);
                     Debug.Log("y de player : " + player1.transform.position.y);
                player1.transform.position = new Vector3(doors[IDs2].transform.position.x, player1.transform.position.y, 0);
               FindObjectOfType<player>().GetComponent<player>().B222 = false;
               FindObjectOfType<player>().GetComponent<player>().rec2 = false;
                break;
               }
            else
            {
                Debug.Log("no se encontro el IDDoor:" + IDs2); 
            }
        }

    } 
}
