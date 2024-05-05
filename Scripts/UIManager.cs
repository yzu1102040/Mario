using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text coinText;
    public Text levelText;
    public Text timeText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = "mario\n" + GameManager.Instance.coin.ToString("0");
        timeText.text = "time\n" + GameManager.Instance.time.ToString("0");
    }
}
