using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int stage;
    public int world;
    public float time;
    public int coin;
    public static GameManager Instance;
    // Start is called before the first frame update
    void Start()
    {
        LoadLevel();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.fixedDeltaTime;
    }

    public void DelayReset(float delay)
    {
        Invoke(nameof(LoadLevel), delay);
    }
    private void Awake() {
        if(Instance != null) {
            DestroyImmediate(gameObject);
        }
        else {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public void LoadLevel()
    {
        SceneManager.LoadScene($"{world}-{stage}");
    }

    public void AddCoin()
    {
        coin++;
    }
}
