using UnityEngine;
using System.Collections;

public class Wall_Move : MonoBehaviour {


    public int length;
    public GameObject Button;

    public void Extend()
    {
        StartCoroutine(Size());
    }

    public void MoveBack()
    {
        StartCoroutine(ReSize());
    }

    IEnumerator ReSize()
    {
        for (int i = 0; i <= length; i++)
        {
            transform.position -= new Vector3(0.1f, 0.0f, 0.0f);
            yield return new WaitForSeconds(0.01f);
        }
    }

    IEnumerator Size()
    {
        for (int i = 0; i <= length; i++)
        {
           transform.position += new Vector3(0.1f, 0.0f, 0.0f);
            yield return new WaitForSeconds(0.01f);
        }
        yield return new WaitForSeconds(2.5f);
        MoveBack();

    }

    void Update()
    {

        if (Button.GetComponent<Button>().Active == true)
        {
            Extend();
            Button.GetComponent<Button>().Active = false;
        }
    }

}
