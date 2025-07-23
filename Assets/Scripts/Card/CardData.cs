using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCard", menuName = "Cards/Card Data")]
public class CardData : ScriptableObject
{
    [Header("카드 정보")]
    public string cardId;                           //카드 구별용 Id
    public string cardName;                         //카드 이름
    [TextArea]public string description;            //카드 설명

    [Header("메인 효과")]
    [Tooltip("공격 스킬")] public AttackEffect attackEffect;                                            //카드 메인 효과

    [Header("부가 스킬 효과")]
    [Tooltip("버프 효과")] public List<StatusEffect> buffEffects = new List<StatusEffect>();            //부가 효과(버프)
    [Tooltip("디버프 효과")] public List<StatusEffect> debuffEffects = new List<StatusEffect>();        //부가 효과(디버프)
    [Tooltip("유틸 효과")] public List<StatusEffect> utilityEffects = new List<StatusEffect>();         //부가 효과(유틸)
}
