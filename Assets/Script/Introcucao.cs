using System.Collections;
using System.Collections.Generic;

using UnityEngine;
public class Introcucao : MonoBehaviour
{
    public GameObject Fechar;
    void Start()
    {
        Invoke("Comeca", 35);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)){

            Comeca();
        }
    }
    public void Comeca()
    {

            Fechar.SetActive(false);

    }
}
