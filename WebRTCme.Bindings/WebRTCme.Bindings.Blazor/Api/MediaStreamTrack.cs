﻿using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebRTCme.Bindings.Blazor.Extensions;
using WebRTCme.Bindings.Blazor.Interops;
using WebRTCme;

namespace WebRTCme.Bindings.Blazor.Api
{
    internal class MediaStreamTrack : ApiBase, IMediaStreamTrack
    {
        public static IMediaStreamTrack Create(IJSRuntime jsRuntime, JsObjectRef jsObjectRefMediaStreamTrack) =>
            new MediaStreamTrack(jsRuntime, jsObjectRefMediaStreamTrack);
            
        private MediaStreamTrack(IJSRuntime jsRuntime, JsObjectRef jsObjectRef) : base(jsRuntime, jsObjectRef) 
        {
            AddNativeEventListener("ended", (s, e) => OnEnded?.Invoke(s, e));
            AddNativeEventListener("mute", (s, e) => OnMute?.Invoke(s, e));
            AddNativeEventListener("unmute", (s, e) => OnUnmute?.Invoke(s, e));
        }

        public string ContentHint 
        {
            get => GetNativeProperty<string>("contentHint");
            set => SetNativeProperty("contentHint", value);
        }

        public bool Enabled 
        {
            get => GetNativeProperty<bool>("enabled");
            set => SetNativeProperty("enabled", value);
        }

        public string Id => GetNativeProperty<string>("id");

        public bool Isolated => GetNativeProperty<bool>("isolated");

        public MediaStreamTrackKind Kind => GetNativeProperty<MediaStreamTrackKind>("kind");

        public string Label => GetNativeProperty<string>("label");

        public bool Muted => GetNativeProperty<bool>("muted");

        public bool Readonly => GetNativeProperty<bool>("readonly");

        public MediaStreamTrackState ReadyState => GetNativeProperty<MediaStreamTrackState>("readyState");

        public event EventHandler OnEnded;
        public event EventHandler OnMute;
        public event EventHandler OnUnmute;

        public Task ApplyConstraints(MediaTrackConstraints contraints) =>
            JsRuntime.InvokeVoidAsync("applyConstraints", contraints).AsTask();

        public IMediaStreamTrack Clone() =>
            Create(JsRuntime, JsRuntime.CallJsMethod<JsObjectRef>(NativeObject, "clone"));

        public MediaTrackCapabilities GetCapabilities() =>
            JsRuntime.CallJsMethod<MediaTrackCapabilities>(NativeObject, "getCapabilities");

        public MediaTrackConstraints GetContraints() =>
            JsRuntime.CallJsMethod<MediaTrackConstraints>(NativeObject, "getContraints");

        public MediaTrackSettings GetSettings() =>
            JsRuntime.CallJsMethod<MediaTrackSettings>(NativeObject, "getSettings");

        public void Stop() =>
            JsRuntime.CallJsMethodVoid(NativeObject, "stop");

        
        
        //public object GetView()
        //{
          //  throw new NotImplementedException();
        //}

    }
}
