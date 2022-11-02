using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipHelth : MonoBehaviour, IHealth
{
    //  HPの最大値
    [SerializeField] private int maxHelth = 100;

    //  HP
    private int health;

    //  死亡イベント
    public Action OnDie { get; set; }

    private void Awake() {
        //  開始時は最大体力で開始
        health = maxHelth;
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
        //  死亡イベントを発火
        OnDie?.Invoke();
        //  自分を消去
        Destroy(this.gameObject);
    }
}
