using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCard", menuName = "Cards/Card Data")]
public class CardData : ScriptableObject
{
    [Header("ī�� ����")]
    public string cardId;               //ī�� ������ Id
    public string cardName;             //ī�� �̸�
    public string description;          //ī�� ����

    //�Ϲ� ��ų ȿ�� (���� ��) ����Ʈ �߰� ����

    [Header("�ΰ� ��ų ȿ��")]
    [Tooltip("���� ȿ��")] public List<StatusEffect> buffEffects = new List<StatusEffect>();            //ī�� ȿ��(����)
    [Tooltip("����� ȿ��")] public List<StatusEffect> debuffEffects = new List<StatusEffect>();        //ī�� ȿ��(�����)
    [Tooltip("��ƿ ȿ��")] public List<StatusEffect> utilityEffects = new List<StatusEffect>();         //ī�� ȿ��(��ƿ)
}
