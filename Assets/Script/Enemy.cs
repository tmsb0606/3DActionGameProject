using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour,IDamagable
{
    Status status;
    public GameObject image;
    public enum EnemyState
    {
        Idel,
        Move,
        Attack,
    }
    EnemyState state = EnemyState.Idel;
    // Start is called before the first frame update
    void Start()
    {
        status = this.gameObject.GetComponent<Status>();
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case EnemyState.Idel:
                break;
            case EnemyState.Move:
                break;
            case EnemyState.Attack:
                break;
        }


        if (status.HP <= 0)
        {
            //�e�I�u�W�F�N�g�����������ԏ�̐e�I�u�W�F�N�g���\��
            if(transform.root.gameObject != null)
            {
                transform.root.gameObject.SetActive(false);
            }
            this.gameObject.SetActive(false);
        }

    }
    public void AddDamage(float damage)
    {
        status.HP -= (int)damage;
        //print("�G�l�~�[HP:" + status.HP+ "/"+status.maxHP);
        image.GetComponent<Image>().fillAmount = (float)status.HP / status.maxHP;
    }
}
