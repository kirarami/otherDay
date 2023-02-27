using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class apoanimp001 : MonoBehaviour
{
    public GameObject a00;
    animationCtr0 a01;
    // Start is called before the first frame update
    void Start()
    {
        a01 = a00.GetComponent<animationCtr0>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void a001(){
        a01.creditos = false;
    }
}
