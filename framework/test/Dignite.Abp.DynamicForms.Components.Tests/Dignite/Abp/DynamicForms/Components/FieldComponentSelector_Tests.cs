﻿using Dignite.Abp.DynamicForms.Components.BlazoriseUI.Components.TextEdit;
using Dignite.Abp.DynamicForms.Textbox;
using Shouldly;
using Xunit;

namespace Dignite.Abp.DynamicForms.Components;

public class FieldComponentSelector_Tests : FieldComponentsTestBase
{
    private readonly IFormViewComponentSelector _selector;

    public FieldComponentSelector_Tests()
    {
        _selector = GetRequiredService<IFormViewComponentSelector>();
    }

    [Fact]
    public void Should_Select_Textbox_Component_Provider()
    {
        _selector.Get(TextEditFormControl.ControlName).ShouldBeAssignableTo<TextEditFormViewComponent>();
    }
}