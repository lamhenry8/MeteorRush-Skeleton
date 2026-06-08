using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth = 3f;
    public float currentHealth { get; private set; }
    public float MaxHealth => Mathf.Max(startingHealth, 3f);

    private Animator anim;
    private bool dead;
    private GameManager gameManager;


    private void Awake()
    {
        startingHealth = Mathf.Max(startingHealth, 3f);
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        gameManager = FindObjectOfType<GameManager>();
    }

    public void TakeDamage(float damage)
    {
        if (dead)
        {
            return;
        }

        currentHealth = Mathf.Clamp(currentHealth - damage, 0f, MaxHealth);

        if (currentHealth > 0f)
        {
            if (anim != null)
                {
                    anim.SetTrigger("hurt");
                }

            return;
        }

        if (!dead)
        {
            dead = true;

            if (anim != null)
            {
                anim.SetTrigger("die");
            }

            PlayerController playerController = GetComponent<PlayerController>();
            if (playerController != null)
            {
                playerController.enabled = false;
            }

            if (gameManager != null)
            {
                gameManager.GameOver();
            }
        }
    }

    public void AddHealth(float amount)
    {
        if (dead)
        {
            return;
        }

        currentHealth = Mathf.Clamp(currentHealth + amount, 0f, MaxHealth);
    }
}