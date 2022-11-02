using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���ˏ���
/// ���̃X�N���v�g�̃A�^�b�`���𑝂₷������1�x�ɔ��˂ł���e�̐��𑝂₹��
/// ����́AShip�Ɉˑ����Ȃ��Ă��������̂͂�
/// </summary>
public class ProjectileLauncher : MonoBehaviour
{
    //  ���˕�
    [SerializeField] private GameObject projectilePrefab;
    //  �e�𔭎˂���ʒu
    [SerializeField] private Transform weaponMountPoint;
    //  ���˂��鋭��
    [SerializeField] private float fireForce = 300f;

    private void Awake() {
        //  �����I�u�W�F�N�g��IProjectileLaunch�����������N���X�����Ă���K�v������
        IProjectileLaunch launch = GetComponent<IProjectileLaunch>();
        if(launch == null) {
            Debug.LogWarning("���΃C�x���g���擾�ł��܂���ł���");
            return;
        }

        launch.OnFire += HandleFire;
    }

    /// <summary>
    /// ���𐶐����ē�����
    /// </summary>
    private void HandleFire() {
        GameObject spawnedProjectile = Instantiate(projectilePrefab, weaponMountPoint.position, weaponMountPoint.rotation);
        Rigidbody projectileRb = spawnedProjectile.GetComponent<Rigidbody>();
        projectileRb.AddForce(spawnedProjectile.transform.forward * fireForce);
    }
}
