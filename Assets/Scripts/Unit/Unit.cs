using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unit : MonoBehaviour
{
    [Header("유닛의 데이터")]
    public UnitBaseStatus baseStatus;               //해당 유닛의 베이스 스테이터스 정보
    public StatusMultiplier modifiedStatus;         //해당 유닛의 스테이터스 버프 정보

    [Header("효과 데이터")]
    private List<StatusEffect> statusEffects;       //상태 효과

    [Header("체력 관련 수치")]
    private float maxHp;
    private float currentHp;
    //private float shield;

    public void StartTurn()
    {
        effectApply();
    }

    #region 데미지 처리 영역
    public void TakeDamage(float amount)
    {
        float damage = CalculateDamageAfterDefense(amount);     //방어력 기반 데미지 계산
        damage = Mathf.Min(currentHp, damage);                  //현재 체력 기준 실제 감소될 데미지 계산
        currentHp = Mathf.Min(0, currentHp - damage);           //실제 데미지 감소

        Debug.Log($"{damage}의 피해를 입혔습니다.");
    }

    public void TakeTrueDamage(float amount)
    {
        float damage = Mathf.Min(currentHp, amount);
        currentHp = Mathf.Min(0, currentHp - damage);

        Debug.Log($"{damage}의 고정 피해를 입혔습니다.");
    }

    //방어력 계산 최종 데미지
    private float CalculateDamageAfterDefense(float amount)
    {
        float currentDefence = baseStatus.defense * (1 + modifiedStatus.defenseMultiplier);     //최종 방어력 계산
        float damageMultiplier = 100f / (100f + currentDefence);                                //방어력 비례 감소율 계산
        return amount * damageMultiplier;                                                       //최종 데미지 리턴
    }

    #endregion

    #region 버프 및 부과 효과 처리 영역
    private void effectApply()
    {
        modifiedStatus.ClearStatusMultipliers();            //기존 강화 수치 초기화

        foreach (var effect in statusEffects)               //스테이터스 관련 버프부터 적용
        {
            if(effect.effectType == EffectType.Buff || effect.effectType == EffectType.Debuff)              //스테이터스 버프/디퍼프 먼저 적용
            {
                effect.StartTurn(this);                     //지속 시간 감소 및 스테이터스 버프 반영
            }
        }

        //쉴드가 있다면 쉴드 먼저 적용 (또는 확인)



    }

    public void RemoveEffect(string effectId)
    {
        StatusEffect targetEffect = statusEffects.Find(o => o.effectId == effectId);
        if (targetEffect != null)
        {
            statusEffects.Remove(targetEffect);
        }
    }

    #endregion

    private IEnumerator ApplyDamageOverTime()
    {
        foreach (var effect in statusEffects)
        {
            if (effect.effectType == EffectType.DamageOverTime)         //지속 피해 스킬 데미지 적용
            {
                effect.ApplyEffect(this);                               //지속 데미지 적용
                //지속 데미지는 시전자의 피해증가 옵션에 영향을 받을지 설정
            }
            yield return new WaitForSeconds(0.5f);                      //각각 효과 연출 등 진행
        }
    }
}
