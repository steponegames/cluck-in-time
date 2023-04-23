using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
    public GameObject spawnPoint;

    public GameObject player;

    //public GameObject restartUI;
    public GameObject restartButton; 
    private Button restart;

    public GameObject clockObject;
    private TextMeshProUGUI clockText;

    public float startTime = 30f;
    public float timeLeft;

    private bool buttonRendered;

    private GameObject clock;

    // Start is called before the first frame update
    void Start()
    {
        if (restart == null)
        {
            restart = restartButton.GetComponent<Button>();
        }
        HideButton();

        timeLeft = startTime;
        clockText = clockObject.GetComponent<TextMeshProUGUI>();



        InvokeRepeating(nameof(TimerUpdate), 1f, 1f);
    }

    private void Awake()
    {
        if(restart == null)
        {
            restart = restartButton.GetComponent<Button>();
        }

            restart.onClick.AddListener(NoParamaterOnclick);
    }

    void ShowButton()
    {
        restartButton.SetActive(true);
        player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
    }
    void HideButton()
    {
        restartButton.SetActive(false);
        player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    private void NoParamaterOnclick()
    {
        clock = GameObject.FindGameObjectWithTag("Clock");
        clock.SetActive(true);

        HideButton();
        timeLeft = 30f;
    }


    void TimerUpdate()
    {
        if (timeLeft > 0)
        {
            clockText.text = timeLeft.ToString();
            timeLeft -= 1f;

        }else
        {
            clockText.text = timeLeft.ToString();
            // show restart screen
            timeLeft = 0f;
            player.transform.position = spawnPoint.transform.position;
            ShowButton();
        }
    }
}
