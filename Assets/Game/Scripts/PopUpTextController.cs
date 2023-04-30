using DG.Tweening;
using TMPro;
using UnityEngine;

public class PopUpTextController : MonoBehaviour
{
    private TextMeshPro _textMeshPro;

    private void Awake()
    {
        _textMeshPro = GetComponent<TextMeshPro>();
    }

    private void Start()
    {
        _textMeshPro.DOFade(0.0f, 2.0f).OnComplete(() =>
        {
            Destroy(gameObject);
        });
    }

    public void SetText(string text)
    {
        _textMeshPro.SetText(text);
    }
}
