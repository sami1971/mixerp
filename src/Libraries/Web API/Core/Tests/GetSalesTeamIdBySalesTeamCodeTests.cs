// ReSharper disable All
using System;
using System.Diagnostics;
using System.Linq;
using MixERP.Net.Api.Core.Fakes;
using MixERP.Net.ApplicationState.Cache;
using Xunit;

namespace MixERP.Net.Api.Core.Tests
{
    public class GetSalesTeamIdBySalesTeamCodeTests
    {
        public static GetSalesTeamIdBySalesTeamCodeController Fixture()
        {
            GetSalesTeamIdBySalesTeamCodeController controller = new GetSalesTeamIdBySalesTeamCodeController(new GetSalesTeamIdBySalesTeamCodeRepository(), "", new LoginView());
            return controller;
        }

        [Fact]
        [Conditional("Debug")]
        public void Execute()
        {
            var actual = Fixture().Execute(new GetSalesTeamIdBySalesTeamCodeController.Annotation());
            Assert.Equal(1, actual);
        }
    }
}