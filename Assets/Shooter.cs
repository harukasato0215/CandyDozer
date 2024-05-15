using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject[] candyPrefabs;
    public Transform candyParentTransform;
    public CandyManager candyManager;
    public float shotForce;
    public float shotTorque;
    public float baseWidth;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) Shot();
    }
    //キャンディをランダムに一つ選ぶ
    GameObject SampleCandy()
    {
        int index = Random.Range(0, candyPrefabs.Length);
        return candyPrefabs[index];
    }

    //画面サイズとInputの割合からキャンディ生成のポジションを計算
    Vector3 GetInstantiatePosition()
    {
        float x = baseWidth * (Input.mousePosition.x / Screen.width) - (baseWidth / 2);
        return transform.position + new Vector3(x, 0, 0);
    }


    //プレハブからオブジェクトを生成
    public void Shot()
    {
        //キャンディを生成できない条件であればshotしない
        if (candyManager.GetCandyAmount() <= 0) return;

        GameObject candy = Instantiate(SampleCandy(), GetInstantiatePosition(), Quaternion.identity);
        //生成したキャンディオブジェクトの親を登録
        candy.transform.parent = candyParentTransform;

        //キャンディオブジェクトのリジットボディを取得、力と回転を加える
        Rigidbody candyRigidBody = candy.GetComponent<Rigidbody>();
        candyRigidBody.AddForce(transform.forward * shotForce);
        candyRigidBody.AddTorque(new Vector3(0, shotTorque, 0));

        //ストック消費
        candyManager.ConsumeCandy();
    }
}


