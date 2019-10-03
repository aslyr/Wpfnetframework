using System;

namespace Wpfnetframework
{
    public class ExcelHelper
    {
        private dynamic cell;

        private dynamic sheet;

        private bool visible = false;

        /// <summary>
        /// excel帮助类Com实现
        /// </summary>
        /// <param name="filepath">filepath如果为空，则自动添加一个新excel文件</param>
        public ExcelHelper(string filepath = null)
        {
            Type excelType = Type.GetTypeFromProgID("Excel.Application");
            dynamic excel = Activator.CreateInstance(excelType);
            this.excel = excel;
            excel.Visible = true;
            if (filepath != null)
            {
                dynamic book = excel.WorkBooks.Open(filepath);
            }
            else
            {
                dynamic book = excel.WorkBooks.Add();
            }
            this.book = book;
        }

        /// <summary>
        /// 工作䈬
        /// </summary>
        public dynamic book { get; set; }

        /// <summary>
        /// 获取单元格，默认参数为字符串“a1”第a列，第1行。
        /// </summary>
        public dynamic Cell
        {
            get { return cell; }

            set
            {
                cell = sheet.Range(value);
            }
        }

        /// <summary>
        /// excel文件
        /// </summary>
        public dynamic excel { get; set; }
        /// <summary>
        /// 选取工作表，参数为int,从1开始
        /// </summary>
        public dynamic Sheet
        {
            get
            {
                return this.sheet;
            }

            set
            {
                sheet = excel.Worksheets(value);
            }
        }

        public bool Visilbe
        {
            get { return excel.Visible; }
            set { excel.Visible = value; }
        }
    }
}