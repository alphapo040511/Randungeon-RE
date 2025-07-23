using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Stat Modifier Effect", menuName = "Effect/Stat Modifier Effect")]
public class StatModifierEffect : StatusEffect
{
    [Header("스테이터스 버프 설정")]
    public StatusType statusType;                   //버프할 스테이터스 타입
    public float value;                             //버프할 크기

    public override void ApplyEffect(Unit target)
    {
        target.modifiedStatus.ApplyStatusEffects(statusType, value); 
    }
}
