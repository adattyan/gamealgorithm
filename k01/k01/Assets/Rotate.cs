using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] GameObject Center; //回転軸
    Vector3 v_center;                   //回転軸の座標
    Vector3 v_point;                    //自身の座標
    Vector3 v_pointmov;                 //自身が回転する座標
    Vector3 v_relbef;                   //回転前の相対ベクター
    Vector3 v_relaft;                   //回転後の相対ベクター
    [SerializeField] float angle = 10;  //回転の角度
    float radian;                       //角度のラジアン
    float correction;                   //めり込んだ時の補正値

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
    /// ポイントが地面にめり込んでないかのチェック
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
    /// 回転処理
    /// </summary>
    void Rotation()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
            //自分と回転軸の座標取得
            v_point = this.transform.position;
            //v_center = Center.transform.position;

            Check();
            //回転軸と自分の相対ベクターを取得
            v_relbef = v_point - v_center;

            AngleChange();
            //角度からラジアン値を計算
            radian = angle * 3.14f / 180;

            //座標回転計算
            v_relaft.x = (v_relbef.x * Mathf.Cos(radian)) - (v_relbef.y * Mathf.Sin(radian));
            v_relaft.y = (v_relbef.x * Mathf.Sin(radian)) + (v_relbef.y * Mathf.Cos(radian));

            //回転する座標の取得
            v_pointmov = v_center + v_relaft;

            //回転分を移動
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
