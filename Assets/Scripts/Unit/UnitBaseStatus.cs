using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//유닛의 베이스 스테이터스 (원본)
[CreateAssetMenu(fileName = "NewUnit", menuName = "Unit/Unit Data")]
public class UnitBaseStatus : ScriptableObject
{
    public float maxHP;
    public float attack;
    public float defense;
    public float critRate;
    public float critDamage;
    public float damageBonus;
}

//몬스터나 캐릭터 정보 SO를 추가하고, 거기에 c# class으로 저장하도록 수정 예정
