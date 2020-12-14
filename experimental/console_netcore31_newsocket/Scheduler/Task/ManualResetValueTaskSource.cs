﻿using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;


public sealed class ManualResetValueTaskSource<T> : IValueTaskSource<T>, IValueTaskSource
{
    public readonly ValueTask<T> AwaitableTask;

    public bool IsRepeate;
    public ManualResetValueTaskSource()
    {
        AwaitableTask = new ValueTask<T>(this, 0);
    }

    private ManualResetValueTaskSourceImplemention<T> _core; // mutable struct; do not make this readonly

    public bool RunContinuationsAsynchronously { get => _core.RunContinuationsAsynchronously; set => _core.RunContinuationsAsynchronously = value; }
    public short Version => _core.Version;
    public void Reset() => _core.Reset();
    public void SetResult(T result) => _core.SetResult(result);
    public void SetException(Exception error) => _core.SetException(error);

    public T GetResult(short token) => _core.GetResult(token);
    void IValueTaskSource.GetResult(short token) => _core.GetResult(token);
    public ValueTaskSourceStatus GetStatus(short token) => _core.GetStatus(token);
    public void OnCompleted(Action<object> continuation, object state, short token, ValueTaskSourceOnCompletedFlags flags) => _core.OnCompleted(continuation, state, token, flags);
}

