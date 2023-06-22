using System;
using System.IO;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    public const string SAVE_PATH = "save_{0}.dat";
    
    /// <summary>
    /// ////////////////////////////////////////////////////////////////
    /// </summary>
    #region Values
    [Serializable]
    public class SaveData
    {
        public Vector3 playerPos;
        public Vector3 playerRot;

        public ItemStack[] itemStacks;
    }
    [Serializable]
    public class ItemStackParameter
    {
        public int id;
        public float value;
        
    }
    
    [Serializable]
    public class ItemStack
    {
        public ItemStackParameter[] parameters;
        public int id;
        public int amount;
    }
    #endregion
    /// <summary>
    /// ////////////////////////////////////////////////////////////////
    /// </summary>
    
    public static void Save(SaveData data, int index)
    {
        var content = JsonUtility.ToJson(data, true);
        var path = Application.persistentDataPath + $"/{string.Format(SAVE_PATH, index)}";
        File.WriteAllText(path, content);
        Debug.Log($"[SaveSystem] Saved save '{index}' to file '{path}'");
    }

    public static SaveData Load(int index)
    {
        var data = new SaveData();
        var path = Application.persistentDataPath + $"/{string.Format(SAVE_PATH, index)}";
        if (File.Exists(path))
            data = JsonUtility.FromJson<SaveData>(File.ReadAllText(path));
        
        Debug.Log($"[SaveSystem] Loaded save '{index}' save from file '{path}'");
        return data;
    }
}