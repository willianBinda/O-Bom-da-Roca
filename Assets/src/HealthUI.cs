using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class HealthUI : MonoBehaviour
{
    public TextMeshProUGUI vidaText;

    public void AtualizarVida(int vidaAtual)
    {
        vidaText.text = "Vida: " + vidaAtual.ToString();
    }
}
