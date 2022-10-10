﻿using System;
using JetBrains.Annotations;

namespace Dignite.Abp.NotificationCenter.Blazor.Pages.NotificationCenter;

public interface INotificationDataComponentSelector
{
    /// <summary>
    /// Get blazor component using field control provider name
    /// </summary>
    /// <param name="notificationDataTypeFullName">
    /// <see cref="UserNotificationDto.Data"/>
    /// </param>
    /// <returns></returns>
    [NotNull]
    INotificationDataComponent Get(string notificationDataTypeFullName);
}

