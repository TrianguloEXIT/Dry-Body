using UnityEngine;
using TMPro;  // Namespace necess�rio para trabalhar com TextMeshPro

public class DialogoFinal : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;  // Refer�ncia ao TextMeshProUGUI
    public GameObject objetoParaAtivar;  // Objeto a ser ativado
    public string valorEsperado = "5";  // Valor esperado no TextMeshPro

    void Update()
    {
        // Verifica se o texto do TextMeshPro � igual ao valor esperado
        if (textMeshPro.text == valorEsperado)
        {
            // Ativa o objeto
            objetoParaAtivar.SetActive(true);
        }
        else
        {
            // Opcional: Desativa o objeto se o valor n�o corresponder
            objetoParaAtivar.SetActive(false);
        }
    }
}
