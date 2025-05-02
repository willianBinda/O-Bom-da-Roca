using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class EnemyKillUI : MonoBehaviour
{
    public TextMeshProUGUI enemiesKilledText;

    public void AtualizarContador(int count)
    {
        enemiesKilledText.text = "Inimigos: " + count;
    }
}
