using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Iatest : MonoBehaviour
{
    public Transform player; // Referência ao jogador
    public float moveSpeed = 5f; // Velocidade de movimento do inimigo
    public float visionRange = 10f; // Alcance da visão do inimigo
    public LayerMask playerLayer; // Layer do jogador
    public Transform[] patrolPoints; // Pontos de patrulha
    private int currentPatrolIndex = 0; // Índice do ponto de patrulha atual
    public float idleTime = 5f; // Tempo ocioso antes de ir para o próximo ponto
    private float idleTimer = 0f; // Temporizador ocioso
    public Animator Anim;
    public SpriteRenderer spriteRenderer;
    void Update()
    {
        // Verifica se há um jogador dentro do alcance de visão
        RaycastHit2D hit = Physics2D.Raycast(transform.position, player.position - transform.position, visionRange, playerLayer);

        if (hit.collider != null && hit.collider.CompareTag("player"))
        {
            Anim.SetBool("VerPlayer", true);
            if(transform.position.x < player.position.x)
            {
                spriteRenderer.flipX = true;

            }
            else {
                spriteRenderer.flipX = false;

            }
            // Calcula a direção para o jogador
            Vector3 direction = (player.position - transform.position).normalized; // Normaliza para manter a mesma velocidade em qualquer direção

            // Move o inimigo na direção do jogador
            transform.Translate(direction * moveSpeed * Time.deltaTime);

            // Reinicia o temporizador ocioso
            idleTimer = 0f;

            // Reinicia o índice do ponto de patrulha atual
            currentPatrolIndex = 0;

        }
        else
        {
            // Se não encontrar o jogador, inicia o temporizador ocioso
            idleTimer += Time.deltaTime;
            Anim.SetBool("VerPlayer", false);

            if (idleTimer >= idleTime)
            {
                Anim.SetBool("VerPlayer", true);
                // Move o inimigo para o próximo ponto de patrulha mais próximo
                Vector3 directionToTarget = (patrolPoints[currentPatrolIndex].position - transform.position).normalized;
                transform.Translate(directionToTarget * moveSpeed * Time.deltaTime);

                // Verifica se o inimigo chegou ao ponto de patrulha
                if (Vector3.Distance(transform.position, patrolPoints[currentPatrolIndex].position) < 0.1f)
                {
                    Anim.SetBool("VerPlayer", false);
                    // Se chegou ao ponto de patrulha, incrementa o índice do ponto de patrulha atual
                    currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;

                    // Reinicia o temporizador ocioso
                    idleTimer = 0f;
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Desenha o alcance da visão do inimigo no editor Unity
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, visionRange);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "player")
        {
            SceneManager.LoadScene("Principal");

        }
    }
}
