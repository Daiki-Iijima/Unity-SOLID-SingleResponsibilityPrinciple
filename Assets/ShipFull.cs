using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���@�̂��ׂĂ̏������������N���X
/// �����Ă���ӔC:
///     - �p�[�e�B�N���̊Ǘ�
/// </summary>
[RequireComponent(typeof(ShipInput))]
public class ShipFull : MonoBehaviour
{
    //  �X���X�^�[�̃p�[�e�B�N��(�����ɍŏ�������Ă���)
    [SerializeField] private GameObject thrusterParticles;
    //  ���񂾂Ƃ��ɕ\������p�[�e�B�N��
    [SerializeField] private GameObject deathParticleSystemPrefab;

    private void Awake() {
    }

    void Update() {
        //  ���͂�����΁A�p�[�e�B�N����\��
        //thrusterParticles.SetActive(input.Vertical > 0);
    }
}
