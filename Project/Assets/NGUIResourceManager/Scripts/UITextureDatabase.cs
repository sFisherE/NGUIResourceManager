using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class UITextureDatabase : ScriptableObject
{
    //public static UIAtlasTextures atlasTextures;

    //[SerializeField]
    //public UIAtlas[] atlases;
    [SerializeField]
    public Texture[] textures;

    [SerializeField]
    public List<string> paths=new List<string>();
}
