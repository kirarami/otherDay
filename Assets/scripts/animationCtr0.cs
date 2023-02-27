using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationCtr0 : MonoBehaviour
{
    private float choI001;
    private float choI002;
    private bool apo001;
    private Animator _animator;
    public GameObject vent;
    public bool creditos;
    public GameObject creditoss;
    // Start is called before the first frame update
    void Start()
    {
        choI001 = Random.Range(0f,200f);
        choI002 = Random.Range(0f, 20f);
        apo001 = false;
        _animator = GetComponent<Animator>();
        creditos = false;
        creditoss.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(apo001 == false) { choI001--; }

        if(choI001 <= 0)
        {
            _animator.SetFloat("A001", 1);
            apo001 = true;
        }

        if (apo001 == true) { choI002--; }

        if(choI002 <= 0)
        {
            _animator.SetFloat("A001", 0);
            apo001 = false;
            choI001 = Random.Range(0f, 200f);
            choI002 = Random.Range(0f, 20f);
        }
        if (!creditos)
        {
            vent.SetActive(true);
            this.gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
            creditoss.SetActive(false);
        }
    }
    public void credi()
    {
        creditos = true;
        vent.SetActive(false);
        this.gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        creditoss.SetActive(true);
    }
}
