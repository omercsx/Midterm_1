using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BrickHealth { Blue=3,Green=2,White=1,Finished=0}
public class Brick : MonoBehaviour
{

    public BrickHealth Health;
   
    private void Awake()
    {
  
    }
    public void AssignHealth()
    {
        this.GetComponent<SpriteRenderer>().sprite = GameManager.Instance.BricksHealthImg[(int)Health - 1];
    }
    void Start()
    {
       
        AssignHealth();
        GameManager.Instance.TotalBricks++;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ball"))
        {
            Health--;
            if(Health==0)
            {
                GameManager.Instance.BrickDestroyed(); 
                this.gameObject.SetActive(false);
            }
            else
            {
                AssignHealth();
            }
        }
    }
}
