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
        if (Mathf.Abs(initialFactor - growthFactor) > Mathf.Epsilon) // 값 비교 정확성 보장
        {
            float targetScale = Mathf.Abs(1 + (growthFactor - initialFactor));

            // 스케일 애니메이션
            //scoreText.transform.parent.DOPunchScale(Vector3.one * targetScale, 0.25f)
            //    .OnComplete(() => scoreText.transform.parent.localScale = Vector3.one * targetScale);

            scoreText.transform.parent.DOScale(new Vector3(growthFactor, growthFactor, growthFactor), 0.5f)
                .SetEase(Ease.OutSine);
            transform.DOScale(new Vector3(growthFactor, growthFactor, growthFactor), 0.5f)
                .SetEase(Ease.OutBack);

            initialFactor = growthFactor;
        }
    }
}
