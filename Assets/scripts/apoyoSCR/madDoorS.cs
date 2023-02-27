using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class madDoorS : MonoBehaviour
{
    public bool elim;
    // Start is called before the first frame update
    void Start()
    {
        elim = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (elim) { Destroy(gameObject); }
    }
}
