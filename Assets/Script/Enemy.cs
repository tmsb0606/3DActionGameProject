using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour,IDamagable
{
    Status status;
    public GameObject image;
    // Start is called before the first frame update
    void Start()
    {
        status = this.gameObject.GetComponent<Status>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (status.HP <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }
    public void AddDamage(float damage)
    {
        status.HP -= (int)damage;
        print("エネミーHP:" + status.HP+ "/"+status.maxHP);
        image.GetComponent<Image>().fillAmount = (float)status.HP / status.maxHP;
    }
}
