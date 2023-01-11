using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationCtr0 : MonoBehaviour
{
    private float choI001;
    private float choI002;
    private bool apo001;
    private Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        choI001 = Random.Range(0f,200f);
        choI002 = Random.Range(0f, 20f);
        apo001 = false;
        _animator = GetComponent<Animator>();
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
    }
}
