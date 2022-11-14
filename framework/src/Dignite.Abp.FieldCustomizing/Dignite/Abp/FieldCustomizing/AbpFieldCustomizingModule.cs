﻿using Dignite.Abp.FieldCustomizing.Localization;
using Volo.Abp.Json;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.Threading;
using Volo.Abp.VirtualFileSystem;

namespace Dignite.Abp.FieldCustomizing;

[DependsOn(
    typeof(AbpLocalizationModule),
    typeof(AbpThreadingModule),
    typeof(AbpJsonModule)
    )]
public class AbpFieldCustomizingModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<AbpFieldCustomizingModule>();
        });

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Add<AbpFieldCustomizingResource>("en")
                .AddVirtualJson("/Dignite/Abp/FieldCustomizing/Localization/Resources");
        });
    }
}