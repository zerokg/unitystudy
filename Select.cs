using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player")
            return;
        if (transform.parent.parent.GetComponent<Dialogue>().IsEnd() == false)
            return;
        if (transform.parent.parent.GetComponent<Answer>().strAnswer == transform.name)
            transform.parent.parent.GetComponent<Answer>().AnswerRight();
        else
            transform.parent.parent.GetComponent<Answer>().AnswerWrong();
    }
}
