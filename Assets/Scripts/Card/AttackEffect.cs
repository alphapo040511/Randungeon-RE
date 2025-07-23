using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class AttackEffect
{
    //스킬 효과 적용 메서드
    public abstract void Execute(Unit attacker, Unit target);

    //데미지 값 메서드
    public abstract string GetDamageValue(int cardRank);
}
