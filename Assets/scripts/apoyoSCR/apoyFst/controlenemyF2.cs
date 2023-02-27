using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class controlenemyF2 : MonoBehaviour
{
    private Animator animator;
    public int mode;
    public GameObject control;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        mode = 0;
        control = GameObject.FindGameObjectWithTag("controlD");
    }

    // Update is called once per frame
    void Update()
    {
        switch (mode)
        {
            case 0:
                animator.SetFloat("anima01", 0);
                cinemachinemovCamera.instance.moverCamara(2, 2, 0.4f);
                if (gameObject.transform.position.x > 218)
                {
                    gameObject.transform.position = new Vector3(gameObject.transform.position.x - 1, gameObject.transform.position.y, gameObject.transform.position.z);
                }
                break;
            case 1:
                if (gameObject.transform.position.x > 218)
                {
                    gameObject.transform.position = new Vector3(gameObject.transform.position.x - 1, gameObject.transform.position.y, gameObject.transform.position.z);
                }
                else if (gameObject.transform.position.x < 218)
                {
                    gameObject.transform.position = new Vector3(218, gameObject.transform.position.y, gameObject.transform.position.z);
                }
                FindObjectOfType<player>().GetComponent<player>().interectiveAllGame = true;
                FindObjectOfType<player>().GetComponent<player>().IDlocal = "corre";
                FindObjectOfType<player>().GetComponent<player>().velocidad = 8;
                break;
            case 2:
                animator.SetFloat("anima01", 1);
                gameObject.transform.position = new Vector3(gameObject.transform.position.x - 0.2f, gameObject.transform.position.y, gameObject.transform.position.z);
                cinemachinemovCamera.instance.moverCamara(1, 1, 0.4f);
                break;
        }
        if (control.GetComponent<controlDAY1>().gameFIN7 == true)
        {
            Destroy(gameObject);
        }


    }

    public void estate01()
    {
        mode = 1;
    }

    public void estate02()
    {
        mode = 2;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("player")){ control.GetComponent<controlDAY1>().gameFIN7 = true; }
       // Destroy(gameObject);
    }
  
}
