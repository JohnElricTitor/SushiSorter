using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Containers : MonoBehaviour
{
    [SerializeField] Transform[] makiPos = new Transform[8];        // Coordinates of where the pieces go
    [SerializeField] Transform[] nigiriPos = new Transform[4];      // Coordinates of where the pieces go
    [SerializeField] Transform[] ikuraPos = new Transform[4];       // Coordinates of where the pieces go
    [SerializeField] Transform[] rollPos = new Transform[3];        // Coordinates of where the pieces go

    public SushiType.sushiTypes boxType;
    public bool isActive;      //First piece has not been placed to determine box type 
    bool isFull;        //Box is completely packed 

    [SerializeField] int slots = 0;      //max number of pieces
    int slot = 0;       //current slot 


    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (!isActive)
        {
            boxType = other.transform.GetComponent<PickUp>().sushi;

            switch(other.transform.GetComponent<PickUp>().sushi)
            {
                case (SushiType.sushiTypes.Maki):
                    slots = 8;
                    break;

                case (SushiType.sushiTypes.Nigiri):
                    slots = 4;
                    break;

                case (SushiType.sushiTypes.Ikura):
                    slots = 4;
                    break;

                case (SushiType.sushiTypes.Roll):
                    slots = 3;
                    break;

                default:
                    slots = 0;
                break;
                    
            }       
            isActive = true;
        }
        
        if (isActive)
        {
            if (other.transform.GetComponent<PickUp>().sushi == boxType)        //confirm the piece in belongs in set 
            {
                if (slot < slots)                                               //confirm theres available slots 
                {
                    if(boxType == SushiType.sushiTypes.Maki)
                    {
                        other.transform.position = makiPos[slot].position;
                        other.transform.rotation = makiPos[slot].rotation;
                        other.transform.parent = transform;
                        other.GetComponent<BoxCollider>().enabled = false;          //disable collider
                        slot++;                                                     //move to next slot 
                    }
                    else if (boxType == SushiType.sushiTypes.Nigiri)
                    {
                        other.transform.position = nigiriPos[slot].position;
                        other.transform.rotation = nigiriPos[slot].rotation;
                        other.transform.parent = transform;
                        other.GetComponent<BoxCollider>().enabled = false;          //disable collider
                        slot++;                                                     //move to next slot 
                    }
                    else if (boxType == SushiType.sushiTypes.Ikura)
                    {
                        other.transform.position = ikuraPos[slot].position;
                        other.transform.rotation = nigiriPos[slot].rotation;
                        other.transform.parent = transform;
                        other.GetComponent<BoxCollider>().enabled = false;          //disable collider
                        slot++;                                                     //move to next slot 
                    }
                    else if (boxType == SushiType.sushiTypes.Roll)
                    {
                        other.transform.position = rollPos[slot].position;
                        other.transform.rotation = rollPos[slot].rotation;
                        other.transform.parent = transform;
                        other.GetComponent<BoxCollider>().enabled = false;          //disable collider
                        slot++;                                                     //move to next slot 
                    }
                }
            }
        }
    
        if (slot == slots)
            GetComponent<Animator>().SetBool("isReady", true);
    
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Exit");
    }
}

