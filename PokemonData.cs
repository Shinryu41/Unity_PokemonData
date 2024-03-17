using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokemonData : MonoBehaviour
{
    [SerializeField] string PokemonName = "Magikarp";
    int CurrentLife;
    [SerializeField] int lifebase;
    [SerializeField] int atkbase;
    [SerializeField] int defbase;
    int stats;
    [SerializeField] float weight;

    enum Typelist {normal, fire, grass, water, rock, ground, fly, electrik, steel, bug, dark, ghost, fairy, fighting, dragon, ice, psy};

    [SerializeField] Typelist[] PokemonType = {};  
    [SerializeField] Typelist[] PokemonWeakness = {};
    [SerializeField] Typelist[] PokemonResist = {};

    void Display ()
    {
        Debug.Log(PokemonName);
        Debug.Log(lifebase);
        Debug.Log(atkbase);
        Debug.Log(defbase);
        Debug.Log(stats);
        Debug.Log(weight);
        for(int i = 0; i < PokemonWeakness.Length; i += 1){
            Debug.Log(PokemonWeakness[i]);
        } 

        for(int i = 0; i < PokemonResist.Length; i += 1){
            Debug.Log(PokemonResist[i]);
        }

    }

    void InitCurrentLife()
    {
        CurrentLife = lifebase;
    }

    void InitStatsPoints ()
    {
        stats = lifebase + atkbase + defbase;
    }

    int GetAttackDamage ()
    {
        return atkbase;
    }

    void TakeDamage (int damage, string PokemonType)
    {
        int neutral = 0;

        for(int i = 0; i < PokemonWeakness.Length; i += 1){
            if(PokemonType == PokemonWeakness[i].ToString() ){
                CurrentLife = CurrentLife - (damage*2);
                neutral +=1;
            } 
        } 

        for(int i = 0; i < PokemonResist.Length; i += 1){
            if(PokemonType == PokemonResist[i].ToString() ){
                CurrentLife = CurrentLife - (damage/2); 
                neutral +=1;
            } 
        }

        if(neutral == 0){
            CurrentLife = CurrentLife - damage;
        }

        Debug.Log("Le pokemon a subit "+damage+" , il lui reste "+CurrentLife+" hp");
    }

    void CheckIfPokemonAlive ()
    {
        if(CurrentLife > 0){
            Debug.Log("Le pokemon est encore en vie");
        } else {
            Debug.Log("Le pokemon est enfin KO");
        }
    }

    void Start()
    {
        Display();
        TakeDamage(34,"normal");
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfPokemonAlive();
    }

    void Awake(){
        InitCurrentLife();
        InitStatsPoints();
    }
}
