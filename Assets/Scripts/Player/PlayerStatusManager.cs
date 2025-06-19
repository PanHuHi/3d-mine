using UnityEngine;
using UnityEngine.UI;

public class PlayerStatusManager : MonoBehaviour
{
    [Header("🧍‍♂️ 플레이어 상태 참조")]
    public PlayerStats playerStats;

    [Header("📊 UI 슬라이더")]
    public Slider healthSlider;
    public Slider staminaSlider;

    [Header("🔋 스태미너 회복 설정")]
    public float staminaRegenRate = 5f; // 초당 회복량

    private void Start()
    {
        // 초기 체력 및 스태미너 설정
        playerStats.currentHealth = playerStats.maxHealth;
        playerStats.currentStamina = playerStats.maxStamina;

        UpdateUI();
    }

    private void Update()
    {
        RegenerateStamina();
        UpdateUI();
    }

    private void RegenerateStamina()
    {
        if (playerStats.currentStamina < playerStats.maxStamina)
        {
            playerStats.currentStamina += staminaRegenRate * Time.deltaTime;
            playerStats.currentStamina = Mathf.Clamp(playerStats.currentStamina, 0f, playerStats.maxStamina);
        }
    }

    private void UpdateUI()
    {
        if (healthSlider != null)
        {
            healthSlider.maxValue = playerStats.maxHealth;
            healthSlider.value = playerStats.currentHealth;
        }

        if (staminaSlider != null)
        {
            staminaSlider.maxValue = playerStats.maxStamina;
            staminaSlider.value = playerStats.currentStamina;
        }
    }

    // 외부에서 데미지를 줄 수 있는 메서드
    public void TakeDamage(float amount)
    {
        playerStats.currentHealth -= amount;
        playerStats.currentHealth = Mathf.Clamp(playerStats.currentHealth, 0f, playerStats.maxHealth);
    }

    // 외부에서 스태미너 소비
    public void UseStamina(float amount)
    {
        playerStats.currentStamina -= amount;
        playerStats.currentStamina = Mathf.Clamp(playerStats.currentStamina, 0f, playerStats.maxStamina);
    }
}
