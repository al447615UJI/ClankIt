using UnityEngine;

public interface ITriggerCheckeable
{
    bool isAggroed {get; set;}
    bool isWithinStrikingDistance{get;set;}

    void SetAggroStatus(bool IsAggroed);
    void SetStrikingDistanceBool(bool isWithinStrikingDistance);
}
