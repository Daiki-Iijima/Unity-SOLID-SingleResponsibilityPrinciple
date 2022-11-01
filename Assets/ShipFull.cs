using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 自機のすべての処理を持ったクラス
/// 持っている責任:
///     - パーティクルの管理
/// </summary>
[RequireComponent(typeof(ShipInput))]
public class ShipFull : MonoBehaviour
{
    //  スラスターのパーティクル(自分に最初からついている)
    [SerializeField] private GameObject thrusterParticles;
    //  死んだときに表示するパーティクル
    [SerializeField] private GameObject deathParticleSystemPrefab;

    private void Awake() {
    }

    void Update() {
        //  入力があれば、パーティクルを表示
        //thrusterParticles.SetActive(input.Vertical > 0);
    }
}
