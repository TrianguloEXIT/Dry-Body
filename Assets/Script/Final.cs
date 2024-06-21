using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using TMPro;

public class Final : MonoBehaviour
{
    public TMP_Text textoTMP;
    public GameObject Entidade, Player,Finall;
    private void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "player")
        {
            if (textoTMP != null && int.TryParse(textoTMP.text, out int valor) && valor == 5)
            {
                Entidade.SetActive(false);
                Player.SetActive(false);
                Finall.SetActive(true);
            }

        }



    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
