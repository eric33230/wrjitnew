using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLL
{
    public class OutsideBarCodePrintManager
    {
        OutsideBarCodePrintService obps = new OutsideBarCodePrintService();
        public DataTable getOutsideByCustomStyleCode(bool isStyle,string CustomStyleCode, int CartonBarcodeNeed, bool isOrderDate, string orderDate,bool isCustomStyleCode)
        {
            return obps.getOutsideByCustomStyleCode(isStyle, CustomStyleCode, CartonBarcodeNeed, isOrderDate, orderDate, isCustomStyleCode);
        }
        public DataTable getOutsideByCustomStyleBox(List<string> CustomStyleCodes)
        {
            return obps.getOutsideByCustomStyleBox(CustomStyleCodes);
        }
        public DataTable getOutsideBycartonBarcode(List<string> cartonBarcodes)
        {
            return obps.getOutsideBycartonBarcode(cartonBarcodes);
        }
    }
}
