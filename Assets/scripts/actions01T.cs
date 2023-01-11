using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Animations;

public class actions01T : MonoBehaviour
{
    //objs actions 
    public GameObject[] OBJanimS;
    // Start is called before the first frame update
    void Start()
    {
        OBJanimS =  GameObject.FindGameObjectsWithTag("NPC1");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Lib_actionsUni0(string g)
    {
        switch (g)
        {
            case "anim_Sprite_choose1":
                for(int i = 0; i < OBJanimS.Length; i++)
                {
                    OBJanimS[i].GetComponent<Dialoge>().action01 = 1;
                }
                break;


        }
    }
}
