using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubStart : MonoBehaviour
{   public static HubStart instance { get; private set; }
   public GameObject player;
   public PlayerMovementAdvanced movement;
   public GameObject inimigoVermelho;
   public GameObject inimigoVerde;
   public GameObject inimigoAzul;
   public GameObject golem;
   public GameObject tutorial;

   public GameObject[] UIgema1;
   public GameObject[] UIgema2;
   public GameObject[] UIgema3;
   private void Awake()
   {
      instance = this;
      CombatTransition.instance.CheckEnemies();
      player.transform.position = CombatTransition.instance.playerPosition;
   }

   private void Start()
   {
      LoadGems();
   }

   public void EnableMovement()
   {
      movement.enabled = true;
   }

   public void DisableMovement()
   {
      movement.enabled = false;
   }
   void LoadGems()
   {
      switch (PlayerStats.instance.pickaxeGems[0])
      {
         case 0: return;
         case 1: UIgema1[0].SetActive(true);
            break;
         case 2: UIgema1[1].SetActive(true);
            break;
         case 3: UIgema1[2].SetActive(true);
            break;
      }
      switch (PlayerStats.instance.pickaxeGems[1])
      {
         case 0: return;
         case 1: UIgema2[0].SetActive(true);
            break;
         case 2: UIgema2[1].SetActive(true);
            break;
         case 3: UIgema2[2].SetActive(true);
            break;
      }
      switch (PlayerStats.instance.pickaxeGems[2])
      {
         case 0: return;
         case 1: UIgema3[0].SetActive(true);
            break;
         case 2: UIgema3[1].SetActive(true);
            break;
         case 3: UIgema3[2].SetActive(true);
            break;
      }
        
            
        
   }
}
