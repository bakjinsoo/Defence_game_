using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Manager : MonoBehaviour
{
    int random_x;
    int random_y;
    int random_character;
    int [,]character=new int[11,6];
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0;i<11;i++)
        {
            for(int j=0;j<6;j++)
            {
                character[i,j]=0;
            }
        }
        for(int i=0;i<3;i++)
        {
            random_x=Random.Range(0,11);
            random_y=Random.Range(0,6);
            character[random_x,random_y]=1;
            while(true)
            {
                if(character[random_x,random_y]==1)
                {
                    random_x=Random.Range(0,11);
                    random_y=Random.Range(0,6);
                }
                else
                {
                    character[random_x,random_y]=1;
                    random_character=Random.Range(0,3);
                    if(random_character==0)
                    {
                        GameObject tmp=Instantiate(Resources.Load<GameObject>("Prefabs/hamster_archer_1"));
                    }
                    else if(random_character==1)
                    {
                        GameObject tmp=Instantiate(Resources.Load<GameObject>("Prefabs/hamster_magician"));
                    }
                    else if(random_character==2)
                    {
                        GameObject tmp=Instantiate(Resources.Load<GameObject>("Prefabs/hamster_gunner_1"));
                    }
                    
                    break;
                }
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
