using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrocarCena : MonoBehaviour
{   
    public int enemyNumber1;
    public int enemyNumber2;
    public int currentEnemy;
    public BoxCollider collider;
   

    public string nomeDaCena;

    IEnumerator colliderStart()
    {
        yield return new WaitForSeconds(3);
        collider.enabled = true;
        
    }

    private void Awake()
    {
        collider = GetComponent<BoxCollider>();
    }

    private void Start()
    {   
        collider.enabled = false;
        StartCoroutine(colliderStart());

    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            Debug.Log("colidiu");
            TipoInimigo.TI.tipoInimigo1 = enemyNumber1;
            TipoInimigo.TI.tipoInimigo2 = enemyNumber2;
            CombatTransition.instance.currentenemy = currentEnemy;
            CombatTransition.instance.playerPosition = this.gameObject.transform.position;
            SceneManager.LoadScene(nomeDaCena);
            Destroy(this.gameObject);
            

        }
    }

    
}