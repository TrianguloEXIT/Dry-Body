using UnityEngine;

public class BotaoWeb : MonoBehaviour
{
    // URL que será aberta
    public string Linkedin = "https://www.example.com";
    public string Git = "https://www.example.com";
    public string Itch = "https://www.example.com";

    // Função que abre a URL
    public void AbrirLinkedin()
    {
        Application.OpenURL(Linkedin);
    }

    public void AbrirGit()
    {
        Application.OpenURL(Git);
    }

    public void AbrirItch()
    {
        Application.OpenURL(Itch);
    }
}
