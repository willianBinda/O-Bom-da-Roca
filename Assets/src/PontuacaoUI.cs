using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PontuacaoUI : MonoBehaviour
{
    public TextMeshProUGUI pontuacao;

    public void AtualizarPontuacao(int pontuacaoAtual)
    {
        pontuacao.text = "Pontuação: " + pontuacaoAtual.ToString();
    }
}
