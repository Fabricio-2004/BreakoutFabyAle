using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;

public class Bola : MonoBehaviour
{
    float paddleOffsetY = 0.4f;
    float velocidad = 7;
    Rigidbody2D rb;
    bool lanzada = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    private void Update()
    {
        if (!lanzada)
            PosicionarSobrePaddle();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Tirar();
        }

    }

    void PosicionarSobrePaddle()
    {
        var paddle = FindObjectOfType<Paddle>();
        var paddlePos = paddle.transform.position;
        transform.position = paddlePos + new Vector3(0, paddleOffsetY, 0);

    }

    void Tirar()
    {
        var dir = new Vector2(1, 1);
        rb.velocity = dir.normalized * velocidad;
        lanzada = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var contacto = collision.GetContact(0);
        rb.velocity = Vector2.Reflect(rb.velocity, contacto.normal);
    }

    public void Reset()
    {
        rb.velocity = new Vector2(0, 0);
        PosicionarSobrePaddle();
        lanzada = false;
    }
}
