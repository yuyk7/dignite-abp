﻿using System.Threading.Tasks;
using Shouldly;
using Volo.Abp.Modularity;
using Volo.Abp.Timing;
using Xunit;

namespace Dignite.Abp.UserPoints;

/* Write your custom repository tests like that, in this project, as abstract classes.
 * Then inherit these abstract classes from EF Core & MongoDB test projects.
 * In this way, both database providers are tests with the same set tests.
 */
public abstract class UserPointsOrderRepository_Tests<TStartupModule> : UserPointsTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{
    private readonly IUserPointsOrderRepository _userPointsOrderRepository;
    private readonly UserPointsTestData _testData;
    private readonly IClock _clock;

    protected UserPointsOrderRepository_Tests()
    {
        _userPointsOrderRepository = GetRequiredService<IUserPointsOrderRepository>();
        _testData = GetRequiredService<UserPointsTestData>();
        _clock = GetRequiredService<IClock>();
    }


    [Fact]
    public async Task GetPagedListAsync_ShouldWorkProperly_WithUserId_WhileGetting10_WithoutSorting()
    {
        var result = await _userPointsOrderRepository.GetListAsync(_testData.User1Id);

        result.ShouldNotBeNull();
        result.ShouldNotBeEmpty();
        result.Count.ShouldBe(1);
    }
}
