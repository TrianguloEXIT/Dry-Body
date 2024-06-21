using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Gasolina : MonoBehaviour
{
    private SpriteRenderer SR;
    private BoxCollider2D Circle;
    public GameObject Colected;
    public int Score;
    private AudioSource audioSource;
    public Final final;
    public bool Gasolina1, Gasolina2, Gasolina3, Gasolina4, Gasolina5;

    // Start is called before the first frame update
    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
        Circle = GetComponent<BoxCollider2D>();
        audioSource = GetComponent<AudioSource>();

    }




    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "player")
        {
            SR.enabled = false;
            Circle.enabled = false;
            Colected.SetActive(true);
            GameController.instance.TotalScore += Score;
            GameController.instance.UpdateScoreText();
            audioSource.Play();
         
            Destroy(gameObject, 0.70f);

            
        }



    }
}
