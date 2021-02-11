﻿using NUnit.Framework;
using System.Threading.Tasks;

namespace StartAndPark.Application.IntegrationTests
{
    using static Testing;

    public class TestBase
    {
        [SetUp]
        public async Task SetUp()
        {
            await ResetState();
        }
    }
}
