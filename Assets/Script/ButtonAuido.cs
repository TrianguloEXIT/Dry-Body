using UnityEngine;

public class ButtonAuido: MonoBehaviour
{
    public AudioSource audioSource;

    

    // Fun��o para tocar o �udio
    public void PlaySound()
    {
        
            audioSource.Play();
        
    
    }
}
