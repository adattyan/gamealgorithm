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
    /// 線を引く
    /// </summary>
    void Draw()
    {
        // LineRendererコンポーネントをゲームオブジェクトにアタッチする
        var lineRenderer = gameObject.AddComponent<LineRenderer>();

        var positions = new Vector3[]
        {
        new Vector3(-12.77f, -3, 0),               // 開始点
        new Vector3(12.77f, -3f, 0),               // 終了点
        };

        lineRenderer.startWidth = 0.1f;                   // 開始点の太さを0.1にする
        lineRenderer.endWidth = 0.1f;                     // 終了点の太さを0.1にする

        // 線を引く場所を指定する
        lineRenderer.SetPositions(positions);
    }
}
