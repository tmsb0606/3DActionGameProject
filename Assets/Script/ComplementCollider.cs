using UnityEngine;
[RequireComponent(typeof(MeshFilter), typeof(MeshCollider), typeof(Rigidbody))]
public class ComplementCollider : MonoBehaviour
{
    /// <summary>
    /// �؂��敔���̈ʒu�ǐ՗p
    /// </summary>
    public Transform TipPosition;

    /// <summary>
    /// ���b�V�������p
    /// </summary>
    Mesh mesh;

    /// <summary>
    /// ���b�V���R���C�_
    /// </summary>
    MeshCollider meshCollider;

    /// <summary>
    /// �O�t���[���؂���ʒu
    /// </summary>
    Vector3 lastTipPosition;

    /// <summary>
    /// �O�t���[��
    /// </summary>
    Vector3 lastPosition;

    void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        meshCollider = GetComponent<MeshCollider>();
        // �g���K�[�Ƃ��Đݒ肷��
        meshCollider.convex = true;
        meshCollider.isTrigger = true;
        // ���b�V�����w��
        meshCollider.sharedMesh = mesh;
        // �O��ʒu�̏�����
        lastTipPosition = TipPosition.position;
        lastPosition = transform.position;
    }

    void FixedUpdate()
    {
        // �O��ʒu�Ɠ������͏������Ȃ��i�G���[�ɂȂ�j
        if (lastPosition == transform.position)
            return;
        if (lastTipPosition == TipPosition.position)
            return;

        // ���t���[�����b�V������蒼��
        mesh.Clear();

        // �O��ʒu�ƍ���ʒu�̒��Ԉʒu��⊮����i�������Ȃ��ƒ��ԕ����̔��肪�Z���Ȃ�j
        var colliderLength = (TipPosition.position - transform.position).magnitude;
        var startMidPoint = Vector3.Lerp(transform.position, lastPosition, 0.5f);
        var endMidPoint = Vector3.Lerp(TipPosition.position, lastTipPosition, 0.5f);
        var assumedMidEndPoint = startMidPoint + (endMidPoint - startMidPoint).normalized * colliderLength;

        // ���_�i���[�J�����W�ɕϊ����Đݒ�j
        mesh.vertices = new Vector3[] {
            transform.InverseTransformPoint(lastPosition), transform.InverseTransformPoint(lastTipPosition),
            transform.InverseTransformPoint(startMidPoint), transform.InverseTransformPoint(assumedMidEndPoint),
            transform.InverseTransformPoint(transform.position), transform.InverseTransformPoint(TipPosition.position),
        };

        // �������̒��_�����Ɏw�肵�ĎO�p�`������
        mesh.triangles = new int[]{
            0, 1, 2,
            1, 2, 3,
            2, 3, 4,
            3, 4, 5,
        };

        // ���f
        meshCollider.enabled = false;
        meshCollider.enabled = true;

        // �O��ʒu�̋L��
        lastTipPosition = TipPosition.position;
        lastPosition = transform.position;
    }
}
