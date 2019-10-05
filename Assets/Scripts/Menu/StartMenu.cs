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
    }
}
