using UnityEngine;
using System.Collections;
using UnityEditor;
using System.IO;

public class NGUIResourceManagerMenu
{
    [MenuItem("NGUIResourceManagerMenu/Create AtlasTextures")]
    public static UITextureDatabase CreateSpriteUsage()
    {
        var path = System.IO.Path.Combine("Assets/NGUIResourceManager/Resources", "TextureDatabase.asset");
        var so = AssetDatabase.LoadMainAssetAtPath(path) as UITextureDatabase;
        if (so)
            return so;
        so = ScriptableObject.CreateInstance<UITextureDatabase>();
        DirectoryInfo di = new DirectoryInfo(Application.dataPath + "/NGUIResourceManager/Resources");
        if (!di.Exists)
        {
            di.Create();
        }
        AssetDatabase.CreateAsset(so, path);
        AssetDatabase.SaveAssets();
        return so;
    }

    [MenuItem("NGUIResourceManagerMenu/Generate Atlas Texture Paths")]
    public static void GenerateAtlasTexturePaths()
    {
        UITextureDatabase ats = CreateSpriteUsage();
       ats.paths.Clear();
        foreach (var tex in ats.textures)
        {
            if (tex!=null)
            {
                string path = AssetDatabase.GetAssetPath(tex.GetInstanceID());
                System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("Resources");
                System.Text.RegularExpressions.Match match = regex.Match(path);
                if (match.Success)
                {
                    path = path.Substring(match.Index + "Resources/".Length);
                    path = path.Substring(0, path.Length - ".png".Length);
                    ats.paths.Add(path);
                }
                else
                {
                    Debug.LogError("the texture:" + tex.name + " must put under Resources folder");
                    ats.paths.Add(string.Empty);
                }

            }
            else
                ats.paths.Add(string.Empty);
        }
    }
}
