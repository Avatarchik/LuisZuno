﻿// Copyright 2018-2019 TAP, Inc. All Rights Reserved.

using System;
using Unity.Entities;
using GlobalDefine;

[RequiresEntityConversion]
public class NoneAvatarProxy : EntityProxy {
    public ItemStruct dropItem;
    public NoneAvatarStatusComponent Status;
    public override void SetupComponents(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem) {
        base.SetupComponents(entity, dstManager, conversionSystem);

        dstManager.AddComponentData(entity, new ItemComponet(dropItem));
        dstManager.AddComponentData(entity, new NoneAvatarStatusComponent(ref Status));    }
}
