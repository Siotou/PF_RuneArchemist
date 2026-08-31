using UnityEngine;
using UnityEditor;
using System.IO;

public static class MaterialCSVImporter
{
    private const string CSV_PATH =
        "Assets/Data/RuneArcheMist_Data - Material.csv";

    private const string ASSET_PATH =
        "Assets/Data/MaterialDatabase.asset";


    [MenuItem("Tools/Material/Import CSV")]
    public static void ImportCSV()
    {
        if (!File.Exists(CSV_PATH))
        {
            Debug.LogError("CSVが見つかりません！");
            Debug.LogError(CSV_PATH);
            return;
        }

        string[] lines = File.ReadAllLines(CSV_PATH);

        MaterialDatabase database =
            AssetDatabase.LoadAssetAtPath<MaterialDatabase>(ASSET_PATH);

        // ScriptableObjectが存在しなければ新規作成
        if (database == null)
        {
            database = ScriptableObject.CreateInstance<MaterialDatabase>();

            AssetDatabase.CreateAsset(database, ASSET_PATH);

            Debug.Log("MaterialDatabaseを新規作成しました！");
        }

        // 一度データを削除
        database.materials.Clear();


        // 1行目はヘッダーなので飛ばす
        for (int i = 1; i < lines.Length; i++)
        {
            if (string.IsNullOrWhiteSpace(lines[i]))
                continue;

            string[] values = lines[i].Split(',');

            // 列数チェック
            if (values.Length < 12)
            {
                Debug.LogWarning(
                    $"CSV {i + 1}行目の列数が正しくありません。"
                );

                continue;
            }


            MaterialData material = new MaterialData();

            material.No = int.Parse(values[0]);
            material.Name = values[1];

            material.Rare = int.Parse(values[2]);

            material.Fire = int.Parse(values[3]);
            material.Water = int.Parse(values[4]);
            material.Wind = int.Parse(values[5]);
            material.Rock = int.Parse(values[6]);
            material.Thunder = int.Parse(values[7]);

            material.Attack = int.Parse(values[8]);
            material.Speed = int.Parse(values[9]);
            material.MP = int.Parse(values[10]);

            material.Explain = values[11];


            database.materials.Add(material);
        }


        // ScriptableObjectを保存
        EditorUtility.SetDirty(database);

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();


        Debug.Log(
            $"CSV → MaterialDatabase 完了！\n" +
            $"登録された素材数：{database.materials.Count}"
        );
    }
}