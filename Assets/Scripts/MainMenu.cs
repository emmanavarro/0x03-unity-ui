using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenu : MonoBehaviour
{
    public Material trapMat;
    public Material goalMat;
    public Toggle colorblindMode;
    public Accesability colorMode;

    public void PlayMaze()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        if (colorMode.value)
        {
            trapMat.color = new Color32(255, 112, 0, 1);
            goalMat.color = Color.blue;
        }
        else
        {
            trapMat.color = Color.red;
            goalMat.color = Color.green;
        }
    }

    public void QuitMaze()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }

    public void SetAccessability()
    {
        colorMode.value = colorblindMode.isOn;
    }

    private void Start()
    {
        colorMode.value = default;
    }
}
