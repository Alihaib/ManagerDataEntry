using Excel = Microsoft.Office.Interop.Excel;
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;

namespace ManagerDataEntry
{
    public partial class Form1 : Form
    {
        private Excel.Application excelApp; 
        private Excel.Workbook workbook;    
        private Excel.Worksheet worksheet; 
        private int row = 2; 
        private string filePath = "C:\\Users\\HP\\OneDrive - ac.sce.ac.il\\שולחן העבודה\\database24.xlsx"; 

        private double[] averagePriceArray;
        private Dictionary<string, int> healthFundStatsArray;
        private Dictionary<string, int> insuranceStatsArray;
        private Dictionary<string, int> serviceTypeStatsArray;
        private Dictionary<string, int> cityStatsArray;

        public Form1()
        {
            InitializeComponent();
            InitializeExcel();
        }

        private void InitializeExcel()
        {
            excelApp = new Excel.Application(); 
            workbook = excelApp.Workbooks.Open(filePath); 
            worksheet = (Excel.Worksheet)workbook.Worksheets[1]; 

            
            row = worksheet.UsedRange.Rows.Count + 1;
        }
        
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            workbook.Close(false); 
            excelApp.Quit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void panelInput_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblID_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
         
            foreach (DataGridViewRow gridRow in dataGridView1.Rows)
            {
                if (gridRow.IsNewRow) continue;

                worksheet.Cells[row, 1] = gridRow.Cells[6].Value;
                worksheet.Cells[row, 2] = gridRow.Cells[5].Value;
                worksheet.Cells[row, 3] = gridRow.Cells[4].Value;
                worksheet.Cells[row, 4] = gridRow.Cells[3].Value;
                worksheet.Cells[row, 5] = gridRow.Cells[2].Value;
                worksheet.Cells[row, 6] = gridRow.Cells[1].Value;
                worksheet.Cells[row, 7] = gridRow.Cells[0].Value;

                row++;
            }

            
            workbook.Save();
            MessageBox.Show("Data saved successfully!");

        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
           
            if (string.IsNullOrWhiteSpace(txtManagerName.Text) ||
                string.IsNullOrWhiteSpace(txtManagerID.Text) ||
                string.IsNullOrWhiteSpace(txtManagerWork.Text))
            {
                MessageBox.Show("Please fill all fields.");
                return;
            }

          
            int index = dataGridView1.Rows.Add();
            dataGridView1.Rows[index].Cells[4].Value = txtManagerWork.Text;
            dataGridView1.Rows[index].Cells[5].Value = txtManagerID.Text;
            dataGridView1.Rows[index].Cells[6].Value = txtManagerName.Text;
            dataGridView1.Rows[index].Cells[3].Value = textBox2.Text;
            dataGridView1.Rows[index].Cells[2].Value = textBox1.Text;
            dataGridView1.Rows[index].Cells[1].Value = textBox3.Text;
            dataGridView1.Rows[index].Cells[0].Value = textBox4.Text;


           
            txtManagerName.Clear();
            txtManagerID.Clear();
            txtManagerWork.Clear();
            txtManagerName.Focus();
            textBox2.Clear();
            textBox1.Clear();
            textBox3.Clear();
            textBox4.Clear();

        }

        private double CalculateAveragePrice()
        {
            double totalAmount = 0;
            int count = 0;

            for (int i = 2; i <= worksheet.UsedRange.Rows.Count; i++)
            {
                double price;
                if (double.TryParse(worksheet.Cells[i, 4].Value.ToString(), out price)) 
                {
                    totalAmount += price;
                    count++;
                }
            }

            return count > 0 ? totalAmount / count : 0;
        }

        private Dictionary<string, int> CountCustomersByHealthFund()
        {
            var healthFundCount = new Dictionary<string, int>();

            for (int i = 2; i <= worksheet.UsedRange.Rows.Count; i++)
            {
                string healthFund = worksheet.Cells[i, 5].Value.ToString(); 
                if (healthFundCount.ContainsKey(healthFund))
                {
                    healthFundCount[healthFund]++;
                }
                else
                {
                    healthFundCount[healthFund] = 1;
                }
            }

            return healthFundCount;
        }

        private Dictionary<string, int> ClassifyByInsurance()
        {
            var insuranceCount = new Dictionary<string, int>();

            for (int i = 2; i <= worksheet.UsedRange.Rows.Count; i++)
            {
                string insurance = worksheet.Cells[i, 6].Value.ToString(); 
                if (insuranceCount.ContainsKey(insurance))
                {
                    insuranceCount[insurance]++;
                }
                else
                {
                    insuranceCount[insurance] = 1;
                }
            }

            return insuranceCount;
        }

        private Dictionary<string, int> ClassifyByServiceType()
        {
            var serviceTypeCount = new Dictionary<string, int>();

            for (int i = 2; i <= worksheet.UsedRange.Rows.Count; i++)
            {
                string serviceType = worksheet.Cells[i, 3].Value.ToString(); 
                if (serviceTypeCount.ContainsKey(serviceType))
                {
                    serviceTypeCount[serviceType]++;
                }
                else
                {
                    serviceTypeCount[serviceType] = 1;
                }
            }

            return serviceTypeCount;
        }

        private Dictionary<string, int> ClassifyByCity()
        {
            var cityCount = new Dictionary<string, int>();

            for (int i = 2; i <= worksheet.UsedRange.Rows.Count; i++)
            {
                string city = worksheet.Cells[i, 7].Value.ToString(); 
                if (cityCount.ContainsKey(city))
                {
                    cityCount[city]++;
                }
                else
                {
                    cityCount[city] = 1;
                }
            }

            return cityCount;
        }



        private void lblWork_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void panelInput_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            double averagePrice = CalculateAveragePrice();
            var healthFundStats = CountCustomersByHealthFund();
            var insuranceStats = ClassifyByInsurance();
            var serviceTypeStats = ClassifyByServiceType();
            var cityStats = ClassifyByCity();

            // Save the results into the arrays
            averagePriceArray = new double[] { averagePrice }; 
            healthFundStatsArray = new Dictionary<string, int>(healthFundStats);
            insuranceStatsArray = new Dictionary<string, int>(insuranceStats);
            serviceTypeStatsArray = new Dictionary<string, int>(serviceTypeStats);
            cityStatsArray = new Dictionary<string, int>(cityStats);

            
            StringBuilder statisticsBuilder = new StringBuilder();

           
            statisticsBuilder.AppendLine($"ממוצע לפי מחיר: {averagePrice} ש\"ח");

           
            statisticsBuilder.AppendLine("\nלקוחות לפי קופת חולים:");
            foreach (var entry in healthFundStatsArray)
            {
                statisticsBuilder.AppendLine($"{entry.Key}: {entry.Value} לקוחות");
            }

            
            statisticsBuilder.AppendLine("\nלקוחות לפי ביטוח:");
            foreach (var entry in insuranceStatsArray)
            {
                statisticsBuilder.AppendLine($"{entry.Key}: {entry.Value} לקוחות");
            }

            
            statisticsBuilder.AppendLine("\nסיווג לפי סוג שירות:");
            foreach (var entry in serviceTypeStatsArray)
            {
                statisticsBuilder.AppendLine($"{entry.Key}: {entry.Value} שירותים");
            }

            statisticsBuilder.AppendLine("\nסיווג לפי עיר:");
            foreach (var entry in cityStatsArray)
            {
                statisticsBuilder.AppendLine($"{entry.Key}: {entry.Value} שירותים");
            }

            
            MessageBox.Show(statisticsBuilder.ToString(), "סיכום סטטיסטיקות");
        }


    }
}