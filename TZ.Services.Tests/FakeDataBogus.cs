using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TZ.Domain.DbModels;
using TZ.Domain.DtoModels;

namespace TZ.Services.Tests
{
    public class FakeDataBogus
    {
        private static List<ExperimentResult> _experimentResults;
        private static List<ExperimentResultDto> _experimentResultsDto;
        private static List<ExperimentDto> _experiments;
        private static ExperimentResultDto _expDto;
        public static List<ExperimentResult> GenerateOneExperimentResultButton()
        {
            if (_experimentResults == null)
            {

                _experimentResults = new Faker<ExperimentResult>()
                    .RuleFor(e => e.DeviceToken, faker => faker.Name.FirstName())
                    .RuleFor(e => e.Id, faker => Guid.NewGuid())
                    .RuleFor(e => e.Key, faker => "button_color")
                    .Generate(1);

            }
            return _experimentResults;
        }

        public static List<ExperimentResult> GenerateOneExperimentResultPrice()
        {
            if (_experimentResults == null)
            {

                _experimentResults = new Faker<ExperimentResult>()
                    .RuleFor(e => e.DeviceToken, faker => faker.Name.FirstName())
                    .RuleFor(e => e.Id, faker => Guid.NewGuid())
                    .RuleFor(e => e.Key, faker => "price")
                    .Generate(1);

            }
            return _experimentResults;
        }

        public static List<ExperimentResultDto> GenerateOneExperimentResultDtoButton()
        {
            if (_experimentResultsDto == null)
            {

                _experimentResultsDto = new Faker<ExperimentResultDto>()
                    .RuleFor(e => e.DeviceToken, faker => faker.Name.FirstName())
                    .RuleFor(e => e.Id, faker => Guid.NewGuid())
                    .RuleFor(e => e.ExperimentId, faker => Guid.Parse("A3DC9081-6DC1-4CF1-9E44-CEFE22F97E85"))
                    .Generate(1);

            }
            return _experimentResultsDto;
        }
        public static List<ExperimentResultDto> GenerateOneExperimentResultDtoPrice()
        {
            if (_experimentResultsDto == null)
            {

                _experimentResultsDto = new Faker<ExperimentResultDto>()
                    .RuleFor(e => e.DeviceToken, faker => faker.Name.FirstName())
                    .RuleFor(e => e.Id, faker => Guid.NewGuid())
                    .RuleFor(e => e.Key, faker => "price")
                    .RuleFor(e => e.ExperimentId, faker => Guid.Parse("EB63B870-0675-4DBE-89D7-3E64BDB21F31"))
                    .Generate(1);

            }
            return _experimentResultsDto;
        }
        public static List<ExperimentResultDto> GenerateOneExperimentResultDtoPriceFalse()
        {
            if (_experimentResultsDto == null)
            {

                _experimentResultsDto = new Faker<ExperimentResultDto>()
                    .RuleFor(e => e.DeviceToken, faker => faker.Name.FirstName())
                    .RuleFor(e => e.Id, faker => Guid.NewGuid())
                    .Generate(1);

            }
            return _experimentResultsDto;
        }

        public static List<ExperimentResultDto> GenerateExperimentResultDtoPrice(int number)
        {
            _experimentResultsDto = new Faker<ExperimentResultDto>()
                .RuleFor(e => e.DeviceToken, faker => faker.Name.FirstName())
                .RuleFor(e => e.Id, faker => Guid.NewGuid())
                .RuleFor(e => e.Key, faker => "price")
                .RuleFor(e => e.ExperimentId, faker => Guid.Parse("EB63B870-0675-4DBE-89D7-3E64BDB21F31"))

                .Generate(number);

            return _experimentResultsDto;
        }
        public static List<ExperimentResultDto> GenerateForExperimentResultDtoPrice(int number)
        {
            if (_experimentResultsDto == null)
            {
                _experimentResultsDto = new Faker<ExperimentResultDto>()
                    .RuleFor(e => e.DeviceToken, faker => faker.Name.FirstName())
                    .RuleFor(e => e.Id, faker => Guid.Parse("EB63B870-0675-4DBE-89D7-3E64BDB21F32"))
                    .RuleFor(e => e.Key, faker => "price")
                    .RuleFor(e => e.ExperimentId, faker => Guid.Parse("EB63B870-0675-4DBE-89D7-3E64BDB21F31"))

                    .Generate(number);
            }
            return _experimentResultsDto;
        }
        public static ExperimentResultDto GenerateForExperimentResultDtoPrice2(int number)
        {
            _experimentResultsDto = new Faker<ExperimentResultDto>()
                .RuleFor(e => e.DeviceToken, faker => faker.Name.FirstName())
                .RuleFor(e => e.Id, faker => Guid.Parse("EB63B870-0675-4DBE-89D7-3E64BDB21F32"))
                .RuleFor(e => e.Key, faker => "price")
                .RuleFor(e => e.ExperimentId, faker => Guid.Parse("EB63B870-0675-4DBE-89D7-3E64BDB21F31"))
                .Generate(number);

            return _expDto;
        }
        public static List<ExperimentDto> GenerateForExperimentDtoPrice(int number)
        {
            _experiments = new Faker<ExperimentDto>()
                .RuleFor(e => e.Id, faker => Guid.NewGuid())
                .RuleFor(e => e.Name, faker => "button_color")
                .Generate(number);

            return _experiments;
        }
        public static List<ExperimentDto> GenerateForExperimentDtoPriceId(Guid Id)
        {
            _experiments = new Faker<ExperimentDto>()
                .RuleFor(e => e.Id, faker => Id)
                .RuleFor(e => e.Name, faker => "button_color")
                .Generate(1);

            return _experiments;
        }
    }
}
