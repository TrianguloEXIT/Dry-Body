using UnityEngine;
using TMPro;

public class Contador : MonoBehaviour
{
    public TextMeshProUGUI textoContador;
    public int contadorInicial = 8;
    public bool iniciarContador = false;

    private int contadorAtual;
    private bool contadorIniciado = false;

    void Start()
    {
        if (iniciarContador && !contadorIniciado)
        {
            contadorAtual = contadorInicial;
            AtualizarTextoContador();
            // Começar a contagem regressiva
            InvokeRepeating("ContagemRegressiva", 1f, 1f);
            contadorIniciado = true;
        }
    }

    void ContagemRegressiva()
    {
        contadorAtual--;
        AtualizarTextoContador();
        if (contadorAtual <= 0)
        {
            // Se o contador chegar a 0, pare a contagem regressiva
            CancelInvoke("ContagemRegressiva");
        }
    }

    void AtualizarTextoContador()
    {
        // Atualiza o texto no TextMeshPro com o valor do contador atual
        textoContador.text = contadorAtual.ToString();
    }
}
