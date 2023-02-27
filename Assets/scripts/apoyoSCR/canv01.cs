using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;
using TMPro;

public class canv01 : MonoBehaviour
{

    public Image img01;
    public TMP_Text txt01;
    public iniciPcNMOs01 padre;
    private Animator animationn;
    // Start is called before the first frame update
    void Start()
    {
        padre = GetComponent<iniciPcNMOs01>();
        animationn = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void botonp01()
    {
        animationn.SetFloat("flo01", 1);
        fin1MO();
    }
    public void iniciMO()
    {
        FindObjectOfType<iniciPcNMOs01>().GetComponent<iniciPcNMOs01>().inc = true;
        FindObjectOfType<player>().GetComponent<player>().onT = false;
    }
    public void fin1MO()
    {
        Destroy(img01);
        Destroy(txt01);
    }
    public void fin2MO()
    {
        FindObjectOfType<iniciPcNMOs01>().GetComponent<iniciPcNMOs01>().eliminate = true;
        Destroy(gameObject);
    }
}
