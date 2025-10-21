using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public static HealthBar instance;

    [SerializeField] private Slider slider;
    [SerializeField] private Gradient gradient;
    [SerializeField] private Image fill;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;

        slider = transform.GetComponentInChildren<Slider>();
        fill = transform.Find("Fill/Fill Area/Fill").GetComponent<Image>();
    }

    public void SetMaxHealth(int maxHealth)
    {
        slider.maxValue = maxHealth;
        slider.value = maxHealth;

        gradient.Evaluate(1f);
    }

    public void SetCurrentHealth(int currentHealth)
    {
        slider.value = currentHealth;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public void IncreaseMaxHealth(int amount)
    {
        slider.maxValue += amount;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
