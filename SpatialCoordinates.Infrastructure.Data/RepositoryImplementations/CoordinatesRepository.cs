using SpatialCoordinates.Domain.DomainEntities;
using SpatialCoordinates.Domain.RepositoryContracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SpatialCoordinates.Infrastructure.Data.RepositoryImplementations
{
    public class CoordinatesRepository : ICoordinatesRepository
    {
        private readonly string _localDbFullPath;

        public CoordinatesRepository()
        {
            _localDbFullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LocalFiles", "Coordinates.txt");
        }

        public void Insert(Coordinates coords)
        {
            List<string> dbAsList = File.ReadAllLines(_localDbFullPath).ToList();

            string dataToInsert = $"Coords [{coords.CoordX}, {coords.CoordY}, {coords.CoordZ}] added on {DateTime.UtcNow}";

            dbAsList.Add(dataToInsert);

            File.WriteAllLines(_localDbFullPath, dbAsList);
        }
    }
}
