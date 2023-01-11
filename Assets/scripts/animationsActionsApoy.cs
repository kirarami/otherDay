using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class animationsActionsApoy : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator anim001;
    void Start()
    {
        anim001 = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void upANIMATION0()
    {
        anim001.SetFloat("animApoy001",1);
    }

}
