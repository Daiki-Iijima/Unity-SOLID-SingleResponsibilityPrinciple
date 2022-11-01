using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 発射処理
/// このスクリプトのアタッチ数を増やすだけで1度に発射できる弾の数を増やせる
/// これは、Shipに依存しなくていい処理のはず
/// </summary>
public class ProjectileLauncher : MonoBehaviour
{
    //  発射物
    [SerializeField] private GameObject projectilePrefab;
    //  弾を発射する位置
    [SerializeField] private Transform weaponMountPoint;
    //  発射する強さ
    [SerializeField] private float fireForce = 300f;

    private void Awake() {
        //  同じオブジェクトにIProjectileLaunchを実装したクラスがついている必要がある
        IProjectileLaunch launch = GetComponent<IProjectileLaunch>();
        if(launch == null) {
            Debug.LogWarning("発火イベントを取得できませんでした");
            return;
        }

        launch.OnFire += HandleFire;
    }

    /// <summary>
    /// 球を生成して動かす
    /// </summary>
    private void HandleFire() {
        GameObject spawnedProjectile = Instantiate(projectilePrefab, weaponMountPoint.position, weaponMountPoint.rotation);
        Rigidbody projectileRb = spawnedProjectile.GetComponent<Rigidbody>();
        projectileRb.AddForce(spawnedProjectile.transform.forward * fireForce);
    }
}
