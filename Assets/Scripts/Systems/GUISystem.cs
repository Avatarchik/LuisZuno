﻿// Copyrighgt 2018-2019 TAP, Inc. All Rights Reserved.

using UnityEngine;
using Unity.Entities;
using GlobalDefine;

public class GUISystem : ComponentSystem {
    private GUIPreset _guiPreset;
    private Entity _player = Entity.Null;

    protected override void OnStartRunning() {
        Entities.ForEach((GUIPresetComponent presetComp) => {
            _guiPreset = presetComp.preset;
        });

        Entities.ForEach((Entity entity, ref InventoryComponent inventoryComp, ref ReactiveComponent reactiveComp) => {
            if (GlobalDefine.EntityType.Player != reactiveComp.type)
                return;

            _player = entity;
        });

        if (null != _guiPreset) {
            _guiPreset.Initialize();
        }
    }

    protected override void OnUpdate() {
        if (null == _guiPreset)
            return;

        if (_player.Equals(Entity.Null))
            return;

        // set gui - inventory
        InventoryComponent InventoryComp = EntityManager.GetComponentData<InventoryComponent>(_player);
        _guiPreset.SetItem0(InventoryComp.item0);
        _guiPreset.SetItem1(InventoryComp.item1);
        _guiPreset.SetItem2(InventoryComp.item2);
    }
}