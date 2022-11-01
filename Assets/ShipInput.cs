using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 自機への入力
/// </summary>
public class ShipInput : MonoBehaviour, IProjectileLaunch
{
    //  横の入力量
    public float Horizontal { get; private set; }
    //  縦の入力量
    public float Vertical { get; private set; }
    //  発射ボタンが押されているか
    public bool FireWeapons { get; private set; }

    /// <summary>
    /// 発射イベント
    /// </summary>
    public Action OnFire { get; set; }

    void Update()
    {
        //  入力の管理
        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");
        FireWeapons = Input.GetButtonDown("Fire1");

        //  発射イベント
        if (FireWeapons) {
            OnFire?.Invoke();
        }
    }
}
