using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    public TimeController timeController;
    private GameObject clock;
    // Start is called before the first frame update
    void Start()
    {
        clock = gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (timeController != null)
        {
            Debug.Log(timeController.timeLeft + 30);
            timeController.timeLeft += 30;
            clock.SetActive(false);
        }
    }
}
