using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���@�̂��ׂĂ̏������������N���X
/// �����Ă���ӔC:
///     - �X�e�[�^�X�̊Ǘ�
///     - �ʒu�̍X�V
///     - ���ˏ���
///     - �p�[�e�B�N���̊Ǘ�
/// </summary>
[RequireComponent(typeof(ShipInput))]
public class ShipFull : MonoBehaviour
{
    //  �D�̃X�s�[�h
    [SerializeField] private float speed = 1f;
    //  ��]�X�s�[�h
    [SerializeField] private float turnSpeed = 30f;
    //  �X���X�^�[�̃p�[�e�B�N��(�����ɍŏ�������Ă���)
    [SerializeField] private GameObject thrusterParticles;
    //  HP�̍ő�l
    [SerializeField] private int maxHelth = 100;
    //  ���񂾂Ƃ��ɕ\������p�[�e�B�N��
    [SerializeField] private GameObject deathParticleSystemPrefab;

    [SerializeField] private ShipInput input;

    //  HP
    private int health;

    private void Awake() {
        //  �J�n���͍ő�̗͂ŊJ�n
        health = maxHelth;
    }

    void Update() {
        //  �ړ�
        transform.position += speed * Time.deltaTime * input.Vertical * transform.forward;

        //  ��]
        transform.Rotate(input.Horizontal * Time.deltaTime * turnSpeed * Vector3.up);

        //  ���͂�����΁A�p�[�e�B�N����\��
        thrusterParticles.SetActive(input.Vertical > 0);
    }


    private void OnCollisionEnter(Collision collision) {
        //  ���������I�u�W�F�N�g���e���`�F�b�N
        Projectile projectile = collision.collider.GetComponent<Projectile>();
        if (projectile != null) {
            //  �e�������ꍇ�_���[�W�����Z
            TakeDamage(projectile.Damage);
        }
    }

    /// <summary>
    /// �_���[�W�̌v�Z
    /// </summary>
    /// <param name="damage">�^����_���[�W</param>
    private void TakeDamage(int damage) {
        health -= damage;
        //  HP��0�ȉ��ɂȂ����玀��
        if (health <= 0) {
            Die();
        }
    }

    /// <summary>
    /// ���S����
    /// </summary>
    private void Die() {
        //  ���񂾂Ƃ��̃p�[�e�B�N���𐶐�
        Instantiate(deathParticleSystemPrefab, transform.position, Quaternion.identity);
        //  ����������
        Destroy(this.gameObject);
    }


}
