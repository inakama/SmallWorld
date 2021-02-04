using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LumenWorks.Framework.IO.Csv;
using SmallWorld.Service.Dtos;

namespace SmallWorld
{
    public class CSVManager
    {

        public List<PointInputDto> GetPoints(string csvPath)
        {
            var csvTable = new DataTable();
            using (var csvReader = new CsvReader(new StreamReader(System.IO.File.OpenRead(csvPath)), true))
            {
                csvTable.Load(csvReader);
            }

            List<PointInputDto> inputPoints = new List<PointInputDto>();

            for (int i = 0; i < csvTable.Rows.Count; i++)
            {
                inputPoints.Add(new PointInputDto { Id = Convert.ToInt32(csvTable.Rows[i][0].ToString()), XCoordinate = Convert.ToDouble(csvTable.Rows[i][1].ToString()), YCoordinate = Convert.ToDouble((csvTable.Rows[i][2].ToString())) });
            }

            return inputPoints;

        }
    }
}
