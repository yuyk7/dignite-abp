﻿using Dignite.Abp.FieldCustomizing;

namespace Dignite.Abp.SettingManagement.Blazor;

public class SettingObject : IHasCustomFields
{
    public SettingObject()
    {
        this.CustomFields = new CustomFieldDictionary();
    }

    public CustomFieldDictionary CustomFields { get; }
}