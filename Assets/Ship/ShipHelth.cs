using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipHelth : MonoBehaviour, IHealth
{
    //  HP�̍ő�l
    [SerializeField] private int maxHelth = 100;

    //  HP
    private int health;

    //  ���S�C�x���g
    public Action OnDie { get; set; }

    private void Awake() {
        //  �J�n���͍ő�̗͂ŊJ�n
        health = maxHelth;
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
        //  ���S�C�x���g�𔭉�
        OnDie?.Invoke();
        //  ����������
        Destroy(this.gameObject);
    }
}
