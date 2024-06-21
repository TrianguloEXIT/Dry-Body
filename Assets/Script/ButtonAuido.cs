using UnityEngine;

public class ButtonAuido: MonoBehaviour
{
    public AudioSource audioSource;

    

    // Função para tocar o áudio
    public void PlaySound()
    {
        
            audioSource.Play();
        
    
    }
}
