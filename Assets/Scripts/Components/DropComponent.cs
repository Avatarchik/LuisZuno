﻿// Copyright 2018-2019 TAP, Inc. All Rights Reserved.

using System;
using Unity.Entities;

[Serializable]
public struct DropComponent : IComponentData {
    public Int64 dropItemID;
}
