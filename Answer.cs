using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Answer : MonoBehaviour
{
    public string strAnswer = "1";
    public void AnswerRight()
    {
        Destroy(transform.Find("Answers").gameObject);
        Debug.Log("Right");
    }
    public void AnswerWrong()
    {
        Destroy(transform.Find("Answers").gameObject);
        Debug.Log("Wrong");
    }
}
