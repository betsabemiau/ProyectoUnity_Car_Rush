using UnityEngine;
using UnityEngine.SceneManagement;

public class botton_manager : MonoBehaviour
{
   public void Reiniciar()
    {
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Jugar()
    {
        SceneManager.LoadScene(1);
    }
}
