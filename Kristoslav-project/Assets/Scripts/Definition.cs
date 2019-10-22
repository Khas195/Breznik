using System;
using Unity;
using UnityEngine;

public class Definition
{
    public static void StateStackDebug(string message)
    {
        Debug.Log("State Stack: " + message);
    }

    public static void InteractableDebug(string message)
    {
        Debug.Log("Interactable Object: " + message);
    }

    public static void InitalizeErrors(string message)
    {
        Debug.LogError("Initialize erros: " + message);
    }


    public static void CameraDebug(string message)
    {
        Debug.Log("Camera Log: " + message);
    }

    public static void MovementDebug(string message)
    {
        Debug.Log("Movement Log: " + message);
    }

    public static void CharacterDebug(Character character, string message)
    {
        Debug.Log(character +  ": "  + message);
    }

    public static void GameStateDebug(GameState state, string message)
    {
        Debug.Log(state +  ": "  + message);
    }

    public static void GameMasterDebug(GameMaster gameMaster, string message)
    {
        Debug.Log(gameMaster +  ": "  + message);
    }
}