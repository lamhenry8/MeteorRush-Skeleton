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
       if (playerHealth.currentHealth == 3)
    currenthealthBar.fillAmount = 1f;
else if (playerHealth.currentHealth == 2)
    currenthealthBar.fillAmount = 0.6667f;
else if (playerHealth.currentHealth == 1)
    currenthealthBar.fillAmount = 0.3333f;
else
    currenthealthBar.fillAmount = 0f;
    }
}