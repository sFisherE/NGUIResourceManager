using UnityEngine;
using System.Collections;
using System;
public class UIResourceCleaner : MonoBehaviour {

    public static UITextureDatabase mTextureDatabase;
    public static UITextureDatabase textureDatabase
    {
        get
        {
            if (mTextureDatabase==null)
                mTextureDatabase=Resources.Load("TextureDatabase") as UITextureDatabase;
            return mTextureDatabase;
        }
    }
    public Texture[] textures;
    public Material[] materials;

	void OnDestroy () {
	    if (textures!=null)
	    {
            foreach ( Texture tex in textures)
            {
                Debug.Log("unload texture:" + tex.name);
                Resources.UnloadAsset(tex);
            }
	    }
        if (materials!=null && materials.Length>0)
        {
            foreach (var mat in materials)
            {
                Debug.Log("unload material:" + mat.name);
                Resources.UnloadAsset(mat);
            }
            
        }
        
	}
}
