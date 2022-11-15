﻿using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Localization;
using Volo.Abp.Settings;

namespace Dignite.Abp.SettingsGrouping;

/// <summary>
/// Wrap controls defined by existing setting items
/// </summary>
public class TestPackageSettingDefinitionProvider : TestSettingDefinitionProvider, ISettingDefinitionGroupProvider, ITransientDependency
{
    public string Section => TestSettingNames.TestSettingGroupName2;

    public override void Define(ISettingDefinitionContext context)
    {
        var settings = new Dictionary<string, SettingDefinition>();
        base.Define(new SettingDefinitionContext(settings));

        //add a setting items group
        context.Add(new FixedLocalizableString(TestSettingNames.TestSettingSectionName2),
                settings.Values.ToImmutableArray().ToArray()
        );

        //Configuration setting item control
        settings.GetValueOrDefault(TestSettingNames.TestSettingPackager)
            .UseTextboxControl(tb =>
                {
                    tb.Required = true;
                    tb.Placeholder = "placeholder-text";
                }
            );
    }
}
public class TestSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        context.Add(
            new SettingDefinition(TestSettingNames.TestSettingPackager, "abc")
        );
    }
}