using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterData : Singleton<characterData>
{

    public float Gunner_AttackPoint = 2.5f;
    public float Gunner_attackSpeed = 1.5f;



    public float Archer_AttackPoint = 2.5f;
    public float Archer_attackSpeed = 1.5f;


    public float Magician_AttackPoint = 2.5f;
    public float Magician_attackSpeed = 1.5f;

    float[] GunnerAttackPoints = {2, 4, 8, 10, 18, 26};

}
