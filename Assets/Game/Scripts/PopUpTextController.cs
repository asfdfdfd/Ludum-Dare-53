using DG.Tweening;
using TMPro;
using UnityEngine;

public class PopUpTextController : MonoBehaviour
{
    [SerializeField] private TextMeshPro _textMeshPro;

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
