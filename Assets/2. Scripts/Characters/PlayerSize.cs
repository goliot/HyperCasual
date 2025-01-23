using DG.Tweening;
using TMPro;
using UnityEngine;

public class PlayerSize : MonoBehaviour
{
    [SerializeField]
    private TextMeshPro scoreText;

    private float initialFactor = 1.0f;

    private void Update()
    {
        float growthFactor = 1 + (GameManager.Instance.score - 1) * 0.1f;
        if (initialFactor != growthFactor)
        {
            float targetScale = Mathf.Abs(1 + (growthFactor - initialFactor));

            scoreText.transform.parent.DOPunchScale(Vector3.one * targetScale, 0.25f)
                .OnKill(() => scoreText.transform.parent.localScale = Vector3.one* targetScale);
            transform.GetChild(0).DOScale(new Vector3(growthFactor, growthFactor, growthFactor), 0.5f).SetEase(Ease.OutBack);
            initialFactor = growthFactor;
        }
    }
}
