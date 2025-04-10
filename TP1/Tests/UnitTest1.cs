using Xunit;
using TP1.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using TP1.Services;
using TP1.Repositories;
using TP1.DTOs;
using System.Diagnostics;
using System.Threading.Tasks;

namespace TP1.Tests
{
    public class EvenementServiceTests
    {
        [Fact]
        public async Task GetEvenementById_ExistingId_ReturnsEvenement()
        {
            // Arrange
            var data = new List<Evenement>
                {
                    new Evenement { Id = 1, Titre = "Test Product", Description = "Test Description", DateDebut = "2023-01-01", DateFin = "2023-01-02", Statut = "Active", Categorie = "Category1", LieuId = 1 },
                    new Evenement { Id = 2, Titre = "Another Product", Description = "Another Description", DateDebut = "2023-02-01", DateFin = "2023-02-02", Statut = "Inactive", Categorie = "Category2", LieuId = 2 }
                }.AsQueryable();

            var mockSet = new Mock<DbSet<Evenement>>();
            mockSet.As<IQueryable<Evenement>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Evenement>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Evenement>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Evenement>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            mockSet.Setup(m => m.Find(It.IsAny<object[]>()))
                   .Returns((object[] ids) => data.FirstOrDefault(p => p.Id == (int)ids[0]));

            // Mock du repository
            var mockRepository = new Mock<IEvenementRepository>();
            mockRepository.Setup(repo => repo.GetById(It.IsAny<int>()))
                          .Returns((int id) => data.FirstOrDefault(e => e.Id == id));

            var service = new EvenementService(mockRepository.Object);

            // Envoie de la requête
            var result = await service.GetEvenementById(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.Equal("Test Product", result.Titre);
            Assert.Equal("Test Description", result.Description);
            Assert.Equal("2023-01-01", result.DateDebut);
            Assert.Equal("2023-01-02", result.DateFin);
            Assert.Equal("Active", result.Statut);
            Assert.Equal("Category1", result.Categorie);
            Assert.Equal(1, result.LieuId);
        }

        [Fact]
        public async Task GetEvenementById_NonExistingId_ReturnsNull()
        {
            // Arrange
            var data = new List<Evenement>
                {
                    new Evenement { Id = 1, Titre = "Test Product", Description = "Test Description", DateDebut = "2023-01-01", DateFin = "2023-01-02", Statut = "Active", Categorie = "Category1", LieuId = 1 },
                    new Evenement { Id = 2, Titre = "Another Product", Description = "Another Description", DateDebut = "2023-02-01", DateFin = "2023-02-02", Statut = "Inactive", Categorie = "Category2", LieuId = 2 }
                }.AsQueryable();

            var mockSet = new Mock<DbSet<Evenement>>();
            mockSet.As<IQueryable<Evenement>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Evenement>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Evenement>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Evenement>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            mockSet.Setup(m => m.Find(It.IsAny<object[]>()))
                   .Returns((object[] ids) => data.FirstOrDefault(p => p.Id == (int)ids[0]));

            // Mock du repository
            var mockRepository = new Mock<IEvenementRepository>();
            mockRepository.Setup(repo => repo.GetById(It.IsAny<int>()))
                          .Returns((int id) => data.FirstOrDefault(e => e.Id == id));

            var service = new EvenementService(mockRepository.Object);

            // Envoie de la requête
            var exception = await Assert.ThrowsAsync<KeyNotFoundException>(() => service.GetEvenementById(3));
            Assert.Equal("Evenement with id 3 not found.", exception.Message);
        }
    }
}
