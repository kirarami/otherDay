using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class ManaGScene : MonoBehaviour
{
    public bool pasarNivel;
    public int indiceNivel;
    public int mode;
    
    // Start is called before the first frame update
    void Start()
    {
        if(mode != 0)
        {
            modeROom();
        }
    }
    private void modeROom()
    {
        Invoke("cambiarNivel01", 3f);
    }
    //principal
    public void cambiarNivel(int indice)
    {
        SceneManager.LoadScene(indice);
    }


    public void cambiarNivel01()
    {
        SceneManager.LoadScene(mode);
    }

    //otros
    IEnumerator time01(int number)
    {
        yield return new WaitForSeconds(number);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
