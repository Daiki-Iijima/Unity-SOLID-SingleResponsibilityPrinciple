using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 自機のすべての処理を持ったクラス
/// 持っている責任:
///     - ステータスの管理
///     - 位置の更新
///     - 発射処理
///     - パーティクルの管理
/// </summary>
[RequireComponent(typeof(ShipInput))]
public class ShipFull : MonoBehaviour
{
    //  船のスピード
    [SerializeField] private float speed = 1f;
    //  回転スピード
    [SerializeField] private float turnSpeed = 30f;
    //  スラスターのパーティクル(自分に最初からついている)
    [SerializeField] private GameObject thrusterParticles;
    //  HPの最大値
    [SerializeField] private int maxHelth = 100;
    //  死んだときに表示するパーティクル
    [SerializeField] private GameObject deathParticleSystemPrefab;

    [SerializeField] private ShipInput input;

    //  HP
    private int health;

    private void Awake() {
        //  開始時は最大体力で開始
        health = maxHelth;
    }

    void Update() {
        //  移動
        transform.position += speed * Time.deltaTime * input.Vertical * transform.forward;

        //  回転
        transform.Rotate(input.Horizontal * Time.deltaTime * turnSpeed * Vector3.up);

        //  入力があれば、パーティクルを表示
        thrusterParticles.SetActive(input.Vertical > 0);
    }


    private void OnCollisionEnter(Collision collision) {
        //  あたったオブジェクトが弾かチェック
        Projectile projectile = collision.collider.GetComponent<Projectile>();
        if (projectile != null) {
            //  弾だった場合ダメージを加算
            TakeDamage(projectile.Damage);
        }
    }

    /// <summary>
    /// ダメージの計算
    /// </summary>
    /// <param name="damage">与えるダメージ</param>
    private void TakeDamage(int damage) {
        health -= damage;
        //  HPが0以下になったら死ぬ
        if (health <= 0) {
            Die();
        }
    }

    /// <summary>
    /// 死亡処理
    /// </summary>
    private void Die() {
        //  死んだときのパーティクルを生成
        Instantiate(deathParticleSystemPrefab, transform.position, Quaternion.identity);
        //  自分を消去
        Destroy(this.gameObject);
    }


}
