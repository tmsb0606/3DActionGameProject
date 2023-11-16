using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshController : MonoBehaviour
{
    // �ړI�n�ƂȂ�GameObject���Z�b�g���܂��B
    public Transform target;
    private NavMeshAgent myAgent;

    void Start()
    {
        // Nav Mesh Agent ���擾���܂��B
        myAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        // target�Ɍ������Ĉړ����܂��B
        myAgent.SetDestination(target.position);
    }
}
