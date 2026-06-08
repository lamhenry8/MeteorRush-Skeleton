using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private Image totalhealthBar;
    [SerializeField] private Image currenthealthBar;

    private void Start()
    {
        if (totalhealthBar != null)
        {
            totalhealthBar.gameObject.SetActive(true);
            totalhealthBar.enabled = true;
        }

        if (currenthealthBar != null)
        {
            currenthealthBar.gameObject.SetActive(true);
            currenthealthBar.enabled = true;
        }

        UpdateHealthBar();
    }

    private void Update()
    {
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        if (playerHealth == null || totalhealthBar == null || currenthealthBar == null)
        {
            return;
        }

        float maxHealth = Mathf.Max(1f, playerHealth.MaxHealth);
        float fillAmount = Mathf.Clamp01(playerHealth.currentHealth / maxHealth);

        totalhealthBar.fillAmount = 1f;
        currenthealthBar.fillAmount = fillAmount;

        if (currenthealthBar.fillAmount <= 0f)
        {
            currenthealthBar.gameObject.SetActive(false);
        }
    }
}