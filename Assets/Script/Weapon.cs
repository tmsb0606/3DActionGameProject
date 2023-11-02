using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public enum WeaponType
    {
        Sword,
    }
    public List<GameObject> hitList;
    // Start is called before the first frame update
    void Start()
    {
        hitList = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag== "Enemy")
        {
            //print(other.gameObject.name);
            if (hitList.Contains(other.gameObject))
            {
               return;
            }
            print("“–‚½‚Á‚½");
            hitList.Add(other.gameObject);
        }
        
    }
}
