using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �ړ����s��
/// Ship�Ɉˑ�����K�v�͂Ȃ�
/// </summary>
public class Engine : MonoBehaviour
{
    //  �ړ����x
    [SerializeField] private float speed = 1f;
    //  ��]���x
    [SerializeField] private float turnSpeed = 30f;

    private IInput input;

    private void Awake() {
        input = GetComponent<IInput>();
        if(input == null) {
            Debug.LogWarning("���͂��擾�ł��܂���");
        }
    }

    private void Update() {

        //  �O�i�ړ�
        float inputVertical = input.Vertical;
        //  �ړ���
        Vector3 forwardValue = transform.forward * Time.deltaTime * speed;
        //  ���͂̌W���������Ĉړ�������
        this.transform.position += forwardValue * inputVertical;


        //  ��]
        float inputHorizon = input.Horizontal;
        //  ��]��
        Vector3 turnValue =  Vector3.up* Time.deltaTime * turnSpeed;
        //  ���͂̌W���������Ĉړ�������
        this.transform.Rotate(turnValue * inputHorizon);
    }
}
