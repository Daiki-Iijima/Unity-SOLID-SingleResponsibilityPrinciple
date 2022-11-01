using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���@�ւ̓���
/// </summary>
public class ShipInput : MonoBehaviour, IProjectileLaunch
{
    //  ���̓��͗�
    public float Horizontal { get; private set; }
    //  �c�̓��͗�
    public float Vertical { get; private set; }
    //  ���˃{�^����������Ă��邩
    public bool FireWeapons { get; private set; }

    /// <summary>
    /// ���˃C�x���g
    /// </summary>
    public Action OnFire { get; set; }

    void Update()
    {
        //  ���͂̊Ǘ�
        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");
        FireWeapons = Input.GetButtonDown("Fire1");

        //  ���˃C�x���g
        if (FireWeapons) {
            OnFire?.Invoke();
        }
    }
}
