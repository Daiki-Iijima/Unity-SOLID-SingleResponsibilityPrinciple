using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���@�̂��ׂĂ̏������������N���X
/// </summary>
public class ShipFull : MonoBehaviour
{
    //  �D�̃X�s�[�h
    [SerializeField] private float speed = 1f;
    //  ���˕�
    [SerializeField] private GameObject projectilePrefab;
    //  �e�𔭎˂���ʒu
    [SerializeField] private Transform weaponMountPoint;
    //  ���˂��鋭��
    [SerializeField] private float fireForce = 300f;
    //  ��]�X�s�[�h
    [SerializeField] private float turnSpeed = 30f;
    //  �X���X�^�[�̃p�[�e�B�N��(�����ɍŏ�������Ă���)
    [SerializeField] private GameObject thrusterParticles;
    //  HP�̍ő�l
    [SerializeField] private int maxHelth = 100;
    //  ���񂾂Ƃ��ɕ\������p�[�e�B�N��
    [SerializeField] private GameObject deathParticleSystemPrefab;

    //  HP
    private int health;

    private void Awake() {
        //  �J�n���͍ő�̗͂ŊJ�n
        health = maxHelth;
    }

    void Update() {

        //  ���͏���
        if (Input.GetButtonDown("Fire1")) {
            FireWeapon();
        }
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        //  �ړ�
        transform.position += speed * Time.deltaTime * vertical * transform.forward;

        //  ��]
        transform.Rotate(horizontal * Time.deltaTime * turnSpeed * Vector3.up);

        //  ���͂�����΁A�p�[�e�B�N����\��
        thrusterParticles.SetActive(vertical > 0);
    }

    /// <summary>
    /// ���𐶐����ē�����
    /// </summary>
    private void FireWeapon() {
        GameObject spawnedProjectile = Instantiate(projectilePrefab, weaponMountPoint.position, weaponMountPoint.rotation);
        Rigidbody projectileRb = spawnedProjectile.GetComponent<Rigidbody>();
        projectileRb.AddForce(spawnedProjectile.transform.forward * fireForce);
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
