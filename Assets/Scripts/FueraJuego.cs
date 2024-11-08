using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FueraJuego : MonoBehaviour
{
    private int resetCounter = 0;
    private int maxResets = 3;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        FindObjectOfType<Bola>().Reset();
        FindObjectOfType<Paddle>().Reset();

        resetCounter++;

        if (resetCounter >= maxResets)
        {
            SceneManager.LoadScene("JuegoTerminado");
        }
    }

    private void Update()
    {
        if (GameObject.FindObjectsOfType<Bloque>().Length == 0)
        {
            SceneManager.LoadScene("JuegoTerminado");
        }
    }
}
