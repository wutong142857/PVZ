using System.Collections;

using Unity.VisualScripting;
using UnityEngine;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get;private set;}
    public PrepareUI prepareUI;
    public CardListUi cardListUi;

    public Fail failUI;
    public WinUI winUI;
    

    private bool isGameEnd = false; 
    void Awake()
    {
        Instance = this;
    }

    
    public void GameOverFail()
    {
        if(isGameEnd)return;
        isGameEnd = true;
        
        failUI.Show();
        ZombieManager.Instance.Pause();
        cardListUi.DisableCardList();
        SunManager.Instance.StopNatureFall();

        AudioManager.Instance.PlayClip(Config.lose_music);


    }
    public void GameOverSuccess()
    {
        if(isGameEnd)return;
        isGameEnd = true;
        winUI.Show();
        
        cardListUi.DisableCardList();
        SunManager.Instance.StopNatureFall();

        AudioManager.Instance.PlayClip(Config.win_music);

    }
    void Start()
    {
        GameStart();
        Debug.Log("111");
    }
    void GameStart()
    {
       StartCoroutine(Game());
        
    }
    IEnumerator Game()
    {
         Vector3 transform = Camera.main.transform.position;
        Camera.main.transform.DOPath(new Vector3[] {transform,new Vector3(5,0,-10)},2);
        yield return new WaitForSeconds(3);
        Camera.main.transform.DOPath(new Vector3[] {new Vector3(5,0,-10),transform},2).OnComplete(PrepareGame);

    }
    void PrepareGame()
    {
        prepareUI.Show(OnPrePareUIComplete);
        
    }
    void OnPrePareUIComplete()
    {
        SunManager.Instance.StartNatureFall();
        ZombieManager.Instance.StartSpawm();
        cardListUi.ShowCardList();
        AudioManager.Instance.PlayBgm(Config.bgm1);

    }

}
