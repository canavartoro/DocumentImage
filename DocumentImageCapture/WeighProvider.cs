using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentImageCapture
{
    internal class WeighProvider : SqlClient
    {
        public WeighProvider() { }

        public WeighProvider(string connstr) : base(connstr) { }

        public WeighModel GetWeigh(long seq)
        {
            WeighModel weigh = null;
            try
            {
                using (DataTable dt = FillTable(string.Concat("SELECT Plate,Weight1,Weight2,Net,FirmName,MaterialName,WaybillNo FROM dbo.Weigh2 WITH (NOLOCK) WHERE seq = ", seq)))
                {
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        weigh = new WeighModel();
                        weigh.FirmName = dt.Rows[0]["FirmName"].GetString();
                        weigh.WaybillNo = dt.Rows[0]["WaybillNo"].GetString();
                        weigh.MaterialName = dt.Rows[0]["MaterialName"].GetString();
                        weigh.Plate = dt.Rows[0]["Plate"].GetString();
                        weigh.Weight1 = dt.Rows[0]["FirmName"].GetDecimal();
                        weigh.Weight2 = dt.Rows[0]["FirmName"].GetDecimal();
                        weigh.Net = dt.Rows[0]["FirmName"].GetDecimal();
                    }
                }
            }
            catch (Exception exc)
            {
                Logger.E(exc);
            }
            return weigh;
        }

        public void AddImage(long seq, byte[] byteimage)
        {
            Execute("INSERT INTO [dbo].[Weigh_Image] (WaybillId,DocImage,Description) VALUES (@Waybill,@DocImage,@Description)",
                new SqlParameter[] {
                    new SqlParameter("Waybill",seq),
                    new SqlParameter("DocImage",byteimage),
                    new SqlParameter("Description",Environment.MachineName)});
        }
    }

    public class WeighModel
    {
        public WeighModel() { }

        public string FirmName { get; set; }
        public string WaybillNo { get; set; }
        public string MaterialName { get; set; }
        public string Plate { get; set; }
        public decimal Weight1 { get; set; }
        public decimal Weight2 { get; set; }
        public decimal Net { get; set; }

        public string FirmNameText { get { return string.Concat("Firm Name:", FirmName); } }
        public string WaybillNoText { get { return string.Concat("Waybill No:", WaybillNo); } }
        public string MaterialNameText { get { return string.Concat("Material:", MaterialName); } }
        public string PlateText { get { return string.Concat("Plate:", Plate); } }
        public string Weight1Text { get { return string.Concat("Weight1:", Weight1.ToString("N")); } }
        public string Weight2Text { get { return string.Concat("Weight2:", Weight2.ToString("N")); } }
        public string NetText { get { return string.Concat("Net:", Net.ToString("N")); } }

    }
}



