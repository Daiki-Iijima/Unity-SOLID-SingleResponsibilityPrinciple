using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 移動を行う
/// Shipに依存する必要はない
/// </summary>
public class Engine : MonoBehaviour
{
    //  移動速度
    [SerializeField] private float speed = 1f;
    //  回転速度
    [SerializeField] private float turnSpeed = 30f;

    private IInput input;

    private void Awake() {
        input = GetComponent<IInput>();
        if(input == null) {
            Debug.LogWarning("入力が取得できません");
        }
    }

    private void Update() {

        //  前進移動
        float inputVertical = input.Vertical;
        //  移動量
        Vector3 forwardValue = transform.forward * Time.deltaTime * speed;
        //  入力の係数をかけて移動させる
        this.transform.position += forwardValue * inputVertical;


        //  回転
        float inputHorizon = input.Horizontal;
        //  回転量
        Vector3 turnValue =  Vector3.up* Time.deltaTime * turnSpeed;
        //  入力の係数をかけて移動させる
        this.transform.Rotate(turnValue * inputHorizon);
    }
}
