using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class StatusEffect
{
    public string effectId;                     //�ĺ��� Id
    public string displayName;                  //ǥ�õ� �̸�
    public string description;                  //ȿ�� ����

    public int duration;                        //ȿ�� ���� �ð�(��)
    public float value;                         //ȿ�� ��ġ
    public Sprite icon;                         //ȿ�� ������

    public StatusEffect CloneEffect()
    {
        return (StatusEffect)this.MemberwiseClone(); // ���� ����
    }
}
