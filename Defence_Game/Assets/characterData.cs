using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterData : Singleton<characterData>
{

    public float Gunner_attackSpeed = 1.5f;

    public float Archer_attackSpeed = 1.5f;

    public float Magician_attackSpeed = 1.5f;

    public float[] GunnerAttackPoints = {2, 4, 8, 10, 18, 26};
    public float[] MagicianAttackPoints = {2, 4, 8, 10, 18, 26};
    public float[] ArcherAttackPoints = {4, 8, 16, 32, 50, 100};

    public float GunnerAttackCoefficient = 1.0f;
    public float MagicianAttackCoefficient = 1.0f;
    public float ArcherAttackCoefficient = 1.0f;

}
