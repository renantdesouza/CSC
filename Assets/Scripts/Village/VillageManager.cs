using System;
using BackgroundSound;
using BusinessException;
using UnityEngine;
using UnityEngine.SceneManagement;
using Village;

public class VillageManager: MonoBehaviour
{
    private VillageService Service = VillageService.GetInstance();

    private void Awake()
    {
        BackgroundSoundManager.Play("Aventura");
    }

    public void OnClickDuel()
    {
        Debug.Log("Duel");
        
        Service.CreateNewBattle();
            
        SceneManager.LoadScene("TurnBattle");
    }
    
    public void OnClickExit()
    {
        SceneManager.LoadScene("Camp");
    }
    
    public void OnClickMarket()
    {
        throw new FeatureNotImplementedInThisVersionException();
    }
}