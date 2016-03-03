using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineRates.Data
{
    public class DDLConverter
    {
        public static List<DDLImage> GetDDLImage()
        {
            List<DDLImage> lstDDLImage = new List<DDLImage>();
            DDLImage objDDLImage;

            objDDLImage = new DDLImage();
            objDDLImage.ddlImgPath = "<img class='ddlImg' src='Images/Converter/Belarus.png'/>";
            objDDLImage.ddlText = "Белорусский рубль";
            objDDLImage.ddlId = -1;
            lstDDLImage.Add(objDDLImage);

            objDDLImage = new DDLImage();
            objDDLImage.ddlImgPath = "<img class='ddlImg' src='Images/Converter/EU.png'/>";
            objDDLImage.ddlText = "Евро";
            objDDLImage.ddlId = 19;
            lstDDLImage.Add(objDDLImage);

            objDDLImage = new DDLImage();
            objDDLImage.ddlImgPath = "<img class='ddlImg' src='Images/Converter/CANADA.png'/>";
            objDDLImage.ddlText = "Канадский доллар";
            objDDLImage.ddlId = 23;
            lstDDLImage.Add(objDDLImage);
            objDDLImage = new DDLImage();
            objDDLImage.ddlImgPath = "<img class='ddlImg' src='Images/Converter/japan.png'/>";
            objDDLImage.ddlText = "Японская иена";
            objDDLImage.ddlId = 67;
            lstDDLImage.Add(objDDLImage);

            objDDLImage = new DDLImage();
            objDDLImage.ddlImgPath = "<img class='ddlImg' src='Images/Converter/Sweden.png'/>";
            objDDLImage.ddlText = "Шведская крона";
            objDDLImage.ddlId = 129;
            lstDDLImage.Add(objDDLImage);

            objDDLImage = new DDLImage();
            objDDLImage.ddlImgPath = "<img class='ddlImg' src='Images/Converter/Switzerland.png'/>";
            objDDLImage.ddlText = "Швейцарский франк";
            objDDLImage.ddlId = 130;
            lstDDLImage.Add(objDDLImage);

            objDDLImage = new DDLImage();
            objDDLImage.ddlImgPath = "<img class='ddlImg' src='Images/Converter/Russia.png'/>";
            objDDLImage.ddlText = "Российский рубль";
            objDDLImage.ddlId = 190;
            lstDDLImage.Add(objDDLImage);

            objDDLImage = new DDLImage();
            objDDLImage.ddlImgPath = "<img class='ddlImg' src='Images/Converter/UK.png'/>";
            objDDLImage.ddlText = "Фунт стерлингов";
            objDDLImage.ddlId = 143;
            lstDDLImage.Add(objDDLImage);

            objDDLImage = new DDLImage();
            objDDLImage.ddlImgPath = "<img class='ddlImg' src='Images/Converter/USA.png'/>";
            objDDLImage.ddlText = "Доллар США";
            objDDLImage.ddlId = 145;
            lstDDLImage.Add(objDDLImage);

            objDDLImage = new DDLImage();
            objDDLImage.ddlImgPath = "<img class='ddlImg' src='Images/Converter/Ukraine.png'/>";
            objDDLImage.ddlText = "Украинская гривна";
            objDDLImage.ddlId = 224;
            lstDDLImage.Add(objDDLImage);

            objDDLImage = new DDLImage();
            objDDLImage.ddlImgPath = "<img class='ddlImg' src='Images/Converter/Lithuania.png'/>";
            objDDLImage.ddlText = "Литовский лит";
            objDDLImage.ddlId = 177;
            lstDDLImage.Add(objDDLImage);

            objDDLImage = new DDLImage();
            objDDLImage.ddlImgPath = "<img class='ddlImg' src='Images/Converter/Latvia.png'/>";
            objDDLImage.ddlText = "Латвийский лат";
            objDDLImage.ddlId = 176;
            lstDDLImage.Add(objDDLImage);

            objDDLImage = new DDLImage();
            objDDLImage.ddlImgPath = "<img class='ddlImg' src='Images/Converter/Norway.png'/>";
            objDDLImage.ddlText = "Норвежская крона";
            objDDLImage.ddlId = 101;
            lstDDLImage.Add(objDDLImage);

            return lstDDLImage;
        }
    }
    public class DDLImage
    {
        public string ddlImgPath;
        public string ddlText;
        public int ddlId;
    }

}