using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("체력")]
    public float maxHealth = 100f;
    public float currentHealth = 100f;
    public float healthDrainPerSecond = 0f;

    [Header("스태미너")]
    public float maxStamina = 100f;
    public float currentStamina = 100f;

    [Header("이동")]
    public float speedMultiplier = 1f;

    private void Update()
    {
        if (healthDrainPerSecond > 0f)
        {
            currentHealth -= healthDrainPerSecond * Time.deltaTime;
            currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
        }
    }
}
