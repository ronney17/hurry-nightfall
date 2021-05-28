using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string NomeDaCena;

    public void TrocarCena()
    {
        SceneManager.LoadScene(NomeDaCena);
        Debug.Log("Carregar mundo");
    }

    public void Sair()
    {
        Application.Quit();
        Debug.Log("Sair");
    }
}