
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class mainmenu : MonoBehaviour
{

    [SerializeField] private GameObject loadingScreen;
    [SerializeField] private GameObject mainMenu;

  

    public void Play()
    {
        mainMenu.SetActive(false);
        loadingScreen.SetActive(true);

       
    }

   




    public void Quit()
    {
        Application.Quit();
        Debug.Log("Oyundan Çýkýþ Yapýlýyor");
    } 
}
