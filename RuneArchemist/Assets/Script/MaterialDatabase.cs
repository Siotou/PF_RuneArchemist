using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MaterialDatabase", menuName = "Data/Material Database")]
public class MaterialDatabase : ScriptableObject
{
    public List<MaterialData> materials = new List<MaterialData>();
}