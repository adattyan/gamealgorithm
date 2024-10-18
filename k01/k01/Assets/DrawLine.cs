using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Draw();
    }

    /// <summary>
    /// ��������
    /// </summary>
    void Draw()
    {
        // LineRenderer�R���|�[�l���g���Q�[���I�u�W�F�N�g�ɃA�^�b�`����
        var lineRenderer = gameObject.AddComponent<LineRenderer>();

        var positions = new Vector3[]
        {
        new Vector3(-12.77f, -3, 0),               // �J�n�_
        new Vector3(12.77f, -3f, 0),               // �I���_
        };

        lineRenderer.startWidth = 0.1f;                   // �J�n�_�̑�����0.1�ɂ���
        lineRenderer.endWidth = 0.1f;                     // �I���_�̑�����0.1�ɂ���

        // ���������ꏊ���w�肷��
        lineRenderer.SetPositions(positions);
    }
}
