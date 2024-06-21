using UnityEngine;
using TMPro;  // Namespace necessário para trabalhar com TextMeshPro

public class DialogoFinal : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;  // Referência ao TextMeshProUGUI
    public GameObject objetoParaAtivar;  // Objeto a ser ativado
    public string valorEsperado = "5";  // Valor esperado no TextMeshPro

    void Update()
    {
        // Verifica se o texto do TextMeshPro é igual ao valor esperado
        if (textMeshPro.text == valorEsperado)
        {
            // Ativa o objeto
            objetoParaAtivar.SetActive(true);
        }
        else
        {
            // Opcional: Desativa o objeto se o valor não corresponder
            objetoParaAtivar.SetActive(false);
        }
    }
}
