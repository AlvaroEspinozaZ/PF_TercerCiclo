using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class HealthBarController : MonoBehaviour
{
    [SerializeField] public float maxValue;
    [Header("Health Bar Visual Components")]
    [SerializeField] private RectTransform healthBar;
    [SerializeField] private RectTransform modifiedBar;
    [SerializeField] private float changeSpeed;

    public float currentValue;
    private float _fullWidth;
    private float TargetWidth => currentValue * _fullWidth / maxValue;
    private Coroutine updateHealthBarCoroutine;
    public event Action onDeath;

    private void Start()
    {
        _fullWidth = healthBar.rect.width;
    }
    public void SetCurrentLife(float maxvalue)
    {
        this.currentValue = maxvalue;       
    }
    public void SetMaxLife(float maxvalue)
    {
        this.maxValue = maxvalue;
    }
    public void UpdateHealth(float amount)
    {
        currentValue = Mathf.Clamp(currentValue + amount, 0, maxValue);

        if (updateHealthBarCoroutine != null)
        {
            StopCoroutine(updateHealthBarCoroutine);
        }
        updateHealthBarCoroutine = StartCoroutine(AdjustWidthBar(amount));
        if (currentValue <= 0)
        {
            onDeath?.Invoke();
        }
    }

    IEnumerator AdjustWidthBar(float amount)
    {
        RectTransform targetBar = amount >= 0 ? modifiedBar : healthBar;
        RectTransform animatedBar = amount >= 0 ? healthBar : modifiedBar;

        targetBar.sizeDelta = SetWidth(targetBar, TargetWidth);

        while (Mathf.Abs(targetBar.rect.width - animatedBar.rect.width) > 1f)
        {
            animatedBar.sizeDelta = SetWidth(animatedBar, Mathf.Lerp(animatedBar.rect.width, TargetWidth, Time.deltaTime * changeSpeed));
            yield return null;
        }

        animatedBar.sizeDelta = SetWidth(animatedBar, TargetWidth);
    }

    private Vector2 SetWidth(RectTransform t, float width)
    {
        return new Vector2(width, t.rect.height);
    }
}
