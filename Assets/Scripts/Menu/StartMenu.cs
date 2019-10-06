using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu
{
    public class StartMenu : MonoBehaviour
    {
        public void StartButton()
        {
            SceneManager.LoadScene("Game");
        }

        public void QuitGame()
        {
            Application.Quit();
        }

        public void helpButton()
        {
            SceneManager.LoadScene("HelpMenu");
        }

        public void backButton()
        {
            SceneManager.LoadScene("Menu");
        }

        public void creditsButton()
        {
            SceneManager.LoadScene("Credits");
        }

        public void GameOver()
        {
            SceneManager.LoadScene("GameOver");
        }

        public void tutorial()
        {
            SceneManager.LoadScene("Tutorial");
        }
    }
}
