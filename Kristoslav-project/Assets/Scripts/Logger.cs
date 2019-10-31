
#if UNITY_EDITOR || DEVELOPMENT_BUILD
#define ENABLE_LOG
#endif
using System;
using System.Diagnostics;
using Unity;
using UnityEngine;

public class Logger
{
    [Conditional("ENABLE_LOG")]
    public static void StateStackDebug(string message)
    {
        UnityEngine.Debug.Log("State Stack Log: " + message);
    }


    [Conditional("ENABLE_LOG")]
    public static void InteractableDebug(string message)
    {
        UnityEngine.Debug.Log("Interactable Object Log: " + message);
    }

    [Conditional("ENABLE_LOG")]
    public static void InventoryDebug(string message)
    {
        UnityEngine.Debug.Log("Inventory System : " + message);
    }

    [Conditional("ENABLE_LOG")]
    public static void NPCDebug(string message)
    {
        UnityEngine.Debug.Log("NPC Log: " + message);
    }

    [Conditional("ENABLE_LOG")]
    public static void InitalizeErrors(string message)
    {
        UnityEngine.Debug.LogError("Initialize erros: " + message);
    }


    [Conditional("ENABLE_LOG")]
    public static void CameraDebug(string message)
    {
        UnityEngine.Debug.Log("Camera Log: " + message);
    }

    [Conditional("ENABLE_LOG")]
    public static void MovementDebug(string message)
    {
        UnityEngine.Debug.Log("Movement Log: " + message);
    }

    [Conditional("ENABLE_LOG")]
    public static void GameEventDebug(string message)
    {
        UnityEngine.Debug.Log("Game Event Log: " + message);
    }

    [Conditional("ENABLE_LOG")]
    public static void CharacterDebug(Character character, string message)
    {
        UnityEngine.Debug.Log(character + ": " + message);
    }

    [Conditional("ENABLE_LOG")]
    public static void GameStateDebug(GameState state, string message)
    {
        UnityEngine.Debug.Log(state + ": " + message);
    }

    [Conditional("ENABLE_LOG")]
    public static void GameMasterDebug(GameMaster gameMaster, string message)
    {
        UnityEngine.Debug.Log(gameMaster + ": " + message);
    }
    [Conditional("ENABLE_LOG")]
    public static void UltilitiesLog(string message)
    {
        UnityEngine.Debug.Log("Ultilities: " + message);
    }
}