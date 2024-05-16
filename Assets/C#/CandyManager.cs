using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyManager : MonoBehaviour
{
    const int DefaultCandyAmount = 30;
    const int RecoverySeconds = 10;
    public int candy = DefaultCandyAmount;
    int counter;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (candy < DefaultCandyAmount && counter <= 0)
        {
            StartCoroutine(RecoverCandy());
        }
    }

    public void ConsumeCandy()
    {
        if (candy > 0) candy--;
    }
    public int GetCandyAmount()
    {
        return candy;
    }

    public void AddCandy(int amount)
    {
        candy += amount;
    }

    void OnGUI()
    {
        GUI.color = Color.black;
        string label = "Candy" + candy;
        if (counter > 0) label = label + "(" + counter + "s)";

        GUI.Label(new Rect(50, 50, 100, 30), label);
    }

    IEnumerator RecoverCandy()
    {
        counter = RecoverySeconds;
        while (counter > 0)
        {
            yield return new WaitForSeconds(1.0f);
            counter--;
        }
        candy++;
    }
}
