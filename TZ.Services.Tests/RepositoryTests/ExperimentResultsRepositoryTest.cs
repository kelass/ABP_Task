using Bogus;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TZ.Data;
using TZ.Domain.DbModels;
using TZ.Domain.DtoModels;
using TZ.Services.Repositories;

namespace TZ.Services.Tests.RepositoryTests
{
    public class ExperimentResultsRepositoryTest
    {

        private readonly ApplicationDbContext _context;
        private readonly ExperimentResultRepository _experimentResultRepository;

        public ExperimentResultsRepositoryTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()

            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

            _context = new ApplicationDbContext(options, "test");
            _experimentResultRepository = new ExperimentResultRepository(_context);
        }

        [Test]
        public async Task SelectExperimentResult_Success()
        {
            //Arrange


            var experiment = FakeDataBogus.GenerateExperimentResultDtoPrice(10);

            for (int i = 0; i < experiment.Count; i++)
            {
                await _experimentResultRepository.CreateAsync(experiment[i]);
                await _context.SaveChangesAsync();
            }

            

            //Act
            var select = await _experimentResultRepository.SelectAsync();

            //Assert
            Assert.AreEqual(_context.ExperimentResults.Count(), select.Count);
        }

        [Test]
        public async Task CreateExperimentResult_Success()
        {
            //Arrange
           var experiment = FakeDataBogus.GenerateOneExperimentResultDtoButton();

            //Act

            var result = await _experimentResultRepository.CreateAsync(experiment[0]);
            await _context.SaveChangesAsync();

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public async Task GetByIdExperimentResult_Success()
        {
            //Arrange
            var experiment = FakeDataBogus.GenerateOneExperimentResultDtoButton();
            var result = await _experimentResultRepository.CreateAsync(experiment[0]);
            await _context.SaveChangesAsync();
            Guid Id = experiment[0].Id;
            //Act

            
            var getById = await _experimentResultRepository.GetByIdAsync(Id);

            //Assert
            Assert.AreEqual(experiment[0].DeviceToken, getById.DeviceToken);
        }

        [Test]
        public async Task GetByDeviceTokenExperimentResult_Success()
        {
            //Arrange
            var experiment = FakeDataBogus.GenerateOneExperimentResultDtoButton();
            var result = await _experimentResultRepository.CreateAsync(experiment[0]);
            await _context.SaveChangesAsync();
            string dv = experiment[0].DeviceToken;
            //Act


            var getByDeviceToken = await _experimentResultRepository.GetByDeviceTokenAsync(dv);

            //Assert
            Assert.AreEqual(experiment[0].DeviceToken, getByDeviceToken.DeviceToken);
        }

        [Test]
        public async Task GetByValueTokenExperimentResult_Success()
        {
            //Arrange
            var experiment = FakeDataBogus.GenerateExperimentResultDtoPrice(3);
            await _experimentResultRepository.CreateAsync(experiment[0]);
            await _context.SaveChangesAsync();
            string value = experiment[0].Key;

            //Act
            var Value = await _experimentResultRepository.GetByValueAsync(value);

            //Assert
            Assert.AreEqual(_context.ExperimentResults.Where(e=>e.Key == value).Count(), Value.Count);
            
        }

        [Test]
        public async Task UpdateExperimentResult_Success()
        {
            //Arrange

            var experiment = FakeDataBogus.GenerateExperimentResultDtoPrice(3);
            await _experimentResultRepository.CreateAsync(experiment[0]);
            await _context.SaveChangesAsync();
            //Act

            var entity = FakeDataBogus.GenerateForExperimentResultDtoPrice(1);
            var result = await _experimentResultRepository.UpdateAsync(entity[0]);

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public async Task DeleteExperimentResult_Success()
        {
            //Arrange

            var experiment = FakeDataBogus.GenerateExperimentResultDtoPrice(4);
            for (int i = 0; i < experiment.Count - 1; i++)
            {
                await _experimentResultRepository.CreateAsync(experiment[i]);
                await _context.SaveChangesAsync();
            }
            //Act
            var result = await _experimentResultRepository.DeleteAsync(experiment[2].Id);

            //Assert
            Assert.IsTrue(result);
        }
    }
}
