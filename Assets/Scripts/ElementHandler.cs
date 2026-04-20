using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ElementHandler : MonoBehaviour
{
    Dictionary<Elements, int> appliedElements = new();
    Dictionary<Elements, Dictionary<Elements, Action<int>>> reactionMatrix;
    void Start()
    {
        reactionMatrix = new()
    {
        {Elements.fire, new Dictionary<Elements, Action<int>>()
        {
            {Elements.water,Placeholder},
            {Elements.fire,Placeholder},
            {Elements.lightning,Placeholder},
            {Elements.nature,Placeholder}
        }
        },
        {Elements.water, new Dictionary<Elements, Action<int>>()
        {
            {Elements.water,Placeholder},
            {Elements.fire,Placeholder},
            {Elements.lightning,Placeholder},
            {Elements.nature,Placeholder}
        }
        },
        {Elements.lightning, new Dictionary<Elements, Action<int>>()
        {
            {Elements.water,Placeholder},
            {Elements.fire,Placeholder},
            {Elements.lightning,Placeholder},
            {Elements.nature,Placeholder}
        }
        },
        {Elements.nature, new Dictionary<Elements, Action<int>>()
        {
            {Elements.water,Placeholder},
            {Elements.fire,Placeholder},
            {Elements.lightning,Placeholder},
            {Elements.nature,Placeholder}
        }
        }
    };
    }
    void Placeholder(int test)
    {
        print("PlaceHolder Reaction");
    }

    void CheckForReactions()
    {
        if (appliedElements.Count < 2) return;
        //obtain the first two elements in the dictionary
        Elements element1 = appliedElements.Keys.ToArrayPooled()[0];
        Elements element2 = appliedElements.Keys.ToArrayPooled()[1];

        //calculate power
        int reactionPower = appliedElements[element1] + appliedElements[element2];

        //call corresponding method
        reactionMatrix[element1][element2](reactionPower);

        //remove elements
        appliedElements.Remove(element1);
        appliedElements.Remove(element2);
    }

    public void Add(Elements element, int amount)
    {
        //if element is already applied, increases it's amount, otherwise adds new pair
        if (appliedElements.ContainsKey(element))
        {
            appliedElements[element] += amount;
            // print(appliedElements[element]);
        }
        else
        {
            appliedElements.Add(element, amount);
        }
        CheckForReactions();
    }
}

public enum Elements
{
    water,
    fire,
    lightning,
    nature
}