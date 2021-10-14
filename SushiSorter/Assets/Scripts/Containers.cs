using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Containers : MonoBehaviour
{
    // Coordinates of where the pieces go
    [SerializeField] Transform[] makiPos = new Transform[8];        
    [SerializeField] Transform[] nigiriPos = new Transform[4];      
    [SerializeField] Transform[] ikuraPos = new Transform[4];       
    [SerializeField] Transform[] rollPos = new Transform[3];

    //[SerializeField] GameObject[] spawner;

    [SerializeField] Stats stats;


    public SushiType.sushiTypes boxType;                            //MAKI,NIGIRI,IKURA, OR ROLL
    SushiType.sushiTypes currentType;                               //THE TYPE OF THE CURRENT SUSHI PIECE 

    public bool isFirst;                                            //FIRST PIECE HAS NOT BEEN PLACED TO DETERMINE BOX TYPE 

    [SerializeField] int maxSlots = 0;                              //MAX NUMBER OF PIECES
    int currentSlot = 0;                                            //CURRENT SLOT
                                                        
    public int spawnPos;                                            //USED TO TELL CONTAINER SPAWNER WHICH AREA IT IS SPAWNED IN  

    private void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isFirst)                                               //IF FIRST PIECE HASNT BEEN PLACED IN BOX             
            AssignType(other);                                      

        if (isFirst)                                                //IF BOX TYPE HAS BEEN CHOSEN, CHECK NEW PIECE TYPE         
            DetectType(other);                   

        if (currentSlot == maxSlots)                                //IF ALL THE SLOTS ARE FULL 
        {
            GetComponent<Animator>().SetBool("isReady", true);      //PLAY ANIMATION            
        }
    
    }

    void AssignType(Collider other)
    {
        boxType = other.transform.GetComponent<PickUp>().type;      //MAKE THE BOX TYPE THE SAME AS THE FIRST SUSHI PIECE

        switch (boxType)                                            //CHOSE SLOT LAYOUT
        {
            case (SushiType.sushiTypes.Maki):
                maxSlots = 8;
                break;

            case (SushiType.sushiTypes.Nigiri):
                maxSlots = 4;
                break;

            case (SushiType.sushiTypes.Ikura):
                maxSlots = 4;
                break;

            case (SushiType.sushiTypes.Roll):
                maxSlots = 3;
                break;

            default:
                maxSlots = 0;
                break;
        }
        isFirst = true;
    }

    void DetectType(Collider other)                                 //DETECT SUSHI TYPE
    {
        currentType = other.transform.GetComponent<PickUp>().type;  //CURRENT TYPE IN HAND 

        if ( currentType == boxType)                                  
        {
            if (currentSlot < maxSlots)                                         //confirm theres available slots 
            {
                if (boxType == SushiType.sushiTypes.Maki)
                {
                    other.transform.position = makiPos[currentSlot].position;
                    other.transform.rotation = makiPos[currentSlot].rotation;
                    other.transform.parent = transform;
                    other.GetComponent<BoxCollider>().enabled = false;          
                    currentSlot++;
                }
                else if (boxType == SushiType.sushiTypes.Nigiri)
                {
                    other.transform.position = nigiriPos[currentSlot].position;
                    other.transform.rotation = nigiriPos[currentSlot].rotation;
                    other.transform.parent = transform;
                    other.GetComponent<BoxCollider>().enabled = false;          
                    currentSlot++;
                }
                else if (boxType == SushiType.sushiTypes.Ikura)
                {
                    other.transform.position = ikuraPos[currentSlot].position;
                    other.transform.rotation = nigiriPos[currentSlot].rotation;
                    other.transform.parent = transform;
                    other.GetComponent<BoxCollider>().enabled = false;          
                    currentSlot++;
                }
                else if (boxType == SushiType.sushiTypes.Roll)
                {
                    other.transform.position = rollPos[currentSlot].position;
                    other.transform.rotation = rollPos[currentSlot].rotation;
                    other.transform.parent = transform;
                    other.GetComponent<BoxCollider>().enabled = false;          
                    currentSlot++;
                    
                }
                stats.servings += 1;
            }            
        }
    }

    public void End()                                                               //ANIMATION CALLS END() WHICH SENDS SPAWN INFO AND DESTORYS ITSELF 
    {
        this.GetComponentInParent<ContainerSpawn>().Spawn(spawnPos);
        stats.bonusScore += maxSlots;
        Destroy(this.gameObject);
        
    }   
}

