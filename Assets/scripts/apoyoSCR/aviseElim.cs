using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aviseElim : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(activate1());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator activate1()
    {
        yield return new WaitForSecondsRealtime(10.0f);
        Destroy(gameObject);

    }
}
