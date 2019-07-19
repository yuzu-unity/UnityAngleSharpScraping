using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx.Async;
using AngleSharp;
using AngleSharp.Dom;
//AngleSharp.dll必須
//AngleSharp.Js.dll Jint.dll必須
public class ScrapingSampleJs : MonoBehaviour
{
    public string uri;

    void Start()
    {
        CheckURL();
    }

    async void CheckURL()
    {
        var doc = await Parce();
        Debug.Log(doc.Title);
       
    }

    async UniTask<IDocument> Parce()
    {
        // WithJs()で、JavaScriptを有効 動作してるか不明
        var config = Configuration.Default.WithDefaultLoader().WithJs();
        var context = BrowsingContext.New(config);
        return await context.OpenAsync(uri);
    }
}
