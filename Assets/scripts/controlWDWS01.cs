using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class controlWDWS01 : MonoBehaviour
{
    public GameObject img1;
    public Image estateP;
    public Sprite p0;
    public Sprite p1;
    public Sprite p2;
    player a04;
    // Start is called before the first frame update
    void Start()
    {
        a04 = GameObject.FindGameObjectWithTag("player").GetComponent<player>();

    }

    // Update is called once per frame
    void Update()
    {
        if(a04.llave != "noone")
        {
            img1.SetActive(true);
        }
        else
        {
            img1.SetActive(false);
        }

        switch (a04.peligroP)
        {
            case 0:
                estateP.sprite = p0;
                break;
            case 1:
                estateP.sprite = p1;
                break;
            case 2:
                estateP.sprite = p2;
                break;
        }
    }
}
