using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;

namespace week4
{
    public partial class Form1 : Form
    {
        RealEstateEntities context = new RealEstateEntities();
        List<Flat> Flats;

        Excel.Application xlApp; 
        Excel.Workbook xlWB; 
        Excel.Worksheet xlSheet; 
        public Form1()
        {
            InitializeComponent();
            LoadData();
            CreateExcel();
        }
        private void LoadData()
        {
            Flats = context.Flat.ToList();
        }
        private void CreateExcel()
        {
            string[] headers = new string[] {
            "Kód",
            "Eladó",
            "Oldal",
            "Kerület",
            "Lift",
            "Szobák száma",
            "Alapterület (m2)",
            "Ár (mFt)",
            "Négyzetméter ár (Ft/m2)"
            };
            for (int i = 0; i < headers.Length; i++)
            {
                xlSheet.Cells[i+1, i+1] = headers[i];
            }
        }
    }
}
