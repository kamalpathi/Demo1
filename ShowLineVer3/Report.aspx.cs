using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShowLineVer3.Model;
using ShowLineVer3.ViewModel;

namespace ShowLineVer3
{
    public partial class Report : System.Web.UI.Page
    {
        string TTy = "";
        string TID = "";


        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    //EID = Request.QueryString["EID"].ToString();

                    TID = Request.QueryString["TID"].ToString();
                    TTy = Request.QueryString["TT"].ToString();

                    //TID = "T03071310401164";
                    //TTy = "ALL";

                    GetReportDetails(TID, TTy);
                }
            }
            catch (Exception ex)
            {
                ErrHandler.WriteError(ex.Message);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Error", "javascript:alert('Server is busy.Please try after sometime.');", true);
            }
        }

        private void GetReportDetails(string TID,string ticketType)
        {
            try
            {
                ReportViewModel _reportViewModel = new ReportViewModel();
                List<ReportModel> _reportModel = new List<ReportModel>();

                _reportModel = _reportViewModel.ReportList(TID, ticketType);

                //rpt.DataSource = _reportModel;
                //rpt.DataBind();

                Repeater1.DataSource = _reportModel;
                Repeater1.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            int pageSize = 2;
            if ((e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) && ((e.Item.ItemIndex + 1) % pageSize == 0))
            {
                e.Item.Controls.Add(new LiteralControl("<p style='PAGE-BREAK-AFTER: always'> </p>"));
            }
        }
    }
}