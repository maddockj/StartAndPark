﻿using FluentAssertions;
using NUnit.Framework;
using StartAndPark.Application.IntegrationTests.Assertions;
using StartAndPark.Domain.Entities;
using System.Threading.Tasks;

namespace StartAndPark.Application.IntegrationTests.Races.Commands
{
    using static Testing;

    public class CreateRaceCommandTests : TestBase
    {
        [Test]
        public async Task ShouldRequireMinimumFields()
        {
            var command = new CreateTrackCommand();

            var result = await SendAsync(command);

            result.IsBadRequest.Should().BeTrue();
            result.ValidationFailures.Should().ContainNotEmptyValidationErrorForProperty(nameof(CreateTrackCommand.Name));
        }

        [Test]
        public async Task ShouldCreateRace()
        {
            var command = new CreateTrackCommand()
            {
                Name = "Tour de France 2020",
            };

            var result = await SendAsync(command);

            var race = await FindAsync<Race>(result.Content);

            race.Should().NotBeNull();
            race.Name.Should().Be("Tour de France 2020");
        }
    }
}
