using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Font : MonoBehaviour
{
    [SerializeField] private float fontSpeed;
    public TMP_FontAsset m_FontAsset;
    public TMP_FontAsset m_FontAsset2;
    public TMP_FontAsset m_FontAsset3;

    public TMP_Text m_Text;


    private int fontCount;

    void Start()
    {
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        fontCount++;
        yield return new WaitForSeconds(fontSpeed);
        switch (fontCount)
        {
            case 0:
                m_Text.font = m_FontAsset;
                break;

            case 1:
                m_Text.font = m_FontAsset2;
                break;
            case 2:
                m_Text.font = m_FontAsset3;
                fontCount = 0;               
                break;
        }
        StartCoroutine(Wait());
    }
}
