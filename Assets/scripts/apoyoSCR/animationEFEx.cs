using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class animationEFEx : MonoBehaviour
{
    [SerializeField] public Vector2 velocidadM;
    private Vector2 offcet;
    private Material material;
    public GameObject vanc01;
    public GameObject padre;
    //                                                         este codigo no funciona o no se que hacer mejor lo dejo para otro dia
    // Start is called before the first frame update
    private void Awake()
    {
        material = GetComponent<Image>().material;
    }
    void Start()
    {
        padre.GetComponent<Canvas>().sortingOrder = 190;
        vanc01 = GameObject.Find("aviso");
    }

    // Update is called once per frame
    void Update()
    {
        vanc01 = GameObject.Find("aviso");
        //Debug.Log("encontrado canvas :" + vanc01.name);
        if(vanc01)
        {
           padre.GetComponent<Canvas>().sortingLayerID = -235;
        }
        else
        {
           padre.GetComponent<Canvas>().sortingLayerID = -235;
        }
        offcet = velocidadM * Time.deltaTime;
        material.mainTextureOffset += offcet;
    }
}
