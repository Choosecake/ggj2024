using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public GameObject shootingStar;
    void Start()
    {
        AjustarTamanho();
        StartCoroutine(Wait());
    }

    void AjustarTamanho()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer != null)
        {
            float cameraAltura = Camera.main.orthographicSize * 65f;
            float cameraLargura = cameraAltura * Camera.main.aspect;

            Vector2 novaEscala = new Vector2(cameraLargura / spriteRenderer.bounds.size.x, cameraAltura / spriteRenderer.bounds.size.y);

            transform.localScale = novaEscala;
        }
    }


    IEnumerator Wait()
    {
        float randomTime = (Random.Range(8, 15));
        yield return new WaitForSeconds(randomTime);
        Instantiate(shootingStar, new Vector3(Random.Range(-33, 33), Random.Range(14, -14), 9), Quaternion.identity);
        StartCoroutine(Wait());
    }
}
