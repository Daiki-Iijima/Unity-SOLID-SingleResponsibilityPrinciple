using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipParticle : MonoBehaviour
{
    //  スラスターのパーティクル(自分に最初からついている)
    [SerializeField] private GameObject thrusterParticles;
    //  死んだときに表示するパーティクル
    [SerializeField] private GameObject deathParticleSystemPrefab;

    [SerializeField] private float timeToDeathParticleDestruct = 2.0f;

    private IHealth health;
    private IInput input;

    void Start() {

        health = GetComponent<IHealth>();
        input = GetComponent<IInput>();

        if (health == null || input == null) {
            Debug.LogWarning("必要な情報を取得できませんでした。");
            return;
        }

        //  死亡イベントのハンドラを追加
        health.OnDie += HandlerDie;
    }

    // Update is called once per frame
    void Update() {
        thrusterParticles.SetActive(input.Vertical > 0);
    }

    private void HandlerDie() {
        //  死亡時パーティクルを生成
        GameObject obj = Instantiate(deathParticleSystemPrefab, this.transform.position, Quaternion.identity);

        //  消去時間を設定
        Destroy(obj, timeToDeathParticleDestruct);
    }
}
