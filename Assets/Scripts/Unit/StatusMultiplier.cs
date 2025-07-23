using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StatusType
{
    HP,                 //체력
    Attack,             //공격력
    Defense,            //방어력
    CritRate,           //치명타 확률
    CritDamage,         //치명타 데미지 배율
    DamageBonus         //최종 피해 증가
}


public class StatusMultiplier
{
    //각각 스테이터스에 곱연산으로 들어갈 강화 수치
    public float healthMultiplier { get; private set; }         //체력 (곱연산)
    public float attackMultiplier { get; private set; }         //공격력 (곱연산)
    public float defenseMultiplier { get; private set; }        //방어력 (곱연산)
    public float critRateMultiplier { get; private set; }       //치명타 확률 (합연산)
    public float critDamageMultiplier { get; private set; }     //치명타 피해 (합연산)
    public float damageBonusMultiplier { get; private set; }    //피해 강화 (합연산)

    //강화 수치 적용
    public void ApplyStatusEffects(StatusType statusType, float value)
    {
        switch(statusType)
        {
            case StatusType.HP:
                healthMultiplier += value;
                break;
            case StatusType.Attack:
                healthMultiplier += value;
                break;
            case StatusType.Defense:
                healthMultiplier += value;
                break;
            case StatusType.CritRate:
                healthMultiplier += value;
                break;
            case StatusType.CritDamage:
                healthMultiplier += value;
                break;
            case StatusType.DamageBonus:
                healthMultiplier += value;
                break;
        }
    }

    //모든 강화 수치 초기화
    public void ClearStatusMultipliers()
    {
        healthMultiplier = 0;
        attackMultiplier = 0;
        defenseMultiplier = 0;
        critRateMultiplier = 0;
        critDamageMultiplier = 0;
        damageBonusMultiplier = 0;
    }
}
