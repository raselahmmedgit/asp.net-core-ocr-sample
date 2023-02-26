using Microsoft.AspNetCore.Mvc;
using lab.OCRSample.Attributes;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace lab.OCRSample.Models
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }

        public string? ProductName { get; set; }

        public decimal Price { get; set; }

        public int CategoryId { get; set; }

        public string? CategoryName { get; set; }

        //not ok without DisplayFormat attribute
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        [DisplayName("Without JQuery Plugin by Format(MM/dd/yyyy)")]
        public DateTime AppDate { get; set; }



        //[ModelBinder(BinderType = typeof(CustomDateTimeModelBinder))]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        [DisplayName("Without JQuery Plugin by Format(dd/MM/yyyy)")]
        public DateTime AppDate1 { get; set; }



        //[DisplayFormat(DataFormatString = "{0:dd/mm/yyyy}", ApplyFormatInEditMode = true)]
        //[DataType(DataType.Date)]
        [DisplayName("Without JQuery Plugin by local datetime format")]
        public DateTime AppDate2 { get; set; }



        //[DisplayFormat(DataFormatString = "{0:dd/mm/yyyy}", ApplyFormatInEditMode = true)]
        //[DataType(DataType.Date)]
        [DisplayName("JQuery Plugin - bootstrap-datepicker")]
        public DateTime AppDate3 { get; set; }



        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/mm/yyyy}")]
        [DataType(DataType.Date)]
        [DisplayName("JQuery Plugin - bootstrap-datepicker, DataType.Date")]
        //public DateTime AppDate4 { get; set; } = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        public DateTime AppDate4 { get; set; }



        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/mm/yyyy}")]
        //[DataType(DataType.Date)]
        [DisplayName("JQuery Plugin - bootstrap-datepicker")]
        //public DateTime AppDate5 { get; set; } = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));
        public DateTime AppDate5 { get; set; }
        

    }
}
