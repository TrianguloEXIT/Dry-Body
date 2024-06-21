using System.Collections;
using System.Collections.Generic;

using UnityEngine;
public class RayObjects : MonoBehaviour
{
    public float raioDistancia = 10f; // Distância máxima do raio
    public LayerMask mascara; // Máscara de camadas para o raio
    public GameObject E_Interagir;
    public Animator anim;
    public test Test;
    public GameObject Lanterna, Lantern2,Lanterna3;
    public BoxCollider2D boxCollider2D;
    public SpriteRenderer spriteRenderer;
    public bool escondido = false;
    public GameObject Entidade,Texto1,Texto2,Texto3,Gasolina,Galao1, Galao2, Galao3, Galao4, Galao5;


    private void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        
        // Obtém a posição e a direção do raio
        Vector2 posicaoRaio = transform.position; // Posição do objeto do jogador
        Vector2 direcaoRaio = transform.up; // Direção do raio (para cima)

        // Declara uma variável para armazenar informações sobre a colisão
        RaycastHit2D hit = Physics2D.Raycast(posicaoRaio, direcaoRaio, raioDistancia, mascara);

        // Verifica se o raio atingiu um objeto
        if (hit.collider != null)
        {   
            
            // O raio atingiu um objeto
            Debug.DrawRay(posicaoRaio, direcaoRaio * hit.distance, Color.yellow);

            // Verifica se o objeto atingido possui a tag "interable"
            if (hit.collider.gameObject.layer == 3f)
            {
                // Objeto com a tag "interable" foi atingido

                E_Interagir.SetActive(true);
                // Adicione aqui o código para lidar com o objeto interativo
                if (Input.GetKeyDown(KeyCode.E))
                {

                    if (escondido == true){
                        spriteRenderer.enabled = (true);
                        boxCollider2D.enabled = (true);
                        Lantern2.SetActive(true);
                        Lanterna3.SetActive(true);
                        Test.moveSpeed = 5f;
                        escondido = false;
                    }
                   else if (hit.collider.gameObject.name == "Lanterna")
                    {
                        Test.Terlanterna = (true);
                        Lantern2.SetActive(true);
                        
                        Texto1.SetActive(false);
                        Texto2.SetActive(true);
                        Lanterna.SetActive(false);
                        Entidade.SetActive(true);
                        Invoke("TrocarTexto", 14);

                    }

                    else if (hit.collider.gameObject.tag == "Arbusto")
                    {
                        spriteRenderer.enabled = (false);
                        boxCollider2D.enabled = (false);
                        Lantern2.SetActive(false);
                        Lantern2.SetActive(false);
                        Test.moveSpeed = 0f;
                        escondido = true;
                      
                    }
                


                }

            }
        }
        else
        {
            // O raio não atingiu nenhum objeto
            Debug.DrawRay(posicaoRaio, direcaoRaio * raioDistancia, Color.white);
            E_Interagir.SetActive(false);
        }


    }

    public void TrocarTexto()
    {

        Texto2.SetActive(false);
        Texto3.SetActive(true);
        Invoke("TrocarGasolina", 5);

    }

public void TrocarGasolina()
    {
        Texto3.SetActive(false);
        Gasolina.SetActive(true);
        Galao1.SetActive(true);
        Galao2.SetActive(true);
        Galao3.SetActive(true);
        Galao4.SetActive(true);
        Galao5.SetActive(true);


    }

}