using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disapear : MonoBehaviour
{
    private float time = 0.0f;
    private float counter = 0.0f;
    public float startToDisapearTime = 10.0f;
    public float disapearTime = 3.0f;

    private void Update()
    {

        time += Time.deltaTime;

        if (time >= startToDisapearTime)
        {

            counter += Time.deltaTime;

            gameObject.transform.localScale = new Vector3(1 - (counter / disapearTime), 1 - (counter / disapearTime), 1 - (counter / disapearTime));

            if (counter >= disapearTime)
            {
                Destroy(gameObject);
            }
        }
    }
}
