using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerMovementAudio : MonoBehaviour
{
    public float movementThreshold = 0.1f;  // Velocidade m�nima para considerar o jogador em movimento
    public AudioClip walkingClip;  // Clipe de �udio para o som de caminhada

    private AudioSource audioSource;
    private CharacterController characterController;
    private Vector3 previousPosition;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        characterController = GetComponent<CharacterController>();
        previousPosition = transform.position;
    }

    void Update()
    {
        // Verificar se o jogador est� se movendo
        if (IsPlayerMoving())
        {
            if (!audioSource.isPlaying)
            {
                audioSource.clip = walkingClip;
                audioSource.Play();
            }
        }
        else
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }

        previousPosition = transform.position;
    }

    bool IsPlayerMoving()
    {
        // Calcula a dist�ncia percorrida desde o �ltimo frame
        float distance = Vector3.Distance(transform.position, previousPosition);
        return distance > movementThreshold;
    }
}
