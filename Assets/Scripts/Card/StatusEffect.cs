using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class StatusEffect
{
    public string effectId;                     //식별용 Id
    public string displayName;                  //표시될 이름
    public string description;                  //효과 설명

    public int duration;                        //효과 지속 시간(턴)
    public float value;                         //효과 수치
    public Sprite icon;                         //효과 아이콘

    public StatusEffect CloneEffect()
    {
        return (StatusEffect)this.MemberwiseClone(); // 얕은 복사
    }
}
