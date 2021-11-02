using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] int towerCost = 75;

    public bool PlaceTower(Tower towerPrefab, Vector3 position)
    {
        Bank bank = FindObjectOfType<Bank>();

        if(bank == null) { return false; }

        if(bank.CurrentBalance >= towerCost)
        {
            Instantiate(towerPrefab, position, Quaternion.identity);
            bank.Withdraw(towerCost);
            return true;
        }

        return false;
    }
}
