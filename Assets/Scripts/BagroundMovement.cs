using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagroundMovement : MonoBehaviour
{
    public float intensidadeMovimento = 0.1f;
    public float velocidadeMovimento = 1.0f;

    private Vector3 posicaoInicial;

    void Start()
    {
        posicaoInicial = transform.position;
    }

    void Update()
    {
        float movimentoX = Mathf.Sin(Time.time * velocidadeMovimento) * intensidadeMovimento;
        float movimentoY = Mathf.Cos(Time.time * velocidadeMovimento) * intensidadeMovimento;

        Vector3 movimento = new Vector3(movimentoX, movimentoY, 0f);
        transform.position = posicaoInicial + movimento;
    }
}
