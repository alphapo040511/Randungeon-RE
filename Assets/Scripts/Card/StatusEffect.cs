using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//효과 종류
public enum EffectType
{
    Buff,                   //버프
    Debuff,                 //디버프
    DamageOverTime,         //지속 피해
    Utility                 //유틸리티 (쉴드, 상태 해제 등)
}


public abstract class StatusEffect : ScriptableObject
{
    [Header("효과 기본 정보")]
    public Sprite icon;                         //효과 아이콘
    public EffectType effectType;               //효과 종류
    public string effectId;                     //식별용 Id
    public string displayName;                  //표시될 이름
    [TextArea] public string description;       //효과 설명

    [Header("효과 수치 정보")]
    public int maxStack;                        //최대 중첩 개수
    public int duration;                        //효과 지속 시간(턴)

    //턴 시작 시 호출
    public virtual void StartTurn(Unit target)
    {
        duration--;                             //턴 시작 시 지속시간이 감소       (EX. 0 턴 남아 있다는건 다음번 상대 차례 때 까지 유지)
        if (duration < 0)                       //지속시간 종료 시 제거
        {
            RemoveEffect(target);
        }

        //상속 받아서 지속 피해 등 효과 적용
        ApplyEffect(target);
    }

    public abstract void ApplyEffect(Unit target);


    public virtual void RemoveEffect(Unit target)
    {
        target.RemoveEffect(effectId);    //이펙트 제거
    }

    //SO를 사용할 거라면 Instantiate(this) 방식이 더 안전.

    //public StatusEffect CloneEffect()
    //{
    //    return (StatusEffect)this.MemberwiseClone(); // 얕은 복사
    //}
}
