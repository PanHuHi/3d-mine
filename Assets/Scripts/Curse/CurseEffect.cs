using UnityEngine;

public class CurseEffect
{
    private CurseData data;
    private float remainingTime;
    private PlayerStats target;

    public CurseEffect(CurseData data, PlayerStats target)
    {
        this.data = data;
        this.remainingTime = data.duration;
        this.target = target;

        ApplyEffect();
    }

    public bool Update(float deltaTime)
    {
        remainingTime -= deltaTime;
        if (remainingTime <= 0f)
        {
            RemoveEffect();
            return true;
        }
        return false;
    }

    private void ApplyEffect()
    {
        switch (data.curseType)
        {
            case CurseType.HealthDrain:
                target.healthDrainPerSecond += data.power;
                break;
            case CurseType.SpeedDown:
                target.speedMultiplier -= data.power / 100f;
                break;
        }
    }

    private void RemoveEffect()
    {
        switch (data.curseType)
        {
            case CurseType.HealthDrain:
                target.healthDrainPerSecond -= data.power;
                break;
            case CurseType.SpeedDown:
                target.speedMultiplier += data.power / 100f;
                break;
        }
    }

    // ✅ 이름 수정: 클래스와 같은 이름 사용 금지!
    public float HealthDrainPerSecond =>
        data.curseType == CurseType.HealthDrain ? data.power : 0f;
}
