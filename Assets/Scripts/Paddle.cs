using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    float velocidad = 0.4f;
    float limite = 7.5f;

    private void FixedUpdate() {
        var pos = transform.position;
        if (Input.GetKey(KeyCode.RightArrow)) {
            pos.x += velocidad;
            if (pos.x > limite){
                pos.x = limite;
            }

            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                pos.x -= velocidad;
                if (pos.x < -limite) { pos.x = -limite; }
            }
            transform.position = pos;

        }

    public void Reset()
    {
        var pos = transform.position;
        pos.x = 0;
        transform.position = pos;
    }
}







