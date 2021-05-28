using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameController : MonoBehaviour
{
    public Text textoPontuacao;
    public Player player;
    Vector3 startPosition;
    public GameObject painelGameOver;
    void Start()
    {
        startPosition = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 distanciaPercorrida = player.transform.position - startPosition;
        float pontuacao = distanciaPercorrida.z;
        textoPontuacao.text = pontuacao.ToString("0");
    }

    public void GameOver()
    {
        painelGameOver.SetActive(true);
        Invoke("recarregarLevel", 2);
    }

    public void recarregarLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}