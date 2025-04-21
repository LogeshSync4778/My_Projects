using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMedicalStore
{
    public class MedicineDetails
    {
        /// <summary>
        /// private field used to auto Increment MedicineID that uniquely Identify as <see cref="MedicineID"/> Class Instance
        /// </summary>
        private static int s_medicineID = 100;

        /// <summary>
        /// public property used s_medicineID to store MedicineID that uniquely Identify as <see cref="MedicineID"/> Class Instance
        /// </summary>
        /// <value>Starts from MD101</value>
        public string MedicineID { get; }

        /// <summary>
        /// public property used to store Medicine name tha uniquely Identify as <see cref="MedicineName"/> Class Instance
        /// </summary>
        public string MedicineName { get; set; }

        /// <summary>
        /// public property used to store the total stock of medicine that uniquely Identify as <see cref="AvailableCount"/> Class Instance
        /// </summary>
        public int AvailableCount { get; set; }

        /// <summary>
        /// public property used to store the Medicine Price that uniquely Identify as <see cref="Price"/> Class Instance
        /// </summary>
        /// <value></value>
        public double Price { get; set; }

        /// <summary>
        /// public property used to store Expiry date of medicine that uniquely Identify as <see cref="DateOfExpiry"/> Class Instance
        /// </summary>
        public DateTime DateOfExpiry { get; set; }

        //Constructor with parameters
        public MedicineDetails(string medicineName, int availableCount, double price, DateTime dateOfExpiry)
        {
            s_medicineID++;
            MedicineID = "MD" + s_medicineID;
            MedicineName = medicineName;
            AvailableCount = availableCount;
            Price = price;
            DateOfExpiry = dateOfExpiry;
        }

        //Constructor used to read values in CSV file
        public MedicineDetails(string values)
        {
            string[] value = values.Split(",");
            MedicineID = value[0];
            s_medicineID = int.Parse(value[0].Remove(0, 2));
            MedicineName = value[1];
            AvailableCount = int.Parse(value[2]);
            Price = double.Parse(value[3]);
            DateOfExpiry = DateTime.ParseExact(value[4], "dd/MM/yyyy", null);
        }
    }
}
