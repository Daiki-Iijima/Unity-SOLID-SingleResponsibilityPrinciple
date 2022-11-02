using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipParticle : MonoBehaviour
{
    //  �X���X�^�[�̃p�[�e�B�N��(�����ɍŏ�������Ă���)
    [SerializeField] private GameObject thrusterParticles;
    //  ���񂾂Ƃ��ɕ\������p�[�e�B�N��
    [SerializeField] private GameObject deathParticleSystemPrefab;

    [SerializeField] private float timeToDeathParticleDestruct = 2.0f;

    private IHealth health;
    private IInput input;

    void Start() {

        health = GetComponent<IHealth>();
        input = GetComponent<IInput>();

        if (health == null || input == null) {
            Debug.LogWarning("�K�v�ȏ����擾�ł��܂���ł����B");
            return;
        }

        //  ���S�C�x���g�̃n���h����ǉ�
        health.OnDie += HandlerDie;
    }

    // Update is called once per frame
    void Update() {
        thrusterParticles.SetActive(input.Vertical > 0);
    }

    private void HandlerDie() {
        //  ���S���p�[�e�B�N���𐶐�
        GameObject obj = Instantiate(deathParticleSystemPrefab, this.transform.position, Quaternion.identity);

        //  �������Ԃ�ݒ�
        Destroy(obj, timeToDeathParticleDestruct);
    }
}
