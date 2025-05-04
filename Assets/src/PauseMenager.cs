using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenuUI; // Referência ao prefab ou objeto do PauseMenu

    private bool isPaused = false;

    void Start()
    {
        pauseMenuUI.SetActive(false); // Garante que o menu não esteja visível no início
    }

    public void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f; // Pausa o jogo
            pauseMenuUI.SetActive(true);
        }
        else
        {
            Time.timeScale = 1f; // Retoma o jogo
            pauseMenuUI.SetActive(false);
        }
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f;
        pauseMenuUI.SetActive(false);
    }

    public void ReturnToMenu()
    {
        Time.timeScale = 1f; // Retorna o tempo ao normal antes de mudar de cena
        SceneManager.LoadScene("Menu"); // Nome exato da sua cena de Menu
    }
}