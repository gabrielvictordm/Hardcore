using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CombatTransition : MonoBehaviour
{

   public bool azuldead;
   public bool verdedead;
   public bool vermeldead;
   public bool golemdead;
   
   public bool boolTutorial;
   
   public int currentenemy;

   public Vector3 playerPosition;
   
   
   public static CombatTransition instance { get; private set; }

   private void Awake()
   {
     
       if (instance != null && instance != this)
       {
           Destroy(gameObject);
       }
       else
       {
           instance = this;
       }
        
       DontDestroyOnLoad(gameObject);
   }
   

   public void CheckEnemies()
   {
      if(azuldead==true)HubStart.instance.inimigoAzul.SetActive(false);
      if (vermeldead==true)HubStart.instance.inimigoVermelho.SetActive(false);
      if(verdedead==true)HubStart.instance.inimigoVerde.SetActive(false);
      if(golemdead==true)HubStart.instance.golem.SetActive(false);
      if(boolTutorial==true)HubStart.instance.tutorial.SetActive(false);
   }

   public void DefeatEnemies()
   {
       switch (currentenemy)
       {
           case 0: azuldead = true; break;
           case 1: vermeldead = true; break;
           case 2: verdedead = true; break;
           case 3: golemdead = true; break;
           
       }
       TutorialOff();

   }

   public void TutorialOff()
   {
       boolTutorial = true;
   }

}
