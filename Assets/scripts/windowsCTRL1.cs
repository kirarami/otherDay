using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class windowsCTRL1 : MonoBehaviour
{
    [SerializeField] Image imagestate;
    [SerializeField] Sprite spritestate;

    public GameObject GB01;
    public GameObject GB02;
    // Start is called before the first frame update
    void Start()
    {
        imagestate.sprite = spritestate;
    }

    // Update is called once per frame
    void Update()
    {
        if(FindObjectOfType<awakeRoom>().playGame == true)
        {
            ifActive();
        }
    }

    public void ifActive()
    {
        GB01.SetActive(true);
        GB02.SetActive(true);
    }
}
