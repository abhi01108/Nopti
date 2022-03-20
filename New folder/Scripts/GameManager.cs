using UnityEngine.SceneManagement;
using UnityEngine;
public class GameManager : MonoBehaviour
{
     
    //public GameObject escmenu;
    public void StartMatch()
    {
        SceneManager.LoadScene("Map1");
    }
     
    public void ExitGame()
    {
        Application.Quit();
    }
    public void Options()
    {
        SceneManager.LoadScene("Options");
    }
    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }
   
    public void BackToMap1fromMap1Menu()
    {
        SceneManager.LoadScene("Map1");
    }
     
    //public void Respawn()
    //{
    //Instantiate(spawnObject, spawnpoint);
    //}

    //private void Start()
    //{
    //    escmenu.SetActive(false);

    //}
    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.V) && escmenu==false)
    //    {
    //        escmenu.SetActive(true);
    //    }
    //    if (Input.GetKeyDown(KeyCode.V) && escmenu == true)
    //    {
    //        escmenu.SetActive(false);
    //    }

    //}
}
