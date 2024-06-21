using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Galho : MonoBehaviour
{
    public AudioClip collisionSound; // �udio a ser reproduzido quando ocorrer uma colis�o com um objeto "player"

    private bool hasPlayed = false; // Vari�vel para garantir que o som seja reproduzido apenas uma vez

    public Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D Collider)
    {
        // Verifica se o objeto de colis�o possui a tag "player" e se o som ainda n�o foi reproduzido
        if (Collider.gameObject.CompareTag("player") && !hasPlayed)
        {
            // Obt�m o componente AudioSource deste objeto
            AudioSource audioSource = GetComponent<AudioSource>();

            // Verifica se h� um AudioSource anexado e um AudioClip configurado
            if (audioSource != null && collisionSound != null)
            {
                // Define o AudioClip no AudioSource
                audioSource.clip = collisionSound;

                // Reproduz o som
                audioSource.Play();
                anim.SetBool("GalhoBrokee", true);
                // Define a vari�vel hasPlayed como true para garantir que o som seja reproduzido apenas uma vez
                hasPlayed = true;
            }
            else
            {
                // Se n�o houver AudioSource anexado ou AudioClip configurado, exibe um aviso no console
                Debug.LogWarning("O objeto n�o possui um AudioSource anexado ou um AudioClip configurado.");
            }
        }
    }
}