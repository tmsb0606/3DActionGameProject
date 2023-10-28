using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using DG.Tweening;

public class PlayerController : MonoBehaviour,IDamagable
{
    public enum PlayerState
    {
        Idel,
        Move,
        Attack,
    }
    private Status status;
    [SerializeField]private Weapon weapon;
    private Animator _Animator;
    public float HitStopTime = 0.23f;
    private bool _isAttack = false;
    // Start is called before the first frame update
    void Start()
    {
        status = this.gameObject.GetComponent<Status>();
        _Animator = GetComponent<Animator>();
        //weapon = this.gameObject.GetComponent<Weapon>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInput();
        if (_isAttack)
        {
           // print("攻撃判定");
        }
    }
    private void PlayerInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_Animator.GetBool("isGrandAttack"))
            {
                _Animator.SetBool("isComboAttack1", true);
            }
            _Animator.SetTrigger("Attack");
            _Animator.SetBool("isGrandAttack",true);

            Attack();
        }
    }

    private void Attack()
    {
        if (_Animator.GetBool("isGrandAttack"))
        {
            GrandAttack();
        }
       // GameObject.Find("Enemy").GetComponent<IDamagable>().AddDamage(10f);
    }
    private async void GrandAttack()
    {
        weapon.hitList = new List<GameObject>();
        List<GameObject> endAttackList = new List<GameObject>();
        while (_Animator.GetBool("isGrandAttack"))
        {
           
            //await UniTask.Delay(10);
            if (weapon.hitList.Count > 0)
            {
                
                foreach (GameObject hit in weapon.hitList)
                {
                    //print(endAttackList.Contains(hit));
                    if (!endAttackList.Contains(hit)&&_isAttack)
                    {
                        OnAttackHit();
                        hit.GetComponent<IDamagable>().AddDamage(status.ATK);
                        endAttackList.Add(hit);
                    }

                   
                }
                weapon.hitList = new List<GameObject>();

            }
            await UniTask.Delay(10);
        }

    }
    public void AddDamage(float damage)
    {
        status.HP -= (int)damage;
    }

    public void StartAttack()
    {
       
        _isAttack = true;
    }
    public void EndGrandAttack()
    {
        _Animator.SetBool("isGrandAttack", false);
    }
    public void EndAttackJudgment()
    {
        _isAttack = false;
    }
    public void EndComboAttack1()
    {
        
        _Animator.SetBool("isComboAttack1", false);
    }


    public void OnAttackHit()
    {
        print("ヒットストップ");
        // モーションを止める
        _Animator.speed = 0f;

        var seq = DOTween.Sequence();
        seq.SetDelay(HitStopTime);
        // モーションを再開
        seq.AppendCallback(() => _Animator.speed = 1f);
    }
}
