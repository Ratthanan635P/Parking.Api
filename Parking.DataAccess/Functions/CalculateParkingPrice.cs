using System;
using System.Collections.Generic;
using System.Text;

namespace Parking.TesT
{

	public class CalculateParkingPrice
	{
		private int Mode;
		private double SumPropertyValue;
		private List<double> TaxAll = new List<double>();
		public List<OrderCalculate> OrderCalculatees { get; set; }
		public decimal SumTaxValue { get; set; }
		private long[] RangeTax1 = new long[] { 0, 50000000, 200000000, 1000000000, 5000000000 };
		private double[] Tax1 = new double[] { 0.003, 0.004, 0.005, 0.006, 0.007 };

		private long[,] RangeTax = new long[,] { { 5,0, 4, 6, 12, 24,0 }
												,{5, 0, 50000000, 125000000, 150000000, 550000000,1050000000}
												,{ 5,0, 50000000, 75000000, 100000000, 0,0 }
												,{ 5,0, 10000000, 50000000, 75000000, 100000000,0 }
											   };
		private double[,] RangeCalTax = new double[,] { { 5,20, 30, 40, 50, 60,0 }
														,{5, 0.0000, 0.0001, 0.0003, 0.0005, 0.0007,0.001 }
														,{ 5,0.0000, 0.0003, 0.0005, 0.001, 0,0 }
														,{ 5,0.0000, 0.0002, 0.0003, 0.0005, 0.001,0 }
											  };
		public CalculateParkingPrice(double? sumPropertyValue, int mode)
		{
			Mode = mode;
			SumPropertyValue = (double)sumPropertyValue;
			OrderCalculatees = new List<OrderCalculate>();
			CalculateTaxType(mode);
		}
		private void CalculateTaxType(int type)
		{
			TaxAll.Clear();
			OrderCalculatees.Clear();
			switch (type)
			{
				case 1://emptyTax Cal
					   //TaxCalculationEmptyfix();
					TaxCalculationEmtry();
					break;
				case 2://FarmTax Cal
					//TaxCalculationFarm();
					break;
				case 3://homeLandTax Cal
					//TaxCalculationHomeLand();
					break;
				case 4://HomeTax Cal
					//TaxCalculationBuild();
					break;
				default:
					break;
			}
		}
		private void TaxCalculationEmptyFix()
		{
			if ((SumPropertyValue >= RangeTax1[0]) && (SumPropertyValue <= RangeTax1[1]))
			{
				double sum = SumPropertyValue * Tax1[0];
				TaxAll.Add(sum);
			}
			else if ((SumPropertyValue > RangeTax1[1]) && (SumPropertyValue <= RangeTax1[2]))
			{
				double sum = RangeTax1[1] * Tax1[0];
				TaxAll.Add(sum);
				double ansValue = SumPropertyValue - RangeTax1[1];
				sum = ansValue * Tax1[1];
				TaxAll.Add(sum);
			}
			else if ((SumPropertyValue > RangeTax1[2]) && (SumPropertyValue <= RangeTax1[3]))
			{
				double sum = RangeTax1[1] * Tax1[0];
				TaxAll.Add(sum);
				double ansValue = SumPropertyValue - RangeTax1[1];
				sum = ansValue * Tax1[1];
				TaxAll.Add(sum);
				ansValue = ansValue - RangeTax1[2];
				sum = ansValue * Tax1[2];
				TaxAll.Add(sum);
			}
			else if ((SumPropertyValue > RangeTax1[3]) && (SumPropertyValue <= RangeTax1[4]))
			{
				double sum = RangeTax1[1] * Tax1[0];
				TaxAll.Add(sum);
				double ansValue = SumPropertyValue - RangeTax1[1];
				sum = ansValue * Tax1[1];
				TaxAll.Add(sum);
				ansValue = ansValue - RangeTax1[2];
				sum = ansValue * Tax1[2];
				TaxAll.Add(sum);
				ansValue = ansValue - RangeTax1[3];
				sum = ansValue * Tax1[3];
				TaxAll.Add(sum);
			}
			else if (SumPropertyValue > RangeTax1[4])
			{
				double sum = RangeTax1[1] * Tax1[0];
				TaxAll.Add(sum);
				double ansValue = SumPropertyValue - RangeTax1[1];
				sum = ansValue * Tax1[1];
				TaxAll.Add(sum);
				ansValue = ansValue - RangeTax1[2];
				sum = ansValue * Tax1[2];
				TaxAll.Add(sum);
				ansValue = ansValue - RangeTax1[3];
				sum = ansValue * Tax1[3];
				TaxAll.Add(sum);
				ansValue = ansValue - RangeTax1[4];
				sum = ansValue * Tax1[4];
				TaxAll.Add(sum);
			}
			var SumTax = 0.00;
			foreach (var item in TaxAll)
			{
				SumTax = SumTax + item;
			}
			SumTaxValue = Convert.ToDecimal(SumTax);
		}
		private void TaxCalculationEmtry()
		{
			int i = 0;
			int j = 1;
			if ((SumPropertyValue >= RangeTax[i, 1]) && (SumPropertyValue <= RangeTax[i, 2]))
			{
				double sum = SumPropertyValue * RangeCalTax[i, j];
				OrderCalculate OrderCalculate1 = new OrderCalculate();
				OrderCalculate1.Deduction = (long)SumPropertyValue;
				OrderCalculate1.TaxMoney = sum;
				OrderCalculate1.TaxRate = RangeCalTax[i, j];
				OrderCalculatees.Add(OrderCalculate1);
				TaxAll.Add(sum);
			}
			else if ((SumPropertyValue > RangeTax[i, 2]) && (SumPropertyValue <= RangeTax[i, 3]))
			{
				double sum = RangeTax[i, j + 1] * RangeCalTax[i, j];
				OrderCalculate OrderCalculate1 = new OrderCalculate();
				OrderCalculate1.Deduction = RangeTax[i, j + 1];
				OrderCalculate1.TaxMoney = sum;
				OrderCalculate1.TaxRate = RangeCalTax[i, j];
				OrderCalculatees.Add(OrderCalculate1);
				TaxAll.Add(sum);
				j = 2;
				OrderCalculate OrderCalculate2 = new OrderCalculate();
				double ansValue = SumPropertyValue - RangeTax[i, j];
				sum = ansValue * RangeCalTax[i, j];
				OrderCalculate2.Deduction = (long)ansValue;
				OrderCalculate2.TaxMoney = sum;
				OrderCalculate2.TaxRate = RangeCalTax[i, j];
				OrderCalculatees.Add(OrderCalculate2);
				TaxAll.Add(sum);
			}
			else if ((SumPropertyValue > RangeTax[i, 3]) && (SumPropertyValue <= RangeTax[i, 4]))
			{
				j = 1;
				OrderCalculate OrderCalculate1 = new OrderCalculate();
				double sum = RangeTax[i, j + 1] * RangeCalTax[i, j];
				OrderCalculate1.Deduction = RangeTax[i, j + 1];
				OrderCalculate1.TaxMoney = sum;
				OrderCalculate1.TaxRate = RangeCalTax[i, j];
				OrderCalculatees.Add(OrderCalculate1);
				TaxAll.Add(sum);
				j = 2;
				OrderCalculate OrderCalculate2 = new OrderCalculate();
				sum = (RangeTax[i, j + 1] - RangeTax[i, j]) * RangeCalTax[i, j];
				OrderCalculate2.Deduction = RangeTax[i, j + 1] - RangeTax[i, j];
				OrderCalculate2.TaxMoney = sum;
				OrderCalculate2.TaxRate = RangeCalTax[i, j];
				OrderCalculatees.Add(OrderCalculate2);
				TaxAll.Add(sum);
				j = 3;
				OrderCalculate OrderCalculate3 = new OrderCalculate();
				double ansValue = SumPropertyValue - RangeTax[i, j];
				sum = ansValue * RangeCalTax[i, j];
				OrderCalculate3.Deduction = (long)ansValue;
				OrderCalculate3.TaxMoney = sum;
				OrderCalculate3.TaxRate = RangeCalTax[i, j];
				OrderCalculatees.Add(OrderCalculate3);
				TaxAll.Add(sum);
			}
			else if ((SumPropertyValue > RangeTax[i, 4]) && (SumPropertyValue <= RangeTax[i, 5]))
			{
				j = 1;
				OrderCalculate OrderCalculate1 = new OrderCalculate();
				double sum = RangeTax[i, j + 1] * RangeCalTax[i, j];
				OrderCalculate1.Deduction = RangeTax[i, j + 1];
				OrderCalculate1.TaxMoney = sum;
				OrderCalculate1.TaxRate = RangeCalTax[i, j];
				OrderCalculatees.Add(OrderCalculate1);
				TaxAll.Add(sum);
				j = 2;
				OrderCalculate OrderCalculate2 = new OrderCalculate();
				sum = (RangeTax[i, j + 1] - RangeTax[i, j]) * RangeCalTax[i, j];
				OrderCalculate2.Deduction = RangeTax[i, j + 1] - RangeTax[i, j];
				OrderCalculate2.TaxMoney = sum;
				OrderCalculate2.TaxRate = RangeCalTax[i, j];
				OrderCalculatees.Add(OrderCalculate2);
				TaxAll.Add(sum);
				j = 3;
				OrderCalculate OrderCalculate3 = new OrderCalculate();
				sum = (RangeTax[i, j + 1] - RangeTax[i, j]) * RangeCalTax[i, j];
				OrderCalculate3.Deduction = RangeTax[i, j + 1] - RangeTax[i, j];
				OrderCalculate3.TaxMoney = sum;
				OrderCalculate3.TaxRate = RangeCalTax[i, j];
				OrderCalculatees.Add(OrderCalculate3);
				TaxAll.Add(sum);
				j = 4;
				OrderCalculate OrderCalculate4 = new OrderCalculate();
				double ansValue = SumPropertyValue - RangeTax[i, j];
				sum = ansValue * RangeCalTax[i, j];
				OrderCalculate4.Deduction = (long)ansValue;
				OrderCalculate4.TaxMoney = sum;
				OrderCalculate4.TaxRate = RangeCalTax[i, j];
				OrderCalculatees.Add(OrderCalculate4);
				TaxAll.Add(sum);
			}
			else if (SumPropertyValue > RangeTax[i, 5])
			{
				j = 1;
				OrderCalculate OrderCalculate1 = new OrderCalculate();
				double sum = RangeTax[i, j + 1] * RangeCalTax[i, j];
				OrderCalculate1.Deduction = RangeTax[i, j + 1];
				OrderCalculate1.TaxMoney = sum;
				OrderCalculate1.TaxRate = RangeCalTax[i, j];
				OrderCalculatees.Add(OrderCalculate1);
				TaxAll.Add(sum);
				j = 2;
				OrderCalculate OrderCalculate2 = new OrderCalculate();
				sum = (RangeTax[i, j + 1] - RangeTax[i, j]) * RangeCalTax[i, j];
				OrderCalculate2.Deduction = RangeTax[i, j + 1] - RangeTax[i, j];
				OrderCalculate2.TaxMoney = sum;
				OrderCalculate2.TaxRate = RangeCalTax[i, j];
				OrderCalculatees.Add(OrderCalculate2);
				TaxAll.Add(sum);
				j = 3;
				OrderCalculate OrderCalculate3 = new OrderCalculate();
				sum = (RangeTax[i, j + 1] - RangeTax[i, j]) * RangeCalTax[i, j];
				OrderCalculate3.Deduction = RangeTax[i, j + 1] - RangeTax[i, j];
				OrderCalculate3.TaxMoney = sum;
				OrderCalculate3.TaxRate = RangeCalTax[i, j];
				OrderCalculatees.Add(OrderCalculate3);
				TaxAll.Add(sum);
				j = 4;
				OrderCalculate OrderCalculate4 = new OrderCalculate();
				sum = (RangeTax[i, j + 1] - RangeTax[i, j]) * RangeCalTax[i, j];
				OrderCalculate4.Deduction = RangeTax[i, j + 1] - RangeTax[i, j];
				OrderCalculate4.TaxMoney = sum;
				OrderCalculate4.TaxRate = RangeCalTax[i, j];
				OrderCalculatees.Add(OrderCalculate4);
				TaxAll.Add(sum);
				j = 5;
				OrderCalculate OrderCalculate5 = new OrderCalculate();
				double ansValue = SumPropertyValue - RangeTax[i, j];
				sum = ansValue * RangeCalTax[i, j];
				OrderCalculate5.Deduction = (long)ansValue;
				OrderCalculate5.TaxMoney = sum;
				OrderCalculate5.TaxRate = RangeCalTax[i, j];
				OrderCalculatees.Add(OrderCalculate5);
				TaxAll.Add(sum);
			}
			var SumTax = 0.00;
			foreach (var item in TaxAll)
			{
				SumTax = SumTax + item;
			}
			SumTaxValue = Convert.ToDecimal(SumTax);
		}
		
	}
}
