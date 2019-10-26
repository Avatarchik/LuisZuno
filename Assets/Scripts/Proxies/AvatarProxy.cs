﻿// Copyright 2018-2019 TAP, Inc. All Rights Reserved.

using System;
using Unity.Entities;
using GlobalDefine;

[RequiresEntityConversion]
public class AvatarProxy : EntityProxy {
    public ItemStruct[] defaultInventory = new ItemStruct[3];
    public AvatarStatusComponent Status;

    public override void SetupComponents(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem) {
        base.SetupComponents(entity, dstManager, conversionSystem);

        dstManager.AddComponentData(entity, new MovementComponent(-1.0f));

        dstManager.AddComponentData(entity, new InventoryComponent(defaultInventory));

        dstManager.AddComponentData(entity, new AvatarStatusComponent(ref Status));
    }
}
