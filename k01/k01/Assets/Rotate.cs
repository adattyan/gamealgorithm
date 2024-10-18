using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] GameObject Center; //��]��
    Vector3 v_center;                   //��]���̍��W
    Vector3 v_point;                    //���g�̍��W
    Vector3 v_pointmov;                 //���g����]������W
    Vector3 v_relbef;                   //��]�O�̑��΃x�N�^�[
    Vector3 v_relaft;                   //��]��̑��΃x�N�^�[
    [SerializeField] float angle = 10;  //��]�̊p�x
    float radian;                       //�p�x�̃��W�A��
    float correction;                   //�߂荞�񂾎��̕␳�l

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Rotation();
    }

    /// <summary>
    /// �|�C���g���n�ʂɂ߂荞��łȂ����̃`�F�b�N
    /// </summary>
    void Check()
    {
        if(v_point.y < -3)
        {
            correction = -3  - v_point.y;
            v_point.y = v_point.y + correction;
            Center.transform.position = v_point;
        }
    }

    /// <summary>
    /// ��]����
    /// </summary>
    void Rotation()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
            //�����Ɖ�]���̍��W�擾
            v_point = this.transform.position;
            //v_center = Center.transform.position;

            Check();
            //��]���Ǝ����̑��΃x�N�^�[���擾
            v_relbef = v_point - v_center;

            AngleChange();
            //�p�x���烉�W�A���l���v�Z
            radian = angle * 3.14f / 180;

            //���W��]�v�Z
            v_relaft.x = (v_relbef.x * Mathf.Cos(radian)) - (v_relbef.y * Mathf.Sin(radian));
            v_relaft.y = (v_relbef.x * Mathf.Sin(radian)) + (v_relbef.y * Mathf.Cos(radian));

            //��]������W�̎擾
            v_pointmov = v_center + v_relaft;

            //��]�����ړ�
            transform.position = v_pointmov;
        }
    }

    void AngleChange()
    {
        if (Input.GetKey(KeyCode.D))
        {
            if (angle > 0)
            {
                angle = angle * -1;
            }

        }
        if (Input.GetKey(KeyCode.A))
        {
            if(angle < 0)
            {
                angle = angle * -1;
            }
        }
    }
}
