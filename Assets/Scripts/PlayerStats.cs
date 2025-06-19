using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("ü��")]
    public float maxHealth = 100f;
    public float currentHealth = 100f;
    public float healthDrainPerSecond = 0f;

    [Header("���¹̳�")]
    public float maxStamina = 100f;
    public float currentStamina = 100f;

    [Header("�̵�")]
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
