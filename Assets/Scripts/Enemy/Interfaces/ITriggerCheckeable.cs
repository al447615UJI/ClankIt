using UnityEngine;

public interface ITriggerCheckeable
{
    bool IsAggroed {get; set;}
    bool IsWithinStrikingDistance{get;set;}

    void SetAggroStatus(bool IsAggroed);
    void SetStrikingDistanceBool(bool isWithinStrikingDistance);
}
