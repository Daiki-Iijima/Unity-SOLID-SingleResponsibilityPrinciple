using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���@�ւ̓���
/// </summary>
public class ShipInput : MonoBehaviour, IProjectileLaunch,IInput
{
    //  ���̓��͗�
    public float Horizontal { get; private set; }
    //  �c�̓��͗�
    public float Vertical { get; private set; }
    //  ���˃{�^����������Ă��邩
    public bool IsFire { get; private set; }

    /// <summary>
    /// ���˃C�x���g
    /// </summary>
    public Action OnFire { get; set; }

    void Update()
    {
        //  ���͂̊Ǘ�
        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");
        IsFire = Input.GetButtonDown("Fire1");

        //  ���˃C�x���g
        if (IsFire) {
            OnFire?.Invoke();
        }
    }
}
