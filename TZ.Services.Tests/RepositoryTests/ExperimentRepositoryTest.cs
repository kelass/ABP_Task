using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TZ.Data;
using TZ.Domain.DbModels;
using TZ.Domain.DtoModels;
using TZ.Domain.Interfaces;
using TZ.Services.Repositories;

namespace TZ.Services.Tests.RepositoryTests
{
    public class ExperimentRepositoryTest
    {
        private readonly ApplicationDbContext _context;
        private readonly ExperimentRepository _experimentRepository;

        public ExperimentRepositoryTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()

            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

            _context = new ApplicationDbContext(options, "test");
            _experimentRepository = new ExperimentRepository(_context);
        }
        [Test]
        public async Task CreateExperimentResult_Success()
        {
            //Arrange
            var experiment = FakeDataBogus.GenerateForExperimentDtoPrice(1);
           

            //Act
            var result = await _experimentRepository.CreateAsync(experiment[0]);
            await _context.SaveChangesAsync();
            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public async Task SelectExperimentResult_Success()
        {
            //Arrange
            var experiment = FakeDataBogus.GenerateForExperimentDtoPrice(5);

            for(int i = 0; i < experiment.Count - 1; i++)
            {
               var result = await _experimentRepository.CreateAsync(experiment[i]);
               
            }
            await _context.SaveChangesAsync();

            //Act
            var select = await _experimentRepository.SelectAsync();

            //Assert
            Assert.AreEqual(_context.Experiments.Count(), select.Count);
        }

        [Test]
        public async Task GetByIdExperimentResult_Success()
        {
            //Arrange
            var experiment = FakeDataBogus.GenerateForExperimentDtoPrice(1);
            var result = await _experimentRepository.CreateAsync(experiment[0]);
            await _context.SaveChangesAsync();

            //Act
            var id = await _experimentRepository.GetByIdAsync(experiment[0].Id);

            //Assert
            Assert.AreEqual(experiment[0].Name, id.Name);
        }

        [Test]
        public async Task UpdateExperimentResult_Success()
        {
            //Arrange
            Guid Id = Guid.Parse("EB63B870-1675-4DBE-89D7-3E64BDB21F32");
            var experiment = FakeDataBogus.GenerateForExperimentDtoPriceId(Id);
            var result = await _experimentRepository.CreateAsync(experiment[0]);
            await _context.SaveChangesAsync();

            //Act
            ExperimentDto ed = new ExperimentDto { Id = Id, Name="test" };

            bool entity = await _experimentRepository.UpdateAsync(ed);

            //Assert
            Assert.IsTrue(entity);
        }

        [Test]
        public async Task DeleteExperimentResult_Success()
        {
            //Arrange
            Guid Id = Guid.Parse("EB63B870-1675-4DBE-89D7-3E64BDB21F32");
            var experiment = FakeDataBogus.GenerateForExperimentDtoPriceId(Id);
            var result = await _experimentRepository.CreateAsync(experiment[0]);
            await _context.SaveChangesAsync();

            //Act

            bool delete = await _experimentRepository.DeleteAsync(Id);
            //Assert
            Assert.IsTrue(delete);
        }
    }
}
