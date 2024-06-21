using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class ImageFader : MonoBehaviour
{
    public Image[] images;  // Array de imagens
    public float fadeDuration = 1.0f;  // Duração do fade
    public float waitTime = 0.5f;  // Tempo de espera entre fades

    private int currentImageIndex = 0;

    void Start()
    {
        // Inicializar todas as imagens como desabilitadas, exceto a primeira
        for (int i = 1; i < images.Length; i++)
        {
            images[i].gameObject.SetActive(false);
        }

        StartCoroutine(FadeImage());
    }

    IEnumerator FadeImage()
    {
        while (currentImageIndex < images.Length)
        {
            Image currentImage = images[currentImageIndex];
            currentImage.gameObject.SetActive(true);

            // Aumentar a transparência
            yield return StartCoroutine(FadeTo(currentImage, 1.0f));

            // Reduzir a transparência
            yield return StartCoroutine(FadeTo(currentImage, 0.0f));

            // Desabilitar a imagem atual
            currentImage.gameObject.SetActive(false);

            // Avançar para a próxima imagem
            currentImageIndex++;
        }
    }

    IEnumerator FadeTo(Image image, float targetAlpha)
    {
        float startAlpha = image.color.a;
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float newAlpha = Mathf.Lerp(startAlpha, targetAlpha, elapsedTime / fadeDuration);
            Color newColor = new Color(image.color.r, image.color.g, image.color.b, newAlpha);
            image.color = newColor;
            yield return null;
        }

        // Assegurar que o alpha está no valor final
        Color finalColor = new Color(image.color.r, image.color.g, image.color.b, targetAlpha);
        image.color = finalColor;

        // Espera antes de prosseguir
        yield return new WaitForSeconds(waitTime);
    }
}
