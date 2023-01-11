using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class awakeRoom : MonoBehaviour
{
    public float choI001;
    public GameObject P1;
    public Text text1;
    public string[] tips;
    public int tipCount;
    public bool playGame;
    public GameObject canvas1;
    //public GameObject[] findT;
    //public GameObject obj1;
    // Start is called before the first frame update
    void Start()
    {
        choI001 = Random.Range(500f, 1000f);
        generateT();
        playGame = false;
        canvas1.SetActive(false);
        //findT = GameObject.FindGameObjectsWithTag("NPC1");
    }

    // Update is called once per frame
    void Update()
    {
        choI001--;
        if (choI001 <= 0)
        {
            Debug.Log("entro");
            canvas1.SetActive(true);
           // obj1.SetActive(true);
            Destroy(P1);
            playGame = true;
            
        }
        
    }
    public void generateT()
    {
        tipCount = Random.Range(0, tips.Length);
        text1.text = tips[tipCount];
    }
}
