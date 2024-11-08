using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.Requests;
using UnityEngine;

public class Diseño : MonoBehaviour
{
    public List<Bloque> bloquePrefabs;
    List<Bloque> bloques = new List<Bloque>();
    int bloquesDestruidos;

    private void Awake()
    {
        int cols = 11;
        int filas = 5;

        var bloqueSize = bloquePrefabs[0].GetComponent<BoxCollider2D>().size;
        var inicio = new Vector3(bloqueSize.x * -(cols / 2), -1, 0);
        float padding = 0.08f;
        bloqueSize += new Vector2(padding, padding);

        for (int fila = 0; fila < filas; fila++)
        {
            for (int col = 0; col < cols; col++)
            {
                int color = fila;
                var bloque = Instantiate(bloquePrefabs[color]);
                bloque.transform.SetParent(transform);
                bloque.transform.position = new Vector3(col * bloqueSize.x, fila * bloqueSize.y, 0) + inicio;
                bloques.Add(bloque);
            }
        }
    }

    public void BloqueDestruido()
    {
        bloquesDestruidos++;
        if (bloquesDestruidos == bloques.Count)
        {
            FindObjectOfType<Paddle>().Reset();
            FindObjectOfType<Bola>().Reset();
            Reset();

        }
    }

    private void Reset()
    {
        foreach (var bloque in bloques)
        {
            bloque.Reset();
        }
    }
}
